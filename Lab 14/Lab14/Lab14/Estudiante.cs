using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class Estudiante
    {
        public string Nombre;
        public int Edad;
        public string Grado;
        public List<decimal> Notas;

        // Constructor
        public Estudiante(string nombre, int edad, string grado, List<decimal> notas)
        {
            Nombre = nombre;
            Edad = edad;
            Grado = grado;
            Notas = notas;
        }

        // Calcular promedio
        public decimal CalcularPromedio()
        {
            decimal suma = 0;

            foreach (decimal nota in Notas)
            {
                suma += nota;
            }

            return suma / Notas.Count;
        }

        // Mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Grado: " + Grado);

            Console.Write("Notas: ");
            foreach (decimal nota in Notas)
            {
                Console.Write(nota + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Promedio: " + CalcularPromedio());
            Console.WriteLine();
        }

        // Verificar aprobación
        public void Aprobar()
        {
            if (CalcularPromedio() >= 61)
            {
                Console.WriteLine(Nombre + " aprobó.");
            }
            else
            {
                Console.WriteLine(Nombre + " reprobó.");
            }

            Console.WriteLine();
        }

        // Agregar nota
        public void AgregarNota(decimal nuevaNota)
        {
            Notas.Add(nuevaNota);

            Console.WriteLine("Se agregó la nota: " + nuevaNota);
            Console.WriteLine("Nuevo promedio: " + CalcularPromedio());
            Console.WriteLine();
        }
    }
}
