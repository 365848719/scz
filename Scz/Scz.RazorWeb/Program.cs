using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scz.RazorWeb.Models;

namespace Scz.RazorWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //初始化数据
            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                try
                {
                    var context = provider.GetRequiredService<RazorPagesMovieContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(provider);

                }
                catch (Exception ex)
                {
                    var logger = provider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");

                    throw;
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
