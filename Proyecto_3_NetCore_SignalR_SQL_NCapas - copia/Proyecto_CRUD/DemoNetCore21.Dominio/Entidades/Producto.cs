using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNetCore21.Dominio.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}