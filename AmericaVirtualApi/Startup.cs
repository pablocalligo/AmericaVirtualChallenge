using AmericaVirtualApi.Contracts;
using AmericaVirtualApi.Models;
using AmericaVirtualApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AmericaVirtualApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Configuración de la paginación
            services.Configure<PaginationSettings>(Configuration.GetSection("PaginationSettings"));
            services.AddSingleton<IPaginationSettings>(sp => sp.GetRequiredService<IOptions<PaginationSettings>>().Value);

            //Configuración de la base de datos
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            //Servicios
            services.AddSingleton<ProductService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<LogService>();


            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AmericaVirtualApi Api",
                    Description = "REST API Simple utilizada de BackEnd para una pagina de productos",
                    Contact = new OpenApiContact
                    {
                        Name = "Pablo Calligo",
                        Email = "Pabloo.call@gmail.com",
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Middleware Swagger para el endpoint JSON
            app.UseSwagger();
            //JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AmericaVirtualApi Api");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
