using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            Console.WriteLine("Ejercicio 1");
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();
            bool esPalindromo = true;
            int longitud = palabra.Length;
            for (int i = 0; i < longitud / 2; i++)
            {
                if (palabra[i] != palabra[longitud - 1 - i])
                {
                    esPalindromo = false;
                    break;
                }
            }

            if (esPalindromo)
            {
                Console.WriteLine("Es un palíndromo.");
            }
            else
            {
                Console.WriteLine("No es un palíndromo.");
            }

            // Ejercicio 2
            Console.WriteLine("\nEjercicio 2");
            string[] espanol = { "rojo", "azul", "amarillo", "blanco", "verde" };
            string[] ingles = { "red", "blue", "yellow", "white", "green" };
            string[] italiano = { "rosso", "blu", "giallo", "bianco", "verde" };
            int opcion;
            do
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Practicar lección");
                Console.WriteLine("2. Terminar lección");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.Write("Ingrese una palabra en español: ");
                    string entrada = Console.ReadLine().ToLower();
                    bool encontrada = false;
                    for (int i = 0; i < espanol.Length; i++)
                    {
                        if (entrada == espanol[i])
                        {
                            string esp = char.ToUpper(espanol[i][0]) + espanol[i].Substring(1);
                            string ing = char.ToUpper(ingles[i][0]) + ingles[i].Substring(1);
                            string ita = char.ToUpper(italiano[i][0]) + italiano[i].Substring(1);

                            Console.WriteLine($"{esp}, {ing}, {ita}");
                            encontrada = true;
                            break;
                        }
                    }

                    if (!encontrada)
                    {
                        Console.WriteLine("La palabra no corresponde a la lección actual");
                    }
                }

            } while (opcion != 2);
            Console.WriteLine("Lección finalizada.");



            // Ejercicio 3
            Console.WriteLine("\nEjercicio 3");
            Random rnd = new Random();
            int[] notas = new int[10];

            for (int i = 0; i < notas.Length; i++) {
                notas[i] = rnd.Next(50, 101);}

            int option;
            do
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Reporte de rendimiento");
                Console.WriteLine("2. Estadísticas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Opción inválida.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nCalificaciones:\n");

                        for (int i = 0; i < notas.Length; i++)
                        {
                            if (notas[i] >= 50 && notas[i] <= 64)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else if (notas[i] >= 65 && notas[i] <= 79)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else
                                Console.ForegroundColor = ConsoleColor.Green;

                            Console.Write(notas[i] + " ");
                        }

                        Console.ResetColor();
                        Console.WriteLine();
                        break;

                case 2:
                 int suma = 0;
                 int max = notas[0];
                 int min = notas[0];

                for (int i = 0; i < notas.Length; i++){
                    suma += notas[i];

                    if (notas[i] > max)
                     max = notas[i];

                    if (notas[i] < min)
                     min = notas[i];
                        }

                        double promedio = (double)suma / notas.Length;

                Console.WriteLine($"\nPromedio: {promedio:F2}");
                Console.WriteLine($"Calificación más alta: {max}");
                Console.WriteLine($"Calificación más baja: {min}");
                break;

                case 3:
                Console.WriteLine("Programa finalizado.");
                break;

                default:
                Console.WriteLine("Opción no válida.");
                break;
                }

            } while (option != 3);


            //Ejercicio 4
            Console.WriteLine("\nEjercicio 4");
            string[] nombres = { "Ana", "Mario", "Saúl", "Karla", "María", "José" };
            double[] salarioHora = { 100, 125.50, 98.65, 125, 132.50, 102.50 };
            double[] horas = new double[6];

            for (int p = 0; p < nombres.Length; p++) {
             Console.Write($"Ingrese horas trabajadas de {nombres[p]}: ");
             horas[p] = double.Parse(Console.ReadLine());}
            Console.WriteLine("\n PAGOS SEMANALES ");

            for (int p = 0; p < nombres.Length; p++) {
            double pago;
            if (horas[p] > 40) {
            double horasExtra = horas[p] - 40;
            pago = (40 * salarioHora[p]) + (horasExtra * salarioHora[p] * 1.5);}
            else {
            pago = horas[p] * salarioHora[p ];}
            Console.WriteLine($"{nombres[p]}: Q{pago:F2}");
            }
        }
    }
}