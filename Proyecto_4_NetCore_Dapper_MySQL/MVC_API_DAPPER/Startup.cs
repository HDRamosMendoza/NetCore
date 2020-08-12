using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVC_API_DAPPER.Common;
using MVC_API_DAPPER.IServices;
using MVC_API_DAPPER.Services;

namespace MVC_API_DAPPER
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            /* Averiguar sobre AddSingleton */
            services.AddSingleton<IConfiguration>(Configuration);
            /* Connection string - MySQL */
            Global.ConnectionMySQL = Configuration.GetConnectionString("MySQLDB");
            /* Connection string - SQL SERVER */
            Global.ConnectionSQLServer = Configuration.GetConnectionString("SQLServerDB");
            /* Connection string - SQL SERVER */
            Global.ConnectionString = Configuration.GetConnectionString("StudentDB");
            /* Connection string - ORACLE */
            Global.ConnectionOracle = Configuration.GetConnectionString("OracleDB");
            /* Connection string - POSTGRES */
            Global.ConnectionPostgres = Configuration.GetConnectionString("PostgresDB");

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPositionService, PositionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
