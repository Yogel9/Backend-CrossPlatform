using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


using Microsoft.AspNetCore.Http;//CORS
using Microsoft.Extensions.DependencyInjection;

namespace Backend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";//CORS
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        //Необязательный метод ConfigureServices() регистрирует сервисы, которые используются приложением.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(); // добавляем сервисы CORS
            //string cons = "Server=(localdb)\\mssqllocaldb;Database=OrderBd;Trusted_Connection=True;";
            //// устанавливаем контекст данных 
            //services.AddDbContext<TodoContext>(options => options.UseSqlServer(cons));
            services.AddDbContext<TodoContext>(opt =>
                  opt.UseInMemoryDatabase("MyBd"));

            //https://metanit.com/sharp/aspnet5/23.7.php
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Для установки аутентификации с помощью токенов  в методе ConfigureServices в вызов services.AddAuthentication передается значение JwtBearerDefaults.AuthenticationScheme.
                    .AddJwtBearer(options =>//добавляется конфигурация токена.
                    {
                        options.RequireHttpsMetadata = false; //RequireHttpsMetadata: если равно false, то SSL при отправке токена не используется. Однако данный вариант установлен только дя тестирования. В реальном приложении все же лучше использовать передачу данных по протоколу https.
                        options.TokenValidationParameters = new TokenValidationParameters//TokenValidationParameters: параметры валидации токена - сложный объект, определяющий, как токен будет валидироваться. Этот объект в свою очередь имеет множество свойств, которые позволяют настроить различные аспекты валидации токена. Но наиболее важные свойства: IssuerSigningKey - ключ безопасности, которым подписывается токен, и ValidateIssuerSigningKey - надо ли валидировать ключ безопасности. Ну и кроме того, можно установить ряд других свойств, таких как нужно ли валидировать издателя и потребителя токена, срок жизни токена, можно установить название clai
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),//SigningKey,
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddControllers(); // используем контроллеры без представлений

            services.AddScoped<FDeclaration, Function>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Метод Configure устанавливает, как приложение будет обрабатывать запрос.
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

            // подключаем CORS
            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  /* про мап https://metanit.com/sharp/aspnet5/2.22.php */
            });

            //if (env.IsDevelopment())//проверяет, находится ли приложение в состоянии/статусе разработки.
            //{
            //    app.UseDeveloperExceptionPage();//выводит подробные сообщения об ошибках
            //}

            //app.UseRouting();//добавляет некоторые возможности маршрутизации, благодаря чему приложение может соотносить запросы с определенными маршрутами.
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            ////app.UseEndpoints(endpoints =>//позволяет определить маршруты, которые будут обрабатываться приложением.
            ////{
            ////    endpoints.MapGet("/", async context =>  // Это выражение указывает, что для всех запросах по маршруту "/"(то есть к корню веб - приложения) в ответ будет отправляться строка "Hello World!".
            ////    {
            ////        //await context.Response.WriteAsync($"Application Name: {_env.ApplicationName}");
            ////        await context.Response.WriteAsync("Hello World!");
            ////    });
            ////});
        }
    }
}
