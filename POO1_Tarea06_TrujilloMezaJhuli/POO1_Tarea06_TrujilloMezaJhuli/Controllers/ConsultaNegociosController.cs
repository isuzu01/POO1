using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POO1_Tarea06_TrujilloMezaJhuli.Models;

namespace POO1_Tarea06_TrujilloMezaJhuli.Controllers
{
    public class ConsultaNegociosController : Controller
    {
        // GET: ConsultaNegocios

        Negocios2022Entities db = new Negocios2022Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductoListar()
        {
            var lista = from p in db.usp_ProductoListar() select p;
            return View(lista.ToList());
        }

        public ActionResult ProductoNombreListar(string nombre )
        {
            if(nombre == null) nombre = string.Empty;
            ViewBag.nombre = nombre;
            var lista = from p in db.usp_ProductoListar() where p.NombreProducto.StartsWith(nombre) select p;
            return View(lista.ToList());
        }

        public ActionResult PedidosCliente( string id)
        {
            if(id == null) id = string.Empty;
            ViewBag.cliente = new SelectList(db.tb_clientes.ToList(), "IdCliente", "NombreCia", id);
            var lista = from p in db.tb_pedidoscabe where p.IdCliente.Equals(id) select p;
            return View(lista.ToList());
        }
    }
}