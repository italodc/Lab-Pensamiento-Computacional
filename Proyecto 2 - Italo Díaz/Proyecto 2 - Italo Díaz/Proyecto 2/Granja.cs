using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Granja
    {
        public int Filas { get; }
        public int Columnas { get; }
        public int NumEmpleados { get; }
        public double SueldoMensual { get; }
        public int TotalMeses { get; }
        public int MesesRestantes { get; private set; }
        public Dinero Finanzas { get; }
        public Inventario Inventario { get; }

        private readonly Parcela[,] _parcelas;

        public Granja(int filas, int columnas, int numEmpleados, double sueldo,
                      int meses, double capitalInicial)
        {
            Filas = filas;
            Columnas = columnas;
            NumEmpleados = numEmpleados;
            SueldoMensual = sueldo;
            TotalMeses = meses;
            MesesRestantes = meses;
            Finanzas = new Dinero(capitalInicial);
            Inventario = new Inventario();

            _parcelas = new Parcela[filas, columnas];
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                    _parcelas[i, j] = new Parcela();
        }

        // ── Acceso a parcelas ────────────────────────────────────────────
        public Parcela ObtenerParcela(int fila, int col) => _parcelas[fila, col];

        // ── Operación: Comprar Semillas ──────────────────────────────────
        public bool ComprarSemillas(int tipo, int cantidad, out string mensaje)
        {
            TipoCultivo cultivo = CatalogoSiembras.Obtener(tipo);
            double costoTotal = cantidad * cultivo.Costo;

            if (!Finanzas.ComprarSemillas(costoTotal))
            {
                mensaje = $"Fondos insuficientes. Se necesitan Q{costoTotal:F2} " +
                          $"pero solo hay Q{Finanzas.Money:F2}.";
                return false;
            }

            Inventario.Agregar(tipo, cantidad);
            mensaje = $"Compra exitosa: {cantidad} semilla(s) de {cultivo.Nombre} " +
                      $"por Q{costoTotal:F2}.";
            return true;
        }

        // ── Operación: Sembrar ───────────────────────────────────────────
        public bool Sembrar(int fila, int col, int tipo, out string mensaje)
        {
            Parcela p = _parcelas[fila, col];

            if (p.EstaOcupada)
            {
                mensaje = $"La parcela [{fila},{col}] ya está ocupada.";
                return false;
            }

            if (Inventario.Disponible(tipo) <= 0)
            {
                mensaje = $"Sin inventario de {CatalogoSiembras.Obtener(tipo).Nombre}.";
                return false;
            }

            Inventario.Consumir(tipo);
            p.Sembrar(CatalogoSiembras.Obtener(tipo));
            mensaje = $"{p.NombreSiembra} sembrado en [{fila},{col}]. " +
                      $"Cosecha en {p.MesesCrecimiento} mes(es). " +
                      $"Ingreso esperado: Q{p.IngresosCosecha:F2}";
            return true;
        }

        // ── Operación: Avanzar Mes ───────────────────────────────────────
        // Procesa un mes: paga salarios, hace crecer cultivos y cosecha.
        // Devuelve false si la simulación debe terminar (sin dinero o sin meses).
        public bool AvanzarMes(out string resumen)
        {
            int mesActual = TotalMeses - MesesRestantes + 1;
            var sb = new System.Text.StringBuilder();

            sb.AppendLine($"  ─ Mes {mesActual} de {TotalMeses} ─");

            // Pagar salarios
            double pago = Finanzas.PagarSalarios(NumEmpleados, SueldoMensual);
            sb.AppendLine($"  [Salarios] -Q{pago:F2}  " +
                          $"({NumEmpleados} emp. × Q{SueldoMensual:F2})");
            sb.AppendLine($"  Caja tras salarios: Q{Finanzas.Money:F2}");

            if (Finanzas.Money <= 0)
            {
                sb.AppendLine("\n  [!] ¡Fondos agotados! Fin de la simulación.");
                resumen = sb.ToString();
                return false;
            }

            // Crecer y cosechar parcelas
            int cosechas = 0;
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    Parcela p = _parcelas[i, j];
                    if (!p.EstaOcupada) continue;

                    string nombre = p.NombreSiembra;
                    double ingreso = p.IngresosCosecha;
                    if (p.AvanzarMes())
                    {
                        Finanzas.RegistrarCosecha(ingreso);
                        cosechas++;
                        sb.AppendLine($"  [Cosecha] [{i},{j}] {nombre}: +Q{ingreso:F2}");
                    }
                }
            }

            if (cosechas == 0) sb.AppendLine("  (Sin cosechas este mes)");
            MesesRestantes--;
            sb.AppendLine($"\n  Caja final del mes : Q{Finanzas.Money:F2}");
            sb.AppendLine($"  Meses restantes    : {MesesRestantes}");
            resumen = sb.ToString();
            return MesesRestantes > 0;
        }

        // ── Inventario  ─────────────────────────────────────────────
        public double CalcularInventarioProceso()
        {
            double total = 0;
            for (int i = 0; i < Filas; i++)
                for (int j = 0; j < Columnas; j++)
                    if (_parcelas[i, j].EstaOcupada)
                        total += _parcelas[i, j].IngresosCosecha;
            return total;
        }

        // ── Mapa visual (Dibujito) ──────────────────────────────────────────────────
        public char[,] GenerarMapa()
        {
            char[,] mapa = new char[Filas, Columnas];
            for (int i = 0; i < Filas; i++)
                for (int j = 0; j < Columnas; j++)
                    mapa[i, j] = _parcelas[i, j].SimboloMapa();
            return mapa;
        }

        // ── Estado activo ────────────────────────────────────────────────
        public bool SimulacionActiva() =>
            MesesRestantes > 0 && Finanzas.Money > 0;
    }

    //  Entrada/salida de consola, validaciones
    static class Validaciones
    {
        // ── Lectura con validación ───────────────────────────────────────
        public static int LeerEntero(string mensaje, int min, int max)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int v) && v >= min && v <= max)
                    return v;
                Console.WriteLine($"  [!] Ingrese un entero entre {min} y {max}.");
            }
        }

        public static double LeerDouble(string mensaje, bool mayorQueCero = true)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine() ?? "";
                bool ok = double.TryParse(entrada,
                              System.Globalization.NumberStyles.Any,
                              System.Globalization.CultureInfo.InvariantCulture,
                              out double v);
                if (ok && (!mayorQueCero || v > 0)) return v;
                Console.WriteLine(mayorQueCero
                    ? "  [!] El valor debe ser mayor a cero (use punto decimal, ej: 1500.00)."
                    : "  [!] Ingrese un número válido.");
            }
        }

        public static bool LeerSiNo(string mensaje)
        {
            Console.Write(mensaje);
            string r = Console.ReadLine()?.Trim().ToLower() ?? "";
            return r == "s" || r == "si" || r == "sí";
        }

        // ── Mapa de parcelas ─────────────────────────────────────────────
        public static void MostrarMapa(Granja granja)
        {
            char[,] mapa = granja.GenerarMapa();
            Console.WriteLine("\n  Mapa  (- libre  |  inicial del cultivo = ocupada)\n");

            Console.Write("       ");
            for (int j = 0; j < granja.Columnas; j++)
                Console.Write($" {j,3}");
            Console.WriteLine();

            Console.Write("       ");
            for (int j = 0; j < granja.Columnas; j++)
                Console.Write(" ───");
            Console.WriteLine();

            for (int i = 0; i < granja.Filas; i++)
            {
                Console.Write($"  [{i,2}] ");
                for (int j = 0; j < granja.Columnas; j++)
                    Console.Write($"   {mapa[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // ── Utilidades de pantalla ───────────────────────────────────────
        public static void Titulo(string texto)
        {
            Console.Clear();
            Console.WriteLine($"══ {texto} {new string('═', Math.Max(0, 48 - texto.Length))}");
        }

        public static void Pausa()
        {
            Console.Write("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        public static void Ok(string msg) => Console.WriteLine($"  [✓] {msg}");
        public static void Error(string msg) => Console.WriteLine($"  [!] {msg}");
    }
}
