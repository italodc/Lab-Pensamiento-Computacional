using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dinero
    {
        public double Money { get; private set; }
        public double CapitalInicial { get; private set; }
        public double TotalIngresos { get; private set; } = 0;
        public double TotalMateriaPrima { get; private set; } = 0;
        public double TotalManoObra { get; private set; } = 0;

        public Dinero(double capitalInicial)
        {
            Money = capitalInicial;
            CapitalInicial = capitalInicial;
        }

        //Descuenta el dinero de la compra de semillas del dinero disponible.
        //Devuelve false si los fondos son insuficientes.
        public bool ComprarSemillas(double costoTotal)
        {
            if (Money < costoTotal) return false;
            Money -= costoTotal;
            TotalMateriaPrima += costoTotal;
            return true;
        }

        //Pago salarios mensuales. Devuelve el monto pagado.
        public double PagarSalarios(int numEmpleados, double sueldoMensual)
        {
            double pago = numEmpleados * sueldoMensual;
            Money -= pago;
            TotalManoObra += pago;
            return pago;
        }

        //Registra el ingreso de una cosecha.
        public void RegistrarCosecha(double ingreso)
        {
            Money += ingreso;
            TotalIngresos += ingreso;
        }

        //Calcula la utilidad estimada antes de comprar semillas.
        public double Utilidad(int numEmpleados, double sueldoMensual) =>
            Money - (numEmpleados * sueldoMensual);

        //Genera el reporte financiero final.
        public void GenerarReporte(double inventarioProceso, int mesesSimulados,
                                   int numEmpleados, double sueldoMensual)
        {
            double manoObra = numEmpleados * sueldoMensual * mesesSimulados;
            double utilidades = TotalIngresos + inventarioProceso
                                - manoObra - TotalMateriaPrima;

            Console.WriteLine();
            Console.WriteLine($"  Capital inicial       : Q {CapitalInicial:F2}");
            Console.WriteLine($"  Ingresos (cosechas)   : Q {TotalIngresos:F2}");
            Console.WriteLine($"  Inventario en proceso : Q {inventarioProceso:F2}");
            Console.WriteLine($"  Mano de obra          : Q {manoObra:F2}");
            Console.WriteLine($"  Materia prima         : Q {TotalMateriaPrima:F2}");
            Console.WriteLine("  ──────────────────────────────────────────────");
            Console.WriteLine($"  Utilidades finales    : Q {utilidades:F2}");
            Console.WriteLine($"  Dinero en caja        : Q {Money:F2}");
        }
    }
}