using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using _0041_First_Application.Models.Data;
using Microsoft.Extensions.Logging.Console;

namespace _0041_First_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            host.Seed();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, builder)  =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Debug);

                builder.AddConsole();
                builder.AddLog4Net();
            })
             .ConfigureAppConfiguration((context, builder) =>
             {
                 // pas de dictionnaire, on peut rajouter le même plusieurs fois => quel est le comportement ?
                 builder.AddJsonFile("appsettings.json", false, true);
                 builder.AddJsonFile("test.json", false, true);
                 builder.AddJsonFile("oneobject.json", false, true);

             })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
