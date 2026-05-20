using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Inventario
    {
        private readonly int[] _semillas = new int[CatalogoSiembras.TotalTipos + 1];

        //Agrega semillas al inventario.
        public void Agregar(int tipo, int cantidad)
        {
            ValidarTipo(tipo);
            _semillas[tipo] += cantidad;
        }

        // Consume 1 semilla del tipo indicado.
        // Lanza InvalidOperationException si no hay stock.
        public void Consumir(int tipo)
        {
            ValidarTipo(tipo);
            if (_semillas[tipo] <= 0)
                throw new InvalidOperationException(
                    $"Sin inventario de {CatalogoSiembras.Obtener(tipo).Nombre}.");
            _semillas[tipo]--;
        }

        //Cantidad disponible de un tipo.
        public int Disponible(int tipo)
        {
            ValidarTipo(tipo);
            return _semillas[tipo];
        }

        //Total de semillas en inventario (todos los tipos).
        public int TotalDisponible()
        {
            int total = 0;
            for (int i = 1; i <= CatalogoSiembras.TotalTipos; i++)
                total += _semillas[i];
            return total;
        }

        public void MostrarInventario()
        {
            Console.WriteLine("  Inventario actual:");
            for (int i = 1; i <= CatalogoSiembras.TotalTipos; i++)
            {
                TipoCultivo c = CatalogoSiembras.Obtener(i);
                Console.WriteLine($"    {i}. {c.Nombre,-12}: {_semillas[i]} unidad(es)");
            }
        }

        private static void ValidarTipo(int tipo)
        {
            if (tipo < 1 || tipo > CatalogoSiembras.TotalTipos)
                throw new ArgumentOutOfRangeException(nameof(tipo),
                    "Tipo de cultivo fuera de rango (1-5).");
        }
    }
}
