using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Simulacion
    {
        private Granja _granja;

        // ── Punto de entrada ─────────────────────────────────────────────
        public void Ejecutar()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MostrarBienvenida();
            _granja = ConfigurarGranja();
            CicloPrincipal();
            GenerarReporteFinal();
        }

        // ── Bienvenida ───────────────────────────────────────────────────
        private static void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║  BIENVENIDO A LAGRANJA DE TOTI  –  Proyecto 2 PC ║");
            Console.WriteLine("║      Universidad Rafael Landívar  |  2026        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        // ── Configuración Inicial ────────────────────────────────────
        private static Granja ConfigurarGranja()
        {
            Console.WriteLine("══ INICIA TU GRANJA! ══════════════════════════");
            double capital;
            while (true)
            {
                Console.Write("Capital inicial (Q): ");
                if (double.TryParse(Console.ReadLine(), out capital)
                    && capital > 0)
                {
                    break;
                }
                Console.WriteLine("  [!] Ingrese un valor válido mayor a cero.");
            }

            // ---------------------------------------------------

            int empleados;

            while (true)
            {
                Console.Write("Número de empleados: ");
                if (int.TryParse(Console.ReadLine(), out empleados)
                    && empleados >= 1)
                {
                    break;
                }
                Console.WriteLine("  [!] Ingrese un número válido.");
            }

            // ---------------------------------------------------

            double sueldo;

            while (true)
            {
                Console.Write("Sueldo mensual por empleado: ");
                if (double.TryParse(Console.ReadLine(), out sueldo)
                    && sueldo > 0)
                {
                    break;
                }
                Console.WriteLine("  [!] Ingrese un sueldo válido.");
            }

            // ---------------------------------------------------

            int meses;

            while (true)
            {
                Console.Write("Meses a simular: ");
                if (int.TryParse(Console.ReadLine(), out meses)
                    && meses >= 1)
                {
                    break;
                }
                Console.WriteLine("  [!] Ingrese un número válido.");
            }

            // ---------------------------------------------------

            int filas;

            while (true)
            {
                Console.Write("Filas de cuadrícula: ");
                if (int.TryParse(Console.ReadLine(), out filas)
                    && filas >= 1)
                {
                    break;
                }
                Console.WriteLine("  [!] Ingrese un número válido.");
            }

            // ---------------------------------------------------

            int columnas;
            while (true)
            {
                Console.Write("Columnas de cuadrícula: ");
                if (int.TryParse(Console.ReadLine(), out columnas)
                    && columnas >= 1)
                {
                    break;
                }
                Console.WriteLine("  [!] Ingrese un número válido.");
            }

            // ---------------------------------------------------

            var granja = new Granja(
                filas,
                columnas,
                empleados,
                sueldo,
                meses,
                capital);

            Console.WriteLine("\n[✓] Granja configurada. ¡Bienvenido a la Granja de TOTI!");

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
            return granja;
        }

        // ── Ciclo Principal ──────────────────────────────────────────────
        private void CicloPrincipal()
        {
            while (_granja.SimulacionActiva())
            {
                MostrarMenu();
                int opcion;
                while (true)
                {
                    Console.Write("Seleccione una opción: ");

                    if (int.TryParse(Console.ReadLine(), out opcion)
                        && opcion >= 1 && opcion <= 5)
                    {
                        break;
                    }

                    Console.WriteLine("  [!] Ingrese un entero entre 1 y 5.");
                }

                switch (opcion)
                {
                    case 1: OpComprarSemillas(); break;
                    case 2: OpSembrar(); break;
                    case 3: OpConsultarParcelas(); break;
                    case 4: OpAvanzarMes(); break;
                    case 5:
                        Console.WriteLine("\n  Saliendo de la simulación...");
                        return;
                }
            }
        }

        // ── Menú ─────────────────────────────────────────────────────────
        private void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine($"║  Caja: Q{_granja.Finanzas.Money,12:F2}" +
                              $"   Meses rest.: {_granja.MesesRestantes,3}          ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Comprar Semillas                             ║");
            Console.WriteLine("║  2. Sembrar                                      ║");
            Console.WriteLine("║  3. Consultar Parcelas                           ║");
            Console.WriteLine("║  4. Avanzar Mes                                  ║");
            Console.WriteLine("║  5. Salir / Reporte Final                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
        }

        // ── Comprar Semillas ─────────────────────────────────────────
        private void OpComprarSemillas()
        {
            Console.Clear();
            Console.WriteLine(
                "══ COMPRAR SEMILLAS ════════════════════════");

            double utilidad = _granja.Finanzas.Utilidad(
                                _granja.NumEmpleados, _granja.SueldoMensual);

            Console.WriteLine($"  Caja actual       : Q {_granja.Finanzas.Money:F2}");
            Console.WriteLine($"  Costos mensuales  : Q {_granja.NumEmpleados * _granja.SueldoMensual:F2}");
            Console.WriteLine($"  Utilidad estimada : Q {utilidad:F2}");
            Console.WriteLine();


            if (utilidad < 0)
            {
                Console.WriteLine(
                    "[!] Fondos insuficientes para cubrir salarios. No se puede comprar.");
                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadLine();
                return;
            }
            bool continuar = true;
            while (continuar)
            {
                CatalogoSiembras.MostrarCatalogo();
                Console.WriteLine();
                _granja.Inventario.MostrarInventario();
                Console.WriteLine();

                // Leer tipo de semillas
                int tipo;
                while (true)
                {
                    Console.Write("Tipo de semillas (1-5): ");
                    if (int.TryParse(Console.ReadLine(), out tipo)
                        && tipo >= 1 && tipo <= 5)
                    {
                        break;
                    }
                    Console.WriteLine(
                        "  [!] Ingrese un número entre 1 y 5.");
                }

                // Leer cantidad de semillas
                int cantidad;
                while (true)
                {
                    Console.Write("Cantidad de semillas: ");
                    if (int.TryParse(Console.ReadLine(), out cantidad)
                        && cantidad >= 1)
                    {
                        break;
                    }
                    Console.WriteLine(
                        "  [!] Ingrese una cantidad válida.");
                }

                // Comprar semillas
                if (_granja.ComprarSemillas(tipo, cantidad, out string msg))
                {
                    Console.WriteLine($"[✓] {msg}");
                }
                else
                {
                    Console.WriteLine($"[!] {msg}");
                }

                Console.WriteLine(
                    $"  Caja actual: Q {_granja.Finanzas.Money:F2}");

                // Preguntar si continúa
                Console.Write("\n¿Comprar más semillas? (s/n): ");
                string respuesta =
                    Console.ReadLine()?.Trim().ToLower() ?? "";

                continuar =
                    respuesta == "s" ||
                    respuesta == "si" ||
                    respuesta == "sí";
            }

            // Confirmación de continuidad
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        // ── Sembrar ──────────────────────────────────────────────────
        private void OpSembrar()
        {
            // Título
            Console.Clear();
            Console.WriteLine(
                "══ SEMBRAR ═════════════════════════════");

            // Mostrar mapa
            char[,] mapa = _granja.GenerarMapa();
            Console.WriteLine(
                "\nMapa (- libre | inicial del cultivo = ocupada)\n");
            Console.Write("     ");
            for (int j = 0; j < _granja.Columnas; j++)
            {
                Console.Write($" {j,3}");
            }

            Console.WriteLine();
            for (int i = 0; i < _granja.Filas; i++)
            {
                Console.Write($"[{i}] ");
                for (int j = 0; j < _granja.Columnas; j++)
                {
                    Console.Write($"   {mapa[i, j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // Validar inventario
            if (_granja.Inventario.TotalDisponible() == 0)
            {
                Console.WriteLine(
                    "[!] Sin semillas en inventario. Compra primero.");
                Console.WriteLine(
                    "\nPresione ENTER para continuar...");
                Console.ReadLine();
                return;
            }

            // Mostrar inventario
            _granja.Inventario.MostrarInventario();

            // Leer tipo de siembra
            int tipo;
            while (true)
            {
                Console.Write("\nTipo de siembra (1-5): ");
                if (int.TryParse(Console.ReadLine(), out tipo)
                    && tipo >= 1 && tipo <= 5)
                {
                    break;
                }
                Console.WriteLine(
                    "[!] Ingrese un número válido.");
            }

            // Validar disponibilidad
            if (_granja.Inventario.Disponible(tipo) == 0)
            {
                Console.WriteLine(
                    $"[!] Sin inventario de {CatalogoSiembras.Obtener(tipo).Nombre}.");
                Console.WriteLine(
                    "\nPresione ENTER para continuar...");
                Console.ReadLine();
                return;
            }

            // Leer fila
            int fila;
            while (true)
            {
                Console.Write(
                    $"Fila (0-{_granja.Filas - 1}): ");
                if (int.TryParse(Console.ReadLine(), out fila)
                    && fila >= 0
                    && fila < _granja.Filas)
                {
                    break;
                }
                Console.WriteLine(
                    "[!] Fila inválida.");
            }

            // Leer columna
            int col;
            while (true)
            {
                Console.Write(
                    $"Columna (0-{_granja.Columnas - 1}): ");
                if (int.TryParse(Console.ReadLine(), out col)
                    && col >= 0
                    && col < _granja.Columnas)
                {
                    break;
                }
                Console.WriteLine(
                    "[!] Columna inválida.");
            }

            // Sembrar
            if (_granja.Sembrar(fila, col, tipo, out string msg))
            {
                Console.WriteLine($"[✓] {msg}");
            }
            else
            {
                Console.WriteLine($"[!] {msg}");
            }

            // Continuar
            Console.WriteLine(
                "\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        // ── Consultar Parcelas ───────────────────────────────────────

        private void OpConsultarParcelas()
        {
            Console.Clear();
            Console.WriteLine(
                "══ CONSULTAR PARCELAS ═══════════════════");

            char[,] mapa = _granja.GenerarMapa();
            Console.WriteLine(
                "\nMapa (- libre | inicial del cultivo = ocupada)\n");

            for (int i = 0; i < _granja.Filas; i++)
            {
                Console.Write($"[{i}] ");
                for (int j = 0; j < _granja.Columnas; j++)
                {
                    Console.Write($"   {mapa[i, j]}");
                }
                Console.WriteLine();
            }

            int fila;
            while (true)
            {
                Console.Write(
                    $"Fila a consultar (0-{_granja.Filas - 1}): ");
                if (int.TryParse(Console.ReadLine(), out fila)
                    && fila >= 0
                    && fila < _granja.Filas)
                {
                    break;
                }
                Console.WriteLine("[!] Fila inválida.");
            }

            int col;
            while (true)
            {
                Console.Write(
                    $"Columna a consultar (0-{_granja.Columnas - 1}): ");
                if (int.TryParse(Console.ReadLine(), out col)
                    && col >= 0
                    && col < _granja.Columnas)
                {
                    break;
                }
                Console.WriteLine("[!] Columna inválida.");
            }

            Console.WriteLine($"\nParcela [{fila},{col}]:");
            Console.WriteLine(
                _granja.ObtenerParcela(fila, col).ToString());
            Console.WriteLine(
                "\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        // ── Avanzar Mes ──────────────────────────────────────────────

        private void OpAvanzarMes()
        {
            Console.Clear();
            Console.WriteLine(
                "══ AVANZAR MES ══════════════════════════");

            bool continuar =
                _granja.AvanzarMes(out string resumen);
            Console.WriteLine(resumen);
            Console.WriteLine(
                "\nPresione ENTER para continuar...");
            Console.ReadLine();
            if (!continuar)
            {
                GenerarReporteFinal();
                Environment.Exit(0);
            }
        }

        // ── P6: Reporte Final ─────────────────────────────────────────────
        private void GenerarReporteFinal()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║                   REPORTE FINAL                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");

            int mesesSimulados = _granja.TotalMeses - _granja.MesesRestantes;
            double inventarioProceso = _granja.CalcularInventarioProceso();

            _granja.Finanzas.GenerarReporte(
                inventarioProceso, mesesSimulados,
                _granja.NumEmpleados, _granja.SueldoMensual);

            Console.WriteLine($"\n  Meses simulados: {mesesSimulados} de {_granja.TotalMeses}");
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║      TERMINO LA TEMPORADA DE SIEMBRA!!!!!!       ║");
            Console.WriteLine("║                   𝙼𝚊𝚍𝚎 𝚋𝚢 𝚃𝚘𝚝𝚒                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
        }
    }
}
