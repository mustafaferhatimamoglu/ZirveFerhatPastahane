using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZirveFerhatPastahane
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Islemler.Configs.ReadConfigs();
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyyMMdd");
            int sqlFormattedDate2 = Convert.ToInt32(sqlFormattedDate);
            if (Convert.ToInt32(Islemler.Configs.LisansDate.Replace("-","")) < sqlFormattedDate2)
            {
                Console.WriteLine("Lisans Süreniz Bitmiþtir");
                return;
            }
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
