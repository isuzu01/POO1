using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Configuration;

using POO1_T2_TrujilloMezaJhuli.Dao;
using POO1_T2_TrujilloMezaJhuli.Dao.DaoImpl;
using POO1_T2_TrujilloMezaJhuli.Models;

namespace POO1_T2_TrujilloMezaJhuli.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            IClienteDao dao = new ClienteDaoImpl();
            List<Cliente> lista = dao.ListarTodo();
            return View(lista);
        }

        public ActionResult Detalle(int id)
        {
            IClienteDao dao = new ClienteDaoImpl();
            Cliente cliente = dao.ObtenerClliente(id);
            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            IClienteDao dao = new ClienteDaoImpl();
            Cliente cliente = dao.ObtenerClliente(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Editar(Cliente cli)
        {
            IClienteDao dao = new ClienteDaoImpl();
            var procesar = dao.ActualizarCliente(cli);
            return RedirectToAction("Reporte");
        }

        public ActionResult Crear()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public ActionResult Crear(Cliente c)
        {
            IClienteDao dao = new ClienteDaoImpl();
            var procesar = dao.RegistrarCliente(c);
            return RedirectToAction("Reporte");
        }

        public ActionResult Eliminar(int id)
        {
            IClienteDao dao = new ClienteDaoImpl();
            Cliente cliente = dao.ObtenerClliente(id);
            return View(cliente);
        }
        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmation(int id)
        {
            IClienteDao dao = new ClienteDaoImpl();
            var procesar = dao.EliminarCliente(id);
            return RedirectToAction("Reporte");
        }

    }
}