using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_09
{
    internal class Pelota
    {
        public string marca {  get; set; }
        public double peso {  get; set; }
        public double presion {  get; set; }
        public double diametro {  get; set; }
        public double precio {  get; set; }

        public Pelota(string marca, double peso, double presion, double diametro, double precio)
        {
            this.marca = marca;
            this.peso = peso;
            this.presion = presion;
            this.diametro = diametro;
            this.precio = precio;
        }

        public double calcularRadio()
        {
            return diametro / 2;
        }

        public double calcularVolumen()
        {
            return 4 * 3.1416 * calcularRadio() * calcularRadio() * (calcularRadio() / 3);
        }

        public double calcularDescuento()
        {
            return precio * 0.1;
        }

        public double calcularImporte()
        {
            return precio - calcularDescuento();
        }
    }
}
