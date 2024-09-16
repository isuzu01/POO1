using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edificio edif = new Edificio(111, 3, 15, 1500);

            listar(edif);
            edif.precio = edif.precio + (edif.precio * 0.2);
            listar(edif);

            Console.ReadKey();
        }

        static void listar(Edificio e)
        {
            Console.WriteLine("Codigo              : " + e.codigo);
            Console.WriteLine("n° de dptos         : " + e.numDepa);
            Console.WriteLine("cantidad de pisos   : " + e.cantPisos);
            Console.WriteLine("Precio              : " + e.precio);
            Console.WriteLine("precio de edificio  : " + e.calcularPrecio());
            Console.WriteLine("____________________________________\n");
        }
    }
}
