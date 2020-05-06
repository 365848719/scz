
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scz.WebApi3_1.Attribute;
using Scz.WebApi3_1.Services;

namespace Scz.WebApi3_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;//return versions in a response header
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);//default version select 
                o.AssumeDefaultVersionWhenUnspecified = true;//if not specifying an api version,show the default version
            });

            //根据属性注入来配置全局拦截器
            services.ConfigureDynamicProxy(config =>
            {
                config.Interceptors.AddTyped<CustomInterceptorAttribute>();
                //CustomInterceptorAttribute这个是需要全局拦截的拦截器
            });

            services.AddControllers();

          //  services.AddSwaggerGen(s =>
          //  {
          //      //...

          //      //Show the api version in url address
          //      s.DocInclusionPredicate((version, apiDescription) =>
          //      {
          //      if (!version.Equals(apiDescription.GroupName))
          //          return false; var values = apiDescription.RelativePath
          //          .Split('/')
          //          .Select(v => v.Replace("v{version}", apiDescription.GroupName)); apiDescription.RelativePath = string.Join("/", values);
          //      return true;

          //);
          //  });

            services.AddSwaggerDocument(config=> {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ToDo API";
                    document.Info.Description = "A simple ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            }); //注册Swagger 服务

            services.AddSingleton<ICustomService, CustomService>();

            //var serviceContainer = services.ToServiceContainer();//容器

            //serviceContainer.Build();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi(); //添加swagger生成api文档（默认路由文档 /swagger/v1/swagger.json）
            app.UseSwaggerUi3();//添加Swagger UI到请求管道中(默认路由: /swagger).

        }
    }
}
