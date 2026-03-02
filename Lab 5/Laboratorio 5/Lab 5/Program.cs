using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            Console.Write("Ingrese un número entero: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero > 0)
            {
                Console.WriteLine("El número es POSITIVO");
            }
            else if (numero < 0)
            {
                Console.WriteLine("El número es NEGATIVO");
            }
            else
            {
                Console.WriteLine("El número es CERO");
            }


            //Ejercicio 2
            Console.Write("Ingrese un año: ");
            int año = int.Parse(Console.ReadLine());

            if (año % 400 == 0)
            {
                Console.WriteLine("Es un año BISIESTO");
            }
            else if (año % 4 == 0 && año % 100 != 0)
            {
                Console.WriteLine("Es un año BISIESTO");
            }
            else
            {
                Console.WriteLine("NO es un año bisiesto");
            }


            //Ejercicio 3
            double ingreso;
            bool multa;
            double Ornato = 0;

            Console.Write("Ingrese su ingreso mensual: ");
            ingreso = double.Parse(Console.ReadLine());

            Console.Write("¿Tiene multa? (true/false): ");
            multa = bool.Parse(Console.ReadLine());

            if (ingreso >= 500 && ingreso <= 1000)
                Ornato = multa ? 20 : 10;
            else if (ingreso <= 3000)
                Ornato = multa ? 30 : 15;
            else if (ingreso <= 6000)
                Ornato = multa ? 100 : 50;
            else if (ingreso <= 9000)
                Ornato = multa ? 150 : 75;
            else if (ingreso <= 12000)
                Ornato = multa ? 200 : 100;
            else
                Ornato = multa ? 300 : 150;

            Console.WriteLine("El pago de ornato es: Q" + Ornato);


            //Ejercicio 4
            Console.Write("Ingrese horas estacionado: ");
            int horas = int.Parse(Console.ReadLine());

            int total = horas * 10;

            Console.WriteLine("Total a pagar: Q" + total);

            Console.Write("Ingrese monto de pago: ");
            int pago = int.Parse(Console.ReadLine());

            if (pago < total)
            {
                Console.WriteLine("Error: Pago insuficiente");
                return;
            }
            else if (pago == total)
            {
                Console.WriteLine("Pago exacto. No hay vuelto.");
                return;
            }

            int vuelto = pago - total;
            Console.WriteLine("Vuelto: Q" + vuelto);

            int b100 = vuelto / 100;
            vuelto %= 100;

            int b50 = vuelto / 50;
            vuelto %= 50;

            int b20 = vuelto / 20;
            vuelto %= 20;

            int b10 = vuelto / 10;
            vuelto %= 10;

            int b5 = vuelto / 5;
            vuelto %= 5;

            int b1 = vuelto;

            Console.WriteLine("Billetes a entregar:");
            Console.WriteLine("Q100: " + b100);
            Console.WriteLine("Q50: " + b50);
            Console.WriteLine("Q20: " + b20);
            Console.WriteLine("Q10: " + b10);
            Console.WriteLine("Q5: " + b5);
            Console.WriteLine("Q1: " + b1);
        }
    }
}
