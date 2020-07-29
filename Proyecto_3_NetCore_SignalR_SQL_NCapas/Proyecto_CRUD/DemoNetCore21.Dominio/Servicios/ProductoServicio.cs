using DemoNetCore21.Dominio.Contratos.Repositorios;
using DemoNetCore21.Dominio.Contratos.Servicios;
using DemoNetCore21.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNetCore21.Dominio.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;
        // Vamos a utilizar este contrato con inyeccion de independencias
        public ProductoServicio(IProductoRepositorio productoRepositorio)
        {
            this._productoRepositorio = productoRepositorio;
        }

        public IEnumerable<Producto> Listado()
        {
            return _productoRepositorio.Get();
        }

        // Que lo elimine despues de haberlo utilizado
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
