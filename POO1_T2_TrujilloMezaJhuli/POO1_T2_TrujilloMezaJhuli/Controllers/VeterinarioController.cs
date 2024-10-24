using POO1_T2_TrujilloMezaJhuli.Dao.DaoImpl;
using POO1_T2_TrujilloMezaJhuli.Dao;
using POO1_T2_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POO1_T2_TrujilloMezaJhuli.Controllers
{
    public class VeterinarioController : Controller
    {
        // GET: Veterinario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            List<Veterinario> lista = dao.ListarTodo();
            return View(lista);
        }

        public ActionResult Detalle(int id)
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            Veterinario veterinario = dao.ObtenerVeterinario(id);
            return View(veterinario);
        }

        public ActionResult Editar(int id)
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            Veterinario veterinario = dao.ObtenerVeterinario(id);
            return View(veterinario);
        }
        [HttpPost]
        public ActionResult Editar(Veterinario v)
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            var procesar = dao.ActualizarVeterinario(v);
            return RedirectToAction("Reporte");
        }

        public ActionResult Crear()
        {
            return View(new Veterinario());
        }

        [HttpPost]
        public ActionResult Crear(Veterinario v)
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            var procesar = dao.RegistrarVeterinario(v);
            return RedirectToAction("Reporte");
        }

        public ActionResult Eliminar(int id)
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            Veterinario veterinario = dao.ObtenerVeterinario(id);
            return View(veterinario);
        }
        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmation(int id)
        {
            IVeterinarioDao dao = new VeterinarioDaoImpl();
            var procesar = dao.EliminarVeterinario(id);
            return RedirectToAction("Reporte");
        }



    }
}