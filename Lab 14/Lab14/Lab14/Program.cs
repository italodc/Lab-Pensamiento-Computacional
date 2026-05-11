using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EJERCICIO 1
            Console.WriteLine("EJERCICIO 1");
            CuentaBancaria cuenta1 = new CuentaBancaria("Juan Pérez", "001", 1500);
            CuentaBancaria cuenta2 = new CuentaBancaria("Ana López", "002", 3000);

            cuenta1.MostrarInformacion();
            cuenta2.MostrarInformacion();
            cuenta1.Depositar(500);
            cuenta2.Retirar(1000);


            // EJERCICIO 2

            Console.WriteLine("EJERCICIO 2");
            Producto producto1 = new Producto("Laptop", 4500, 10);
            Producto producto2 = new Producto("Mouse", 150, 25);

            producto1.MostrarInformacion();
            producto2.MostrarInformacion();
            producto1.Vender(2);
            producto2.Reabastecer(10);


            // EJERCICIO 3
            Console.WriteLine("EJERCICIO 3");

            List<decimal> notas1 = new List<decimal>() { 70, 80, 65 };
            List<decimal> notas2 = new List<decimal>() { 50, 55, 60 };

            Estudiante estudiante1 = new Estudiante("Carlos", 16, "Décimo", notas1);
            Estudiante estudiante2 = new Estudiante("María", 17, "Undécimo", notas2);

            estudiante1.MostrarInformacion();
            estudiante2.MostrarInformacion();

            estudiante1.Aprobar();
            estudiante2.Aprobar();

            estudiante2.AgregarNota(90);
            Console.WriteLine("Información actualizada:");
            estudiante2.MostrarInformacion();
            Console.ReadKey();
        }
    }
}
