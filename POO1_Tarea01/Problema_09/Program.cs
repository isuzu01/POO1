using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pelota pelota = new Pelota("ball", 50, 30, 25, 100);

            listar(pelota);
            pelota.precio = pelota.precio - (pelota.precio * 0.25);
            pelota.diametro += 1;
            listar(pelota);


            Console.ReadKey();
        }

        static void listar(Pelota p)
        {
            Console.WriteLine("Marca                : " + p.marca);
            Console.WriteLine("peso                 : " + p.peso);
            Console.WriteLine("presion libras       : " + p.presion);
            Console.WriteLine("diametro cm          : " + p.diametro);
            Console.WriteLine("precio               : " + p.precio);
            Console.WriteLine("Radio                : " + p.calcularRadio());
            Console.WriteLine("volumen del balon    : " + p.calcularVolumen());
            Console.WriteLine("descuento            : " + p.calcularDescuento());
            Console.WriteLine("Importe              : " + p.calcularImporte());
            Console.WriteLine("____________________________________\n");
        }
    }
}
