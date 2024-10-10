using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace POO1_T2_TrujilloMezaJhuli.Models
{
    public class Cliente
    {
        public int Id_Cliente {  get; set; }
        public string Nombre_Cliente {  get; set; }
        public string Direccion {  get; set; }
        public string Telefono {  get; set; }
        public string Email {  get; set; }
        public DateTime Fecha_Registro {  get; set; }
    }
}