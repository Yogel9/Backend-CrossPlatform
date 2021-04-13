using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Backend.Models;
/*https://metanit.com/sharp/aspnet5/2.13.php*/
namespace Backend
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();//Чтобы запустить приложение ASP.NET Core, необходим объект IHost, в рамках которого развертывается веб-приложение. Для создания IHost применяется объект IHostBuilder.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => //Чтобы запустить приложение ASP.NET Core, необходим объект IHost, в рамках которого развертывается веб-приложение. Для создания IHost применяется объект IHostBuilder.
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>//Далее вызывается метод ConfigureWebHostDefaults(). Этот метод призван выполнять конфигурацию параметров хоста,
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
