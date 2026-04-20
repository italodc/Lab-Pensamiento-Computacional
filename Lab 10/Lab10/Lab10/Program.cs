using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    internal class Program
    {

        // Ejercicio 1
        static int SumarDigitos(int numero)
        {
            int suma = 0;

            while (numero > 0)
            {
                suma += numero % 10;
                numero /= 10;
            }

            return suma;
        }

        // Ejercicio 2
        static string AjustarSaldo(ref double saldo, double retiro)
        {
            if (saldo >= retiro)
            {
                saldo -= retiro;
                return "Retiro exitoso. Saldo actual: " + saldo;
            }
            else
            {
                return "Fondos insuficientes. Saldo sin cambios: " + saldo;
            }
        }

        // Ejercicio 3
        static string ConvertirTemperatura(double celsius, ref double fahrenheit)
        {
            fahrenheit = (celsius * 9 / 5) + 32;
            return "Temperatura en Fahrenheit: " + fahrenheit;
        }

        // Ejercicio 4
        static int AgregarPuntos(ref int puntos)
        {
            puntos += 10;
            if (puntos > 100)
                puntos = 100;

            return puntos;
        }

        // 4.2 
        static int QuitarPuntos(ref int puntos)
        {
            puntos -= 7;
            if (puntos < 0)
                puntos = 0;

            return puntos;
        }

        // 4.3
        static string ObtenerNivel(int puntos)
        {
            if (puntos >= 80)
                return "Avanzado";
            else if (puntos >= 50)
                return "Intermedio";
            else
                return "Básico";
        }

        // 4.4 
        static string EvaluarEstado(int puntos)
        {
            if (puntos == 100)
                return "Excelente";
            else if (puntos >= 70)
                return "Aprobado";
            else
                return "Reprobado";
        }

        static void Main()
        {
            // Ejercicio 1 
            Console.WriteLine("Ejercicio 1");
            Console.Write("Ingrese un número: ");
            int num = int.Parse(Console.ReadLine());

            int suma = SumarDigitos(num);
            Console.WriteLine("Resultado: " + suma);

            // Ejercicio 2 
            Console.WriteLine("\nEjercicio 2");
            Console.Write("Ingrese saldo: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Ingrese monto de retiro: ");
            double retiro = double.Parse(Console.ReadLine());

            string resultadoSaldo = AjustarSaldo(ref saldo, retiro);
            Console.WriteLine(resultadoSaldo);

            // Ejercicio 3 
            Console.WriteLine("\nEjercicio 3");
            Console.Write("Ingrese temperatura en Celsius: ");
            double c = double.Parse(Console.ReadLine());

            double f = 0;
            string resultadoTemp = ConvertirTemperatura(c, ref f);
            Console.WriteLine(resultadoTemp);

            //Ejercicio 4 
            Console.WriteLine("\nEjercicio 4");
            Console.Write("Ingrese puntos iniciales: ");
            int puntos = int.Parse(Console.ReadLine());

            AgregarPuntos(ref puntos);
            Console.WriteLine("Después de agregar: " + puntos);

            QuitarPuntos(ref puntos);
            Console.WriteLine("Después de quitar: " + puntos);

            Console.WriteLine("Nivel: " + ObtenerNivel(puntos));
            Console.WriteLine("Estado: " + EvaluarEstado(puntos));
        }
    }
}