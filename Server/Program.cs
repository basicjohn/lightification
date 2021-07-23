using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                WriteTo.Console()
                .CreateLogger();

            Helpers.SimpleLogger.Log("Starting Service");

            string json = File.ReadAllText("appsettings.json");
            JObject o = JObject.Parse(json);
            AppSettings.appSettings = JsonConvert.DeserializeObject<AppSettings>(o["AppSettings"].ToString());

            //Helpers.SimpleLogger

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
