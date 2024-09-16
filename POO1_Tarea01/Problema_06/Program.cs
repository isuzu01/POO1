using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Paciente paciente = new Paciente("Alejandra", "Perez", 20, 1.60, 55);

            listar(paciente);
            paciente.edad = 17;
            listar(paciente);

            Console.ReadKey();
        }

        static void listar(Paciente p)
        {
            Console.WriteLine("Nombre         : " + p.nombre);
            Console.WriteLine("Apelllido      : " + p.apellido);
            Console.WriteLine("Edad           : " + p.edad);
            Console.WriteLine("Talla          : " + p.talla);
            Console.WriteLine("Peso           : " + p.peso);
            Console.WriteLine("Estado         : " + p.calcularEdad());
            Console.WriteLine("____________________________________\n");
        }
    }
}
