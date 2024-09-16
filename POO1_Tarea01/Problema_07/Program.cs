using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Empleado emp = new Empleado(002, "Melanie", 987654321, 3300);

            listar(emp);
            emp.cel = 999888777;
            emp.sueldo += 200;
            listar(emp);


            Console.ReadKey();
        }

        static void listar(Empleado e)
        {
            Console.WriteLine("Codigo         : " + e.codigo);
            Console.WriteLine("nombre         : " + e.nombre);
            Console.WriteLine("celular        : " + e.cel);
            Console.WriteLine("Sueldo         : " + e.sueldo);
            Console.WriteLine("Estado sueldo  : " + e.indicarSueldo());
            Console.WriteLine("____________________________________\n");
        }
    }
}
