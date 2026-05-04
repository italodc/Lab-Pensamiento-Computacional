using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1: Persona
            Persona persona1 = new Persona();
            persona1.nombre = "Juan";
            persona1.edad = 20;
            persona1.altura = 1.75;
            persona1.estudiante = true;

            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("Nombre: " + persona1.nombre);
            Console.WriteLine("Edad: " + persona1.edad);
            Console.WriteLine("Altura: " + persona1.altura);
            Console.WriteLine("Estudiante: " + persona1.estudiante);

            // Ejercicio 2: Vehiculo
            Vehiculo v = new Vehiculo();
            v.marca = "Toyota";
            v.modelo = "Corolla";
            v.anio = 2020;
            v.color = "Rojo";
            v.placa = "P187FCW";

            Console.WriteLine("\nEjercicio 2");
            Console.WriteLine("Marca: " + v.marca);
            Console.WriteLine("Modelo: " + v.modelo);
            Console.WriteLine("Año: " + v.anio);
            Console.WriteLine("Color: " + v.color);
            Console.WriteLine("Placa: " + v.placa);

            // Ejercicio 3: Producto
            Producto p1 = new Producto();
            Producto p2 = new Producto();

            p1.nombre = "Laptop";
            p1.codigo = "LAP123";
            p1.precio = 999.99;
            p1.stock = 10;
            p1.disponible = true;
            p2.nombre = "Mouse";
            p2.codigo = "MOU456";
            p2.precio = 49.99;
            p2.stock = 50;
            p2.disponible = true;

            Console.WriteLine("\nEjercicio 3");
            Console.WriteLine("Nombre: " + p1.nombre);
            Console.WriteLine("Código: " + p1.codigo);
            Console.WriteLine("Precio: " + p1.precio);
            Console.WriteLine("Stock: " + p1.stock);
            Console.WriteLine("Disponible: " + p1.disponible);
            Console.WriteLine("\nNombre: " + p2.nombre);
            Console.WriteLine("Código: " + p2.codigo);
            Console.WriteLine("Precio: " + p2.precio);
            Console.WriteLine("Stock: " + p2.stock);
            Console.WriteLine("Disponible: " + p2.disponible);

            // Ejercicio 4: Mascota
            Mascota m = new Mascota();
            m.nombre = "Max";
            m.especie = "Perro";    
            m.edad = 5;
            m.peso = 20.5;
            m.vacunado = true;

            Console.WriteLine("\nEjercicio 4");
            Console.WriteLine("Nombre: " + m.nombre);
            Console.WriteLine("Especie: " + m.especie);
            Console.WriteLine("Edad: " + m.edad);
            Console.WriteLine("Peso: " + m.peso);
            Console.WriteLine("Vacunado: " + m.vacunado);
        }
    }
}
