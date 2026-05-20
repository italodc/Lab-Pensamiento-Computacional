using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TipoCultivo
    {
        public int Codigo { get; }
        public string Nombre { get; }
        public int Meses { get; }
        public double Costo { get; }
        public double Ingreso { get; }

        public TipoCultivo(int codigo, string nombre, int meses,
                           double costo, double ingreso)
        {
            Codigo = codigo;
            Nombre = nombre;
            Meses = meses;
            Costo = costo;
            Ingreso = ingreso;
        }

        public override string ToString() =>
            $"  [{Codigo}] {Nombre,-12} | Meses: {Meses,2} | " +
            $"Costo: Q{Costo,8:F2} | Ingreso: Q{Ingreso,10:F2}";
    }
}
