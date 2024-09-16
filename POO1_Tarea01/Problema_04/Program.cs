using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obrero obrero = new Obrero(123, "Pedro", 8, 5);

            listar(obrero);
            obrero.horas +=  8;
            obrero.tarifa = obrero.tarifa - (obrero.tarifa * 0.15);
            listar(obrero);


            Console.ReadKey();
        }


        static void listar(Obrero o)
        {
            Console.WriteLine("Codigo              : " + o.codigo);
            Console.WriteLine("Nombre              : " + o.nombre);
            Console.WriteLine("Horas trabajadas   : " + o.horas);
            Console.WriteLine("Tirifa x hora       : " + o.tarifa);
            Console.WriteLine("Sueldo Bruto        : " + o.calcularSueldoBruto());
            Console.WriteLine("Descuento AFP       : " + o.calcularDscAFP());
            Console.WriteLine("Descuento EPS       : " + o.calcularDscEPS());
            Console.WriteLine("Sueldo Neto         : " + o.calcularSueldoNeto());
            Console.WriteLine("____________________________________\n");
        }
    }
}
