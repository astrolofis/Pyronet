using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pyronet.Repo.Data;
using Repo.Data.SeedData;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope=host.Services.CreateScope())
            {
                var services=scope.ServiceProvider;
                var loggerFactory=services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context=services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context,loggerFactory);
                }
                catch(Exception ex)
                {
                    var logger=loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex,"Bir Hata Oluştu");
                }
                host.Run(); 
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
