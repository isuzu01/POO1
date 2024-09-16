using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_07
{
    internal class Empleado
    {
        public int codigo {  get; set; }
        public string nombre {  get; set; }
        public int cel {  get; set; }
        public double sueldo {  get; set; }

        public Empleado(int codigo, string nombre, int cel, double sueldo)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.cel = cel;
            this.sueldo = sueldo;
        }

        public string indicarSueldo()
        {
            if (sueldo > 3500)
                return "mayor a 3500";
            else if (sueldo < 3500)
                return "menor a 3500";
            else
                return "igual a 3500";
        }


    }
}
