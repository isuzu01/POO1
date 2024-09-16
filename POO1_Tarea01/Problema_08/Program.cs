using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Asesor asesor = new Asesor(01, "Camila", 10, 10);

            listar(asesor);
            asesor.horas += 10;
            asesor.tarifa = asesor.tarifa - (asesor.tarifa * 0.15);
            listar(asesor);


            Console.ReadKey();
        }

        static void listar(Asesor a)
        {
            Console.WriteLine("Codigo         : " + a.codigo);
            Console.WriteLine("nombre         : " + a.nombre);
            Console.WriteLine("horas          : " + a.horas);
            Console.WriteLine("tarifa         : " + a.tarifa);
            Console.WriteLine("Sueldo bruto   : " + a.calcularSueldoBruto());
            Console.WriteLine("descuento      : " + a.calcularDesc());
            Console.WriteLine("sueldo neto    : " + a.calcularSueldoNeto());
            Console.WriteLine("____________________________________\n");
        }
    }
}
