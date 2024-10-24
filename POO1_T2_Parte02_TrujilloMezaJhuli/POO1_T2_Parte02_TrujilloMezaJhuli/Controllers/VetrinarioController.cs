using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POO1_T2_Parte02_TrujilloMezaJhuli.Models;
using Newtonsoft.Json;
using System.IO;

namespace POO1_T2_Parte02_TrujilloMezaJhuli.Controllers
{
    public class VeterinarioController : Controller
    {
        // GET: Veterinario
        private static List<Veterinario> veterinarios = new List<Veterinario>
        {
            new Veterinario {
                Id_Veterinario = 1,
                Nombre_Veterinario = "Dr. Juan Pérez",
                Especialidad = "Cirugía",
                Telefono = "123456789",
                Email = "juan.perez@veterinaria.com"
            },
            new Veterinario
            {
                Id_Veterinario = 2,
                Nombre_Veterinario = "Dra. Ana López",
                Especialidad = "Dermatología",
                Telefono = "987654321",
                Email = "ana.lopez@veterinaria.com"
            }
        };

        public ActionResult Index()
        {
            return View(veterinarios);
        }


        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Agregar(Veterinario veterinario)
        {
            if (!veterinarios.Any(v => v.Id_Veterinario == veterinario.Id_Veterinario))
            {
                veterinarios.Add(veterinario);
                return RedirectToAction("Index");
            }
            ViewBag.Error = "El Id del veterinario ya existe.";
            return View();
        }


        public ActionResult Eliminar(int id)
        {
            var veterinario = veterinarios.FirstOrDefault(v => v.Id_Veterinario == id);
            if (veterinario == null)
            {
                return RedirectToAction("Index");
            }
            return View(veterinario);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            var veterinario = veterinarios.FirstOrDefault(v => v.Id_Veterinario == id);
            if (veterinario != null)
            {
                veterinarios.Remove(veterinario);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Serializar()
        {
            string path = @"D:\veterinarios.txt"; 

            try
            {
                string json = JsonConvert.SerializeObject(veterinarios, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter(path, false)) 
                {
                    writer.WriteLine(json); 
                }
                
                ViewBag.Message = "Datos almacenados correctamente en D:/veterinarios.txt";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error al almacenar los datos: {ex.Message}";
            }

            return View();
        }
    }
}
