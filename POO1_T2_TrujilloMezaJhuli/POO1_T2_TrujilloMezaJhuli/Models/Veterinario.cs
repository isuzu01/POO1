using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace POO1_T2_TrujilloMezaJhuli.Models
{
    public class Veterinario
    {
        public int Id_Veterinario { get; set; }
        public string  Nombre_Veterinario { get; set; }
        public string Especialidad { get; set; }
        public string  Telefono { get; set; }
        public string Email { get; set; }
    }
}