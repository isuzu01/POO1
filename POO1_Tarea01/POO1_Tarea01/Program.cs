using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1_Tarea01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Celular celular = new Celular(987654321, "Mariana", 60, 5);

            listar(celular);

            celular.segundos += 20;
            celular.precio = celular.precio - (celular.precio * 0.05);

            listar(celular);

            Console.ReadKey();
        }

        static void listar(Celular c)
        {
            Console.WriteLine("Número           : " + c.numero);
            Console.WriteLine("Usuario          : " + c.usuario);
            Console.WriteLine("Segundos         : " + c.segundos);
            Console.WriteLine("Pexio x seg      : " + c.precio);
            Console.WriteLine("Costo consumo    : " + c.calcularCostoXConsumo());
            Console.WriteLine("IGV              : " + c.calcularIGV());
            Console.WriteLine("Tatal            : " + c.calcularTotal());
            Console.WriteLine("____________________________________\n");
        }
    }
}
