using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capital = 1000;
            double tasa = 0.05;
            double intereses = 0;
            double abonos = 0;

            for (int mes = 1; mes <= 12 && capital > 0; mes++)
            {
                // Cálculo de intereses del mes
                intereses = capital * tasa;

                // Abono realizado cada mes
                abonos = 100 + (mes * 10);

                // Actualización del capital
                capital = capital + intereses - abonos;
            }
        }
    }
}
