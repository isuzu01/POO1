using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO1_Tarea05_TrujilloMezaJhuli.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public string NombreCategoria { get; set; }
        public string NomProveedor { get; set; }
        public int stock { get; set; }
    }
}