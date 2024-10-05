using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO1_Tarea04_MVC_Web.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public double PrecioUnidad { get; set; }
        public string NomCategoria { get; set; }
        public string NomProveedor { get; set; }
        public int Stock { get; set; }
    }
}