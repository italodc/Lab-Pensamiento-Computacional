using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CatalogoSiembras
    {
        public static readonly int TotalTipos = 5;

        private static readonly TipoCultivo[] _cultivos =
        {
            null,   //Tipos de semilla: van del 1 al 5
            new TipoCultivo(1, "Trigo",     1, 100.00,  130.00),
            new TipoCultivo(2, "Repollo",   2, 180.00,  280.00),
            new TipoCultivo(3, "Tomate",    3, 250.00,  450.00),
            new TipoCultivo(4, "Calabaza",  4, 220.00,  360.00),
            new TipoCultivo(5, "Espárrago", 6, 500.00, 1000.00),
        };

        //Devuelve el TipoCultivo dado el código (1-5). 
        public static TipoCultivo Obtener(int codigo)
        {
            if (codigo < 1 || codigo > TotalTipos)
                throw new ArgumentOutOfRangeException(nameof(codigo),
                    "Código de cultivo fuera de rango.");
            return _cultivos[codigo];
        }

        public static void MostrarCatalogo()
        {
            Console.WriteLine("  ┌─────┬────────────┬────────┬──────────────┬──────────────────┐");
            Console.WriteLine("  │  #  │ Cultivo    │ Meses  │ Costo Semilla│ Ingreso Cosecha  │");
            Console.WriteLine("  ├─────┼────────────┼────────┼──────────────┼──────────────────┤");
            for (int i = 1; i <= TotalTipos; i++)
            {
                TipoCultivo c = _cultivos[i];
                Console.WriteLine(
                    $"  │  {c.Codigo}  │ {c.Nombre,-10} │   {c.Meses,2}   │  Q{c.Costo,9:F2}  │  Q{c.Ingreso,13:F2}  │");
            }
            Console.WriteLine("  └─────┴────────────┴────────┴──────────────┴──────────────────┘");
        }
    }
}
