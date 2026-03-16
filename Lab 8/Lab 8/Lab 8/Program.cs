using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            Console.WriteLine("\n Ejercicio 1");
            int mayor = int.MinValue;
            int menor = int.MaxValue;
            int suma = 0;
            for (int i = 1; i <= 20; i++)
            {
                Console.Write("Ingrese número " + i + ": ");
                int num = int.Parse(Console.ReadLine());

                if (num > mayor)
                    mayor = num;
                if (num < menor)
                    menor = num;
                suma += num;
            }

            double promedio = (double)suma / 20;
            Console.WriteLine("Número mayor: " + mayor);
            Console.WriteLine("Número menor: " + menor);
            Console.WriteLine("Promedio: " + promedio);


            // Ejercicio 2
            Console.WriteLine("\nEjercicio 2");

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0 && i % 7 == 0)
                    Console.WriteLine("ParSiete");
                else if (i % 2 == 0)
                    Console.WriteLine("Par");
                else if (i % 7 == 0)
                    Console.WriteLine("Siete");
                else
                    Console.WriteLine(i);
            }


            // Ejercicio 3
            Console.WriteLine("\nEJERCICIO 3");
            int clientesDescuento = 0;
            double totalVentas = 0;
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("Monto de compra del cliente " + i + ": ");
                double compra = double.Parse(Console.ReadLine());
                double descuento = 0;

                if (compra > 700)
                {
                    descuento = compra * 0.12;
                    clientesDescuento++;
                }
                else if (compra > 300)
                {
                    descuento = compra * 0.05;
                    clientesDescuento++;
                }
                double totalPagar = compra - descuento;
                Console.WriteLine("Total a pagar: " + totalPagar);
                totalVentas += totalPagar;
            }
            Console.WriteLine("Clientes con descuento: " + clientesDescuento);
            Console.WriteLine("Total de ventas del día: " + totalVentas);


            // Ejercicio 4
            Console.WriteLine("\nEJERCICIO 4");

            Console.Write("Ingrese un número entero: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Mostrar números hasta 1");
            Console.WriteLine("2. Múltiplos de 3");
            Console.WriteLine("3. Múltiplos de 5");
            Console.Write("Seleccione opción: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    for (int i = numero; i >= 1; i--)
                    {
                        Console.WriteLine(i);
                    }
                    break;

                case 2:
                    for (int i = 1; i <= numero; i++)
                    {
                        if (i % 3 == 0)
                            Console.WriteLine(i);
                    }
                    break;

                case 3:
                    for (int i = 1; i <= numero; i++)
                    {
                        if (i % 5 == 0)
                            Console.WriteLine(i);
                    }
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }


            // Ejercicio 5
            Console.WriteLine("\nEJERCICIO 5");
            Console.Write("Ingrese número de filas: ");
            int filas = int.Parse(Console.ReadLine());
            for (int i = 1; i <= filas; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
