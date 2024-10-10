using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            IClienteDao daocli = new ClienteDaoImpl();
            ViewBag.Clientes = new SelectList(daocli.ListarTodo(), "Id_Cliente", "Nombre_Cliente", mascota.Id_Cliente);

            return View(mascota);
        }
        [HttpPost]
        public ActionResult Editar(Mascota m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IClienteDao daocli = new ClienteDaoImpl();
                    ViewBag.Clientes = new SelectList(daocli.ListarTodo(), "Id_Cliente", "Nombre_Cliente", m.Id_Cliente);

                    IMascotaDao daom = new MascotaDaoImpl();
                    daom.ActualizarMascota(m); // Llama al método de actualización en lugar de registrar

                    return RedirectToAction("Reporte");
                }

                return View(m);
            }
            catch
            {
                Debug.WriteLine("error");
                return View(m);
            }
        }

        public ActionResult Crear()
        {
            IClienteDao daocli = new ClienteDaoImpl();
            ViewBag.Clientes = new SelectList(daocli.ListarTodo(), "Id_Cliente", "Nombre_Cliente");

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Mascota m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IClienteDao daocli = new ClienteDaoImpl();
                    ViewBag.Clientes = new SelectList(daocli.ListarTodo(), "Id_Cliente", "Nombre_Cliente");

                    IMascotaDao daom = new MascotaDaoImpl();
                    daom.RegistrarMascota(m);

                    return RedirectToAction("Reporte");
                }

                return View(m);
            }
            catch
            {
                Debug.WriteLine("error");
                return View(m);

            }
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