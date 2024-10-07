using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using POO1_Tarea05_TrujilloMezaJhuli;
using POO1_Tarea05_TrujilloMezaJhuli.Models;

namespace POO1_Tarea05_TrujilloMezaJhuli.Controllers
{
    public class NegociosController : Controller
    {
        // GET: Negocios

        AccesoDatos db = new AccesoDatos();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarClientes()
        {
            return View(db.ClienteListar());
        }

        public ActionResult ListarPedidos()
        {
            return View(db.PedidoListar());
        }

        public ActionResult ListarProductoXNombre(string nombre = null )
        {
            if (nombre == null) nombre = string.Empty;
            ViewBag.nombre = nombre;
            Debug.WriteLine(nombre);
            return View(db.ProductoListar(nombre).ToList());
        }

        public ActionResult ListarProductoCategoria(string nombrecat = null)
        {
            if (nombrecat == null) nombrecat = string.Empty;
            ViewBag.nombrecat = nombrecat;
            Debug.WriteLine(nombrecat);
            return View(db.ProductoXcategoriaLista(nombrecat).ToList());
        }
    }
}