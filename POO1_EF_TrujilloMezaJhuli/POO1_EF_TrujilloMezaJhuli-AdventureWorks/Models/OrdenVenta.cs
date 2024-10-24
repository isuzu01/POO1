using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO1_EF_TrujilloMezaJhuli_AdventureWorks.Models
{
    public class OrdenVenta
    {
        public int SalesOrderID { get; set; } 
        public string Cliente { get; set; } 
        public string Vendedor { get; set; } 
        public int VendedorID { get; set; }
        public string Producto { get; set; } 
        public DateTime OrderDate { get; set; } 
        public decimal TotalDue { get; set; } 

    }
}