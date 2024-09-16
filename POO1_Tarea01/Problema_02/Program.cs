using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computadora compu = new Computadora(01, "Legion", "grey", 2500);

            listar(compu);

            compu.precio = compu.precio - (compu.precio * 0.1);

            listar(compu);


            Console.ReadKey();
        }

        static void listar(Computadora c)
        {
            Console.WriteLine("Codigo            : " + c.codigo);
            Console.WriteLine("Marca             : " + c.marca);
            Console.WriteLine("Color             : " + c.color);
            Console.WriteLine("Precio            : " + c.precio);
            Console.WriteLine("Precio en soles   : " + c.calcularPrecioSol());
            Console.WriteLine("Precio en Euros   : " + c.calcularPrecioEuro());
            Console.WriteLine("____________________________________\n");
        }
    }
}
