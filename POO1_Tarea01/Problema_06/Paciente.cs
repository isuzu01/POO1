using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_06
{
    internal class Paciente
    {
        public string nombre {  get; set; }
        public string apellido {  get; set; }
        public int edad {  get; set; }
        public double talla {  get; set; }
        public double peso {  get; set; }

        public Paciente(string nombre, string apellido, int edad, double talla, double peso)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.talla = talla;
            this.peso = peso;
        }


        public string calcularEdad()
        {
            if (edad < 18)
                return "Menor de edad";
            else
                return "Mayor de edad";
        }







    }
}
