using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("¿Como te llamas?");
            string name = Console.ReadLine();
            //Salida de Usuario
            Console.WriteLine("Hola " + name);


            //Ejercicio 1
            Console.WriteLine("Ejercicio 1");
            int i = 1;
            string nombre = "Italo Fernando Díaz Castillo";
            string carnet = "1059826";
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Carnet: " + carnet);
            Console.WriteLine();
            while (i <= 20)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; // Par
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Impar
                }

                Console.WriteLine(i);
                i++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();


            //Ejercicio 2
            Console.WriteLine("Ejercicio 2");
            int numero;
            int d = 1;
            Console.Write("Ingrese un número entero positivo: ");
            numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Divisores de " + numero + ":");
            do
            {
                if (numero % d == 0)
                {
                    Console.WriteLine(d);
                }

                d++;

            } while (d <= numero);

            Console.ReadLine();


            //Ejercicio 3
            Console.WriteLine("Ejercicio 3");
            int n;
            int a = 0;
            int b = 1;
            int c;
            Console.Write("Ingrese la cantidad de números Fibonacci: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Serie de Fibonacci:");
            for (int e = 0; e < n; e++)
            {
                Console.Write(a + " ");

                c = a + b;
                a = b;
                b = c;
            }
            Console.ReadLine();


            //Ejercicio 4
            Console.WriteLine("Ejercicio 4");
            for (int t = 1; t <= 12; t++)
            {
                Console.WriteLine("Tabla del " + t);
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine(i + " x " + j + " = " + (t * j));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
