using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POO1_T2_TrujilloMezaJhuli.Dao;
using POO1_T2_TrujilloMezaJhuli.Dao.DaoImpl;
using POO1_T2_TrujilloMezaJhuli.Models;

namespace POO1_T2_TrujilloMezaJhuli.Controllers
{
    public class MascotaController : Controller
    {
        // GET: Mascota
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            IMascotaDao dao = new MascotaDaoImpl();
            List<Mascota> lista = dao.ListarTodo();
            return View(lista);
        }

        public ActionResult Detalle(int id)
        {
            IMascotaDao dao = new MascotaDaoImpl();
            Mascota mascota = dao.ObtenerMascota(id);
            return View(mascota);
        }

        public ActionResult Editar(int id)
        {
            IMascotaDao dao = new MascotaDaoImpl();
            Mascota mascota = dao.ObtenerMascota(id);
            return View(mascota);
        }
        [HttpPost]
        public ActionResult Editar(Mascota m)
        {
            IMascotaDao dao = new MascotaDaoImpl();
            var procesar = dao.ActualizarMascota(m);
            return RedirectToAction("Reporte");
        }

        public ActionResult Crear()
        {
            return View(new Mascota());
        }

        [HttpPost]
        public ActionResult Crear(Mascota m)
        {
            IMascotaDao dao = new MascotaDaoImpl();
            var procesar = dao.RegistrarMascota(m);
            return RedirectToAction("Reporte");
        }

        public ActionResult Eliminar(int id)
        {
            IMascotaDao dao = new MascotaDaoImpl();
            Mascota mascota = dao.ObtenerMascota(id);
            return View(mascota);
        }
        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmation(int id)
        {
            IMascotaDao dao = new MascotaDaoImpl();
            var procesar = dao.EliminarMascota(id);
            return RedirectToAction("Reporte");
        }
    }
}