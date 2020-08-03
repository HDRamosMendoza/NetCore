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
            var connectionString = _configuration.GetConnectionString("dbconnection");
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("uspGetProductos", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    #region SqlDependency
                    cmd.Notification = null;
                    dependency = new SqlDependency();
                    dependency.OnChange += daniel_ramos;
                    SqlDependency.Start(connectionString);
                    #endregion

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        listProducto = new List<Producto>();
                        while (dr.Read())
                        {
                            oProducto = new Producto()
                            {
                                Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? -1 : dr.GetInt32(dr.GetOrdinal("Id")),
                                Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "NoData" : dr.GetString(dr.GetOrdinal("Nombre")),
                                Precio = dr.IsDBNull(dr.GetOrdinal("Precio")) ? Convert.ToDecimal(0) : dr.GetDecimal(dr.GetOrdinal("Precio")),
                                Stock = dr.IsDBNull(dr.GetOrdinal("Stock")) ? -1 : dr.GetInt32(dr.GetOrdinal("Stock"))
                            };
                            listProducto.Add(oProducto);
                        }
                    }
                    return listProducto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void daniel_ramos(object sender, SqlNotificationEventArgs e)
        {
            // Detecta cambios
            if (e.Type == SqlNotificationType.Change)
            {
                _tablaHub.Clients.All.SendAsync("ActualizarGrilla");
            }
            Get();
        }

      
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}