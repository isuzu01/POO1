using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POO1_Tarea04_MVC_ENTITY;
using POO1_Tarea04_MVC_ENTITY.Models;

namespace POO1_Tarea04_MVC_ENTITY.Controllers
{
    public class NegociosController : Controller
    {
        // GET: Negocios
            Negocios2022Entities db = new Negocios2022Entities();
        public ActionResult Index()
        {

            return View(db.usp_ProductoListar().ToList());
        }
    }
}