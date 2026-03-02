using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("Ingrese la conversion");
            Console.WriteLine("Conversion 1: De Celsius a Fahrenheit");
            Console.WriteLine("Conversion 2: De Fahrenheit a Celsius");
            Console.WriteLine("Conversion 3: De Celsius a Kelvin");
            string caso = Console.ReadLine()?.Trim();
            Console.WriteLine("Ingrese la temperatura");
            if (caso != "1" && caso != "2" && caso != "3")
            {
                Console.WriteLine("Opcion no valida");
            }
            else
            {
                double temperatura = Convert.ToDouble(Console.ReadLine());
                switch (caso)
                {
                    case "1":
                        double fahrenheit = (temperatura * 9 / 5) + 32;
                        Console.WriteLine("La temperatura en Fahrenheit es: " + fahrenheit);
                        break;
                    case "2":
                        double celsius = (temperatura - 32) * 5 / 9;
                        Console.WriteLine("La temperatura en Celsius es: " + celsius);
                        break;
                    case "3":
                        double kelvin = temperatura + 273.15;
                        Console.WriteLine("La temperatura en Kelvin es: " + kelvin);
                        break;
                }
            }

            //Ejercicio 2
            Console.WriteLine();
            Console.WriteLine("Ejercicio 2");
            int tipoCliente, unidades;
            double descuento = 0;

            Console.WriteLine("TIPO DE CLIENTE");
            Console.WriteLine("1. Regular");
            Console.WriteLine("2. VIP");
            Console.Write("Seleccione tipo: ");
            tipoCliente = int.Parse(Console.ReadLine());

            Console.Write("Ingrese cantidad de unidades: ");
            unidades = int.Parse(Console.ReadLine());

            if (unidades > 100)
            {
                descuento = 0.15;
                Console.WriteLine("Cliente Mayorista");
            }
            else if (tipoCliente == 1)
            {
                descuento = 0.05;
                Console.WriteLine("Cliente Regular");
            }
            else if (tipoCliente == 2)
            {
                descuento = 0.10;
                Console.WriteLine("Cliente VIP");
            }
            else
            {
                Console.WriteLine("Tipo invalido");
                return;
            }
            Console.WriteLine("Descuento aplicado: " + (descuento * 100) + "%");

            //Ejercicio 3
            Console.WriteLine();
            Console.WriteLine("Ejercicio 3");
            int horas;
            double precioHora, total;
            Console.Write("Ingrese cantidad de horas: ");
            horas = int.Parse(Console.ReadLine());

            if (horas < 2)
            {
                precioHora = 5;
            }
            else if (horas <= 5)
            {
                precioHora = 4;
            }
            else
            {
                precioHora = 3;


                total = horas * precioHora;

                Console.WriteLine("Precio por hora: $" + precioHora);
                Console.WriteLine("Total a pagar: $" + total);
            }

            //Ejercicio 4
            Console.WriteLine();
            Console.WriteLine("Ejercicio 4");
            double puntuacion, dinero;
            string nivel;
            Console.Write("Ingrese su puntuacion: ");
            puntuacion = double.Parse(Console.ReadLine());
            if (puntuacion == 0.0)
            {
                nivel = "Inaceptable";
            }
            else if (puntuacion == 0.4)
            {
                nivel = "Aceptable";
            }
            else if (puntuacion >= 0.6)
            {
                nivel = "Meritorio";
            }
            else
            {
                Console.WriteLine("Puntuacion invalida");
                return;
            }

            dinero = 2400 * puntuacion;

            Console.WriteLine("Nivel: " + nivel);
            Console.WriteLine("Dinero recibido: " + dinero);
        }
    


    }
}


