using System;
using System.Collections.Generic;
using DemoNetCore21.Dominio.Contratos.Repositorios;
using DemoNetCore21.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using DemoNetCore21.Infraestructura.Hubs.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Data.SqlClient;

namespace DemoNetCore21.Infraestructura.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly IConfiguration _configuration;
        /* 
        * Para se uso de los HUB de SIGNAL R. IHubContext.
        * Ayuda a ver los cambios que se da en la tabla con SQLDependency.
        */
        private readonly IHubContext<TablaHub> _tablaHub;

        public ProductoRepositorio(IConfiguration configuration, IHubContext<TablaHub> tablaHub)
        {
            this._configuration = configuration;
            this._tablaHub = tablaHub;
        }

        public IEnumerable<Producto> Get()
        {
            List<Producto> listProducto = null;
            Producto oProducto = null;
            SqlDependency dependency = null;

            /*Usando ADO .NET*/
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("dbconnection")))
            {
                try
                {

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}