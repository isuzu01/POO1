using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO1_Tarea05_TrujilloMezaJhuli.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string NombreCliente { get; set; }
        public string DirCliente { get; set; }
        public string Empleado { get; set; }
    }
}