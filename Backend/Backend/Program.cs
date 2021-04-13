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
            CreateHostBuilder(args).Build().Run();//����� ��������� ���������� ASP.NET Core, ��������� ������ IHost, � ������ �������� �������������� ���-����������. ��� �������� IHost ����������� ������ IHostBuilder.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => //����� ��������� ���������� ASP.NET Core, ��������� ������ IHost, � ������ �������� �������������� ���-����������. ��� �������� IHost ����������� ������ IHostBuilder.
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>//����� ���������� ����� ConfigureWebHostDefaults(). ���� ����� ������� ��������� ������������ ���������� �����,
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
