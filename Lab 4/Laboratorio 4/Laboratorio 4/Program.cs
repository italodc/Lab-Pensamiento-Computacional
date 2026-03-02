using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            string nombre="Apollo";
            int nivel=1;
            double vida=99.9;
            bool esEnemigo=false;
            Console.WriteLine("Nombre "+nombre +" Nivel " +nivel + " Vida "+ vida + " Boss " +esEnemigo);
           
            //Ejercicio 2
            int numeroEntero=1500;
            long numeroLargo=numeroEntero;
            double numeroDecimal=Convert.ToDouble(numeroLargo);
            Console.WriteLine(numeroDecimal);

            //Ejercicio 3
            double precioExacto=45.89;
            int precioRedondeado=Convert.ToInt32(precioExacto);
            Console.WriteLine(precioRedondeado);

            //Ejercicio 4
            Console.WriteLine("Ingrese un numero entero");
            string numeroString=Console.ReadLine();
            int numeroParseado=int.Parse(numeroString);
            int numeroMultiplicado=numeroParseado+5;
            Console.WriteLine("El numero mas 5 es "+ numeroMultiplicado);

            //Ejercicio 5
            string valorBooleano="true";
            bool booleanoConvertido=Convert.ToBoolean(valorBooleano);
            string valorDecimal="25.5";
            double decimalConvertido=Convert.ToDouble(valorDecimal);
            Console.WriteLine("Valor booleano convertido: " + booleanoConvertido);
            Console.WriteLine("Valor decimal convertido: " + decimalConvertido);

            //Ejercicio 6
            double pi = 3.14159265;
            string piTexto = pi.ToString();
            string piDosDecimales = pi.ToString("F2");
            Console.WriteLine("PI completo: " + piTexto);
            Console.WriteLine("PI con dos decimales: " + piDosDecimales);

            //Ejercicio 7
            Console.Write("Ingresa el precio del producto: ");
            string precioTexto = Console.ReadLine();
            double precio = Convert.ToDouble(precioTexto);
            double iva = precio * 0.21;
            double total = precio + iva;
            int totalSinDecimales = (int)total;
            Console.WriteLine("El total a pagar es: " + totalSinDecimales);

        }
    }
}


