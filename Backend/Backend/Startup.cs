using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // ������������ ���� EntityFramework
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        //�������������� ����� ConfigureServices() ������������ �������, ������� ������������ �����������.
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddDbContext<TodoContext>(opt =>
                  opt.UseInMemoryDatabase("MyBd"));

            //https://metanit.com/sharp/aspnet5/23.7.php
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//��� ��������� �������������� � ������� �������  � ������ ConfigureServices � ����� services.AddAuthentication ���������� �������� JwtBearerDefaults.AuthenticationScheme.
                    .AddJwtBearer(options =>//����������� ������������ ������.
                    {
                        options.RequireHttpsMetadata = false; //RequireHttpsMetadata: ���� ����� false, �� SSL ��� �������� ������ �� ������������. ������ ������ ������� ���������� ������ �� ������������. � �������� ���������� ��� �� ����� ������������ �������� ������ �� ��������� https.
                        options.TokenValidationParameters = new TokenValidationParameters//TokenValidationParameters: ��������� ��������� ������ - ������� ������, ������������, ��� ����� ����� ��������������. ���� ������ � ���� ������� ����� ��������� �������, ������� ��������� ��������� ��������� ������� ��������� ������. �� �������� ������ ��������: IssuerSigningKey - ���� ������������, ������� ������������� �����, � ValidateIssuerSigningKey - ���� �� ������������ ���� ������������. �� � ����� ����, ����� ���������� ��� ������ �������, ����� ��� ����� �� ������������ �������� � ����������� ������, ���� ����� ������, ����� ���������� �������� clai
                        {
                            // ��������, ����� �� �������������� �������� ��� ��������� ������
                            ValidateIssuer = true,
                            // ������, �������������� ��������
                            ValidIssuer = AuthOptions.ISSUER,

                            // ����� �� �������������� ����������� ������
                            ValidateAudience = true,
                            // ��������� ����������� ������
                            ValidAudience = AuthOptions.AUDIENCE,
                            // ����� �� �������������� ����� �������������
                            ValidateLifetime = true,

                            // ��������� ����� ������������
                            IssuerSigningKey = AuthOptions.SigningKey,
                            // ��������� ����� ������������
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //����� Configure �������������, ��� ���������� ����� ������������ ������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  /* ��� ��� https://metanit.com/sharp/aspnet5/2.22.php */
            });

            //if (env.IsDevelopment())//���������, ��������� �� ���������� � ���������/������� ����������.
            //{
            //    app.UseDeveloperExceptionPage();//������� ��������� ��������� �� �������
            //}

            //app.UseRouting();//��������� ��������� ����������� �������������, ��������� ���� ���������� ����� ���������� ������� � ������������� ����������.
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            ////app.UseEndpoints(endpoints =>//��������� ���������� ��������, ������� ����� �������������� �����������.
            ////{
            ////    endpoints.MapGet("/", async context =>  // ��� ��������� ���������, ��� ��� ���� �������� �� �������� "/"(�� ���� � ����� ��� - ����������) � ����� ����� ������������ ������ "Hello World!".
            ////    {
            ////        //await context.Response.WriteAsync($"Application Name: {_env.ApplicationName}");
            ////        await context.Response.WriteAsync("Hello World!");
            ////    });
            ////});
        }
    }
}
