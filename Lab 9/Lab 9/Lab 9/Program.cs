using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EJERCICIO 1
            Console.WriteLine("EJERCICIO 1");
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine();
            ContarCaracteres(palabra);


            // EJERCICIO 2
            Console.WriteLine("EJERCICIO 2");
            Console.Write("Ingrese valor de A: ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("Ingrese valor de B: ");
            int B = int.Parse(Console.ReadLine());

            Console.WriteLine("Antes:");
            Console.WriteLine("A = " + A);
            Console.WriteLine("B = " + B);

            Intercambiar(ref A, ref B);

            Console.WriteLine("Después:");
            Console.WriteLine("A = " + A);
            Console.WriteLine("B = " + B);


            // EJERCICIO 3
            Console.WriteLine("EJERCICIO 3");
            Console.Write("Ingrese precio del boleto: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Ingrese porcentaje de descuento (ej: 0.2): ");
            double descuento = double.Parse(Console.ReadLine());

            Console.WriteLine("Precio antes: " + precio);
            AplicarDescuento(descuento, ref precio);
            Console.WriteLine("Precio después: " + precio);


            // EJERCICIO 4
            Console.WriteLine("EJERCICIO 4");

            int puntosSalud = 10;

            mostrarSalud(puntosSalud);

            recibirDaño(ref puntosSalud);
            mostrarSalud(puntosSalud);

            curar(ref puntosSalud);
            mostrarSalud(puntosSalud);

            calificarDesempeño(puntosSalud);
        }

        // EJERCICIO 1
        static void ContarCaracteres(string texto)
        {
            Console.WriteLine("Cantidad de caracteres: " + texto.Length);
        }

        // EJERCICIO 2
        static void Intercambiar(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // EJERCICIO 3
        static void AplicarDescuento(double descuento, ref double precio)
        {
            precio = precio - (precio * descuento);
        }

        // EJERCICIO 4

        static void recibirDaño(ref int puntosSalud)
        {
            puntosSalud -= 5;
            if (puntosSalud < 0)
                puntosSalud = 0;
        }

        static void curar(ref int puntosSalud)
        {
            puntosSalud += 3;
            if (puntosSalud > 15)
                puntosSalud = 15;
        }

        static void mostrarSalud(int puntosSalud)
        {
            if (puntosSalud >= 11)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (puntosSalud >= 6)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Salud actual: " + puntosSalud);
            Console.ResetColor();
        }

        static void calificarDesempeño(int puntosSalud)
        {
            if (puntosSalud == 15)
                Console.WriteLine("Calificación: S");
            else if (puntosSalud >= 11)
                Console.WriteLine("Calificación: A");
            else if (puntosSalud >= 6)
                Console.WriteLine("Calificación: B");
            else
                Console.WriteLine("Calificación: C");
        }
    }
}
