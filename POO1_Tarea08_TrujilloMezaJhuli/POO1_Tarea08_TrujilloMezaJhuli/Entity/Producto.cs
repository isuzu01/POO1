using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO1_Tarea08_TrujilloMezaJhuli.Entity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProduct { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string umedida { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Stock { get; set; }
    }
}