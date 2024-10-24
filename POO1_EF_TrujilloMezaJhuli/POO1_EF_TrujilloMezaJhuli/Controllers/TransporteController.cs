using POO1_EF_TrujilloMezaJhuli.dao.daoImpl;
using POO1_EF_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POO1_EF_TrujilloMezaJhuli.Controllers
{
    public class TransporteController : Controller
    {
        private TransporteDaoImpl dao = new TransporteDaoImpl();

        public ActionResult Reporte()
        {
            List<Transporte> lista = dao.consultarTodo();
            return View(lista);
        }

        public ActionResult Detalle(int id)
        {
            Transporte t = dao.obtenerTransporte(id);
            return View(t);
        }

        public ActionResult Crear()
        {
            int contar = dao.consultarTodo().Count() + 1;
            ViewBag.id = contar;
            return View(new Transporte());
        }

        [HttpPost]
        public ActionResult Crear(Transporte t)
        {
            

            if (ModelState.IsValid)
            {
               
                int procesar = dao.registrar(t);

                if (procesar >= 0)
                {

                    return RedirectToAction("Reporte");
                }
                else
                {
                    ViewBag.Mensaje = "ocurrio un error al registrar ";
                    return View(t);
                }
            }
            return View(t);
        }

        public ActionResult Editar(int id)
        {
            Transporte t = dao.obtenerTransporte(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Editar(Transporte t)
        {
            if (ModelState.IsValid)
            {
                int procesar = dao.actualizar(t);

                if (procesar >= 0)
                {
                    return RedirectToAction("Reporte");
                }
                else
                {
                    ViewBag.Mensaje = "ocurrio un error al registrar el Cambio";
                    return View(t);
                }
            }
            return View(t);
        }

        public ActionResult Eliminar(int id)
        {
            Transporte t = dao.obtenerTransporte(id);
            return View(t);
        }
        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            dao.eliminar(id);
            return RedirectToAction("Reporte");
        }
    }
}