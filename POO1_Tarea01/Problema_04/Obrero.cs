using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_04
{
    internal class Obrero
    {
        public int codigo {  get; set; }
        public string nombre {  get; set; }
        public int horas {  get; set; }
        public double tarifa {  get; set; }

        public Obrero(int codigo, string nombre, int horas, double tarifa)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.horas = horas;
            this.tarifa = tarifa;
        }

        public double calcularSueldoBruto()
        {
            return horas * tarifa;
        }

        public double calcularDscAFP()
        {
            return calcularSueldoBruto() * 0.1;
        }

        public double calcularDscEPS()
        {
            return calcularSueldoBruto() * 0.05;
        }

        public double calcularSueldoNeto()
        {
            return calcularSueldoBruto() - calcularDscAFP() - calcularDscEPS();
        }
    }
}
