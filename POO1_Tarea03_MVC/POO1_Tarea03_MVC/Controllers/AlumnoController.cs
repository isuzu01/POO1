using POO1_Tarea03_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POO1_Tarea03_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public static List<Alumno> listaAlumno = new List<Alumno>();
        public static int cuenta = 0;
        public ActionResult Index()
        {
            if (cuenta == 0)
            {
                listaAlumno = new List<Alumno>
                {
                    new Alumno() { Alumno_id = 1, Alumno_nombre = "Ana", Edad = 14 },
                    new Alumno() { Alumno_id = 2, Alumno_nombre = "Juan", Edad = 15 },
                    new Alumno() { Alumno_id = 3, Alumno_nombre = "Maria", Edad = 12 },
                    new Alumno() { Alumno_id = 4, Alumno_nombre = "Juan", Edad = 15 },
                    new Alumno() { Alumno_id = 5, Alumno_nombre = "Elena", Edad = 14 },
                    new Alumno() { Alumno_id = 6, Alumno_nombre = "Pedro", Edad = 14 },
                    new Alumno() { Alumno_id = 7, Alumno_nombre = "luis", Edad = 13 },
                    new Alumno() { Alumno_id = 8, Alumno_nombre = "Carlos", Edad = 14 }

                };
                cuenta++;
            }
            return View(listaAlumno);
        }

        public ActionResult Crear()
        {
            return View(new Alumno());
        }
        [HttpPost]
        public ActionResult Crear(Alumno obj)
        {
            int cantidad = listaAlumno.Count() + 1;
            Alumno alumno = new Alumno();
            alumno.Alumno_id = cantidad;
            alumno.Alumno_nombre = obj.Alumno_nombre;
            alumno.Edad = obj.Edad;
            
            listaAlumno.Add(alumno);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {

            Alumno alumno = listaAlumno.Where(a => a.Alumno_id == id).FirstOrDefault();
            return View(alumno);
        }
        [HttpPost]
        public ActionResult Editar(Alumno alumno)
        {
            Alumno alu = listaAlumno.Where(a => a.Alumno_id == alumno.Alumno_id).FirstOrDefault();
            alu.Alumno_nombre = alumno.Alumno_nombre;
            alu.Edad = alumno.Edad;

            return RedirectToAction("Index");
        }
    }
}