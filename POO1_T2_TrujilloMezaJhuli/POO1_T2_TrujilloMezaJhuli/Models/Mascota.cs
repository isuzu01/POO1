using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO1_T2_TrujilloMezaJhuli.Models
{
    public class Mascota
    {
        public int Id_Mascota { get; set; }
        public string Nombre_Mascota { get; set; }
        public string Especie {  get; set; }
        public string Raza { get; set; }
        public int Edad {  get; set; }
        public int Id_Cliente { get; set; }
    }
}