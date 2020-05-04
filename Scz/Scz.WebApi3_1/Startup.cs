
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
            //��������ע��������ȫ��������
            services.ConfigureDynamicProxy(config =>
            {
                config.Interceptors.AddTyped<CustomInterceptorAttribute>();
                //CustomInterceptorAttribute�������Ҫȫ�����ص�������
            });

            services.AddControllers();

            services.AddSwaggerDocument(); //ע��Swagger ����
            services.AddSingleton<ICustomService, CustomService>();

            //var serviceContainer = services.ToServiceContainer();//����

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

            app.UseOpenApi(); //���swagger����api�ĵ���Ĭ��·���ĵ� /swagger/v1/swagger.json��
            app.UseSwaggerUi3();//���Swagger UI������ܵ���(Ĭ��·��: /swagger).

        }
    }
}
