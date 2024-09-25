using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

using POOI_T1_TrujilloMezaJhuli.Models;

namespace POOI_T1_TrujilloMezaJhuli.Controllers
{
    public class PlanillaController : Controller
    {
        public static int contador = 0;
        public static List<Asistente> listaAsis = new List<Asistente>();
        // GET: Planilla
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult CreateTrabajador()
        {
            return View(new Trabajador());
        }

        [HttpPost]
        public ActionResult CreateTrabajador(Trabajador objtrab)
        {
            
            ViewBag.dniTrab = objtrab.dniTrab;
            ViewBag.apeTrab = objtrab.apeTrab;
            ViewBag.nomTrab = objtrab.nomTrab;
            ViewBag.fecContrato = objtrab.fecContrato;
            ViewBag.categoriaTrab = objtrab.categoriaTrab;
            ViewBag.Bonificacion = objtrab.Bonificacion();
            ViewBag.Basico = objtrab.Basico();
            ViewBag.Bonificacion = objtrab.Bonificacion();
            ViewBag.Monto = objtrab.Monto();
            

            return View(objtrab);
        }

        //<<<<<<<<<<<<<<<

        public  ActionResult CreateAsistente()
        {
            return View(new Asistente());
        }

        [HttpPost]
        public ActionResult CreateAsistente(Asistente objAsis)
        {
            Asistente asistente = new Asistente();
            asistente.dniTrab = objAsis.dniTrab;
            asistente.nomTrab = objAsis.nomTrab;
            asistente.apeTrab = objAsis.apeTrab;
            asistente.apeTrab = objAsis.apeTrab;
            asistente.fecContrato = objAsis.fecContrato;
            asistente.categoriaTrab = objAsis.categoriaTrab;
            asistente.hijos = objAsis.hijos;
            asistente.grado = objAsis.grado;

            bool existDni = listaAsis.Exists(x => x.dniTrab == objAsis.dniTrab);

            if (existDni)
            {
                ViewBag.Message = "¡¡¡¡¡ DNI ya Existe !!!!!!";
            }
            else
            {
                ViewBag.Message = ">>>>>>>>>> Asistente creado <<<<<<<<<<";

                ViewBag.dniTrab = objAsis.dniTrab;
                ViewBag.nomTrab = objAsis.nomTrab;
                ViewBag.apeTrab = objAsis.apeTrab;
                ViewBag.fecContrato = objAsis.fecContrato;
                ViewBag.categoriaTrab = objAsis.categoriaTrab;
                ViewBag.hijos = objAsis.hijos;
                ViewBag.grado = objAsis.grado;

                ViewBag.Basico = objAsis.Basico();
                ViewBag.BonificacionEspecial = objAsis.BonificacionEspecial();
                ViewBag.escolaridad = objAsis.Escolaridad();
                ViewBag.Monto = objAsis.Monto();
                contador++;
                listaAsis.Add(asistente);

            }
            
             return View(objAsis);
        }

        public ActionResult ListadoAsistente()
        {
            ViewBag.contador = contador;
            return View(listaAsis);
        }



    }
}