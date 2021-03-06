﻿using System;
using System.Collections.Generic;
using DemoNetCore21.Dominio.Entidades;

namespace DemoNetCore21.Dominio.Contratos.Servicios
{
    public interface IProductoServicio: IDisposable
    {
        IEnumerable<Producto> Listado();
    }

}
