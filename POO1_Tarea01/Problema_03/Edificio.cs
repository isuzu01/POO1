using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_03
{
    internal class Edificio
    {
        public int codigo {  get; set; }
        public int numDepa {  get; set; }
        public int cantPisos {  get; set; }
        public double precio {  get; set; }

        public Edificio(int codigo, int numDepa, int cantPisos, double precio)
        {
            this.codigo = codigo;
            this.numDepa = numDepa;
            this.cantPisos = cantPisos;
            this.precio = precio;
        }

        public double calcularPrecio()
        {
            return numDepa * precio;
        }
    }
}
