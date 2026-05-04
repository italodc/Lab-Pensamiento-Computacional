using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            Console.WriteLine("Ejercicio 1");
            int[,] m1 = new int[5, 5];
            LlenarMatriz5x5(m1);
            int sumaPrincipal = SumaDiagonalPrincipal(m1);
            int sumaSecundaria = SumaDiagonalSecundaria(m1);
            Console.WriteLine("Suma diagonal principal: " + sumaPrincipal);
            Console.WriteLine("Suma diagonal secundaria: " + sumaSecundaria);


            // Ejercicio 2
            Console.WriteLine("\nEjercicio 2");
            int[,] m2 = new int[4, 6];
            LlenarMatriz4x6(m2);
            int pares = ContarPares(m2);
            int impares = ContarImpares(m2);
            Console.WriteLine("Cantidad de pares: " + pares);
            Console.WriteLine("Cantidad de impares: " + impares);


            //Ejercicio 3
            Console.WriteLine("\nEjercicio 3");
            float[,] notas = new float[5, 4];
            IngresarNotas(notas);
            for (int i = 0; i < 5; i++)
            {
                float prom = Promedio(notas, i);
                bool estado = Aprueba(prom);

                Console.WriteLine("Estudiante " + (i + 1) +
                                  " Promedio: " + prom +
                                  " Estado: " + (estado ? "Aprobado" : "Reprobado"));
            }


            // Ejercicio 4
            Console.WriteLine("\nEjercicio 4");
            int[,] m4 = new int[3, 3];
            LlenarMatriz3x3(m4);
            bool esSimetrica = EsSimetrica(m4);
            Console.WriteLine("La matriz es simétrica: " + esSimetrica);
        }

        // Ejercicio 1
        static void LlenarMatriz5x5(int[,] m)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"Ingrese elemento [{i},{j}]: ");
                    m[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static int SumaDiagonalPrincipal(int[,] m)
        {
            int suma = 0;
            for (int i = 0; i < 5; i++)
            {
                suma += m[i, i];
            }
            return suma;
        }

        static int SumaDiagonalSecundaria(int[,] m)
        {
            int suma = 0;
            for (int i = 0; i < 5; i++)
            {
                suma += m[i, 4 - i];
            }
            return suma;
        }


        //Ejercicio 2
        static void LlenarMatriz4x6(int[,] m)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($"Ingrese elemento [{i},{j}]: ");
                    m[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static int ContarPares(int[,] m)
        {
            int contador = 0;
            foreach (int num in m)
            {
                if (num % 2 == 0)
                    contador++;
            }
            return contador;
        }

        static int ContarImpares(int[,] m)
        {
            int contador = 0;
            foreach (int num in m)
            {
                if (num % 2 != 0)
                    contador++;
            }
            return contador;
        }


        //Ejercicio 3
        static void IngresarNotas(float[,] m)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Estudiante {i + 1}:");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Nota {j + 1}: ");
                    m[i, j] = float.Parse(Console.ReadLine());
                }
            }
        }

        static float Promedio(float[,] m, int estudiante)
        {
            float suma = 0;
            for (int j = 0; j < 4; j++)
            {
                suma += m[estudiante, j];
            }
            return suma / 4;
        }

        static bool Aprueba(float promedio)
        {
            return promedio >= 61;
        }


        //Ejercicio 4
        static void LlenarMatriz3x3(int[,] m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Ingrese elemento [{i},{j}]: ");
                    m[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static bool EsSimetrica(int[,] m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m[i, j] != m[j, i])
                        return false;
                }
            }
            return true;
        }
    }
}
