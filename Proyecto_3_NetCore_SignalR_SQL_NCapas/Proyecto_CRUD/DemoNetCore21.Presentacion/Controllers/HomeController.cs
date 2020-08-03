using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoNetCore21.Dominio.Contratos.Servicios;

namespace DemoNetCore21.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductoServicio _productoServicio;
        public HomeController(IProductoServicio productoServicio)
        {
            this._productoServicio = productoServicio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult listadoProductos()
        {
            var data = _productoServicio.Listado().ToList();
            return Json(data);
        }
    }
}