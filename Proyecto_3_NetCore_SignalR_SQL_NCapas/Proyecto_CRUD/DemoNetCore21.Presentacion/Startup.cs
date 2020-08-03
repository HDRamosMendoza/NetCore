
using DemoNetCore21.Dominio.Contratos.Repositorios;
using DemoNetCore21.Dominio.Contratos.Servicios;
using DemoNetCore21.Dominio.Servicios;
using DemoNetCore21.Infraestructura.Hubs.Hubs;
using DemoNetCore21.Infraestructura.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoNetCore21.Presentacion
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment environment)
        {
            this._environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json") 
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Activar el SIGNAL R
            services.AddSingleton(_configuration);
            services.AddSignalR();

            #region IOC

            // Te mando un INTERFAZ y en tiempo de ejecución te mano una clase
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IProductoServicio, ProductoServicio>();

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSignalR(hub =>
            {
                hub.MapHub<TablaHub>("/tablaHub");
            });

            app.UseMvc(path =>
            {
                path.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
