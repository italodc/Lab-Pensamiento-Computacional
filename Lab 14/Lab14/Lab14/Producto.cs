using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class Producto
    {
        public string Nombre;
        public decimal Precio;
        public int Cantidad;

        // Constructor
        public Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // Mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine("Producto: " + Nombre);
            Console.WriteLine("Precio: Q" + Precio);
            Console.WriteLine("Cantidad: " + Cantidad);
            Console.WriteLine();
        }

        // Vender producto
        public void Vender(int cantidadVendida)
        {
            Console.WriteLine("Cantidad antes de la venta: " + Cantidad);

            if (Cantidad >= cantidadVendida)
            {
                Cantidad -= cantidadVendida;
                Console.WriteLine("Se vendieron " + cantidadVendida + " unidades.");
            }
            else
            {
                Console.WriteLine("No hay suficiente stock.");
            }

            Console.WriteLine("Cantidad después de la venta: " + Cantidad);
            Console.WriteLine();
        }

        // Reabastecer
        public void Reabastecer(int cantidadNueva)
        {
            Console.WriteLine("Cantidad antes del reabastecimiento: " + Cantidad);

            Cantidad += cantidadNueva;

            Console.WriteLine("Se agregaron " + cantidadNueva + " unidades.");
            Console.WriteLine("Cantidad después del reabastecimiento: " + Cantidad);
            Console.WriteLine();

        }
    }
}