using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video(321, "the wild robot", 1.50, 30, 3.35);

            listar(video);
            video.precioSol += 5.50;
            listar(video);

            Console.ReadKey();
        }



        static void listar(Video v)
        {
            Console.WriteLine("Codigo                      : " + v.codigo);
            Console.WriteLine("Nombre                      : " + v.nombre);
            Console.WriteLine("Duración                    : " + v.duracion);
            Console.WriteLine("Precio en soles             : " + v.precioSol);
            Console.WriteLine("Tipo de Cambio              : " + v.tipoCambio);
            Console.WriteLine("Precio del video en dolar   : " + v.calcularPrecioVideo());
            Console.WriteLine("____________________________________\n");
        }
    }
}
