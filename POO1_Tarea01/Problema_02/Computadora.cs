using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_02
{
    internal class Computadora
    {
        public int codigo {  get; set; }
        public string marca {  get; set; }
        public string color {  get; set; }
        public double precio {  get; set; }

        public Computadora(int codigo, string marca, string color, int precio)
        {
            this.codigo = codigo;
            this.marca = marca;
            this.color = color;
            this.precio = precio;
        }

        public double calcularPrecioSol()
        {
            return precio * 3.35;
        }

        public double calcularPrecioEuro()
        {
            return precio * 1.20;
        }











    }
}
