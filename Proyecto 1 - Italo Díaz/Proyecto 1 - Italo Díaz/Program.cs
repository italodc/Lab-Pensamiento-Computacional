using System;
using System.ComponentModel.Design;
using System.Reflection.Emit;

class Program
{
    static void Main()
    {
        // --- registro menu del trabajador ---
        string nombre, codigoTurno; //variables de nombre del trabajador y codigo de turno de estes
        int capacidad; //capacidad de parqueo
        Console.WriteLine("************Menu inicial del trabajador de turno************");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Ingrese su nombre: ");
        nombre = Console.ReadLine();
        do // ciclo de limite de 4 digitos de codigo
        {
            Console.Write("Ingrese su codigo de turno de 4 digitos: ");
            codigoTurno = Console.ReadLine();
        } while (codigoTurno.Length != 4 );
        do
        {
            Console.Write("Ingrese la capacidad total del parqueo (mínimo 10): ");
            capacidad = Convert.ToInt32(Console.ReadLine());

            if (capacidad < 10) //codigo de capacidad debe de ser minimo 10
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Error: La capacidad debe ser de al menos 10 espacios.");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        } while (capacidad < 10); 
        Console.ResetColor();

        // Variables globales del sistema
        int ticketscreados = 0;
        int ticketscerrados = 0;
        double dineroRecaudado = 0;
        int tiemposim = 0;
        bool continuar = true;
        // variables de vehiculo y tickets en circulacion
        string placaActiva = "", clienteActivo = "";
        string nombreVehiculoActivo = "" ;
        bool TicketActivo = false;

        while (continuar) // ciclo del menu para repetir despues de seleccionar una opcion hasta decidir finalizar
        {
            string opciones;
            Console.WriteLine("--- Menu de opciones ---"); //menu de opciones en el parqueo
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("A. CREAR TICKET ENTRADA | B. COBRO | C. ESTADO | D. SIMULAR TIEMPO | F. SALIR");
            Console.ResetColor();
            opciones = Console.ReadLine().ToUpper();
            switch (opciones)
            {
                case "A": // crear un ticket de entrada si se presiona a o A
                    {
                        int vehiculosActuales = ticketscreados - ticketscerrados;
                        if (TicketActivo) // si ticket activo es positivo
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ERROR: Ya hay un ticket en curso. Realice el cobro primero.");
                            Console.ResetColor();
                        }
                        else if (vehiculosActuales >= capacidad) // si hay mas vehiculos que capacidad de parqueo
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: El parqueo está lleno (Capacidad: " + capacidad + ").");
                            Console.ResetColor();
                        }
                        else // si no pasa ninguna de las anteriores
                        {
                            do {
                                Console.WriteLine("ingrese la placa de su vehiculo");
                                placaActiva = Console.ReadLine();
                            }while (placaActiva.Length  > 8 ); //ciclo para que sea menor que 8 digitos
                            Console.WriteLine("Elija tipo de vehiculo: 1. Moto, 2. Auto, 3. Pickup/SUV");
                            int V = Convert.ToInt32(Console.ReadLine());
                            string nombreVehiculo = "";
                            switch (V) //ciclo de escoger vehiculo
                            {
                                case 1: nombreVehiculo = "Moto"; break;
                                case 2: nombreVehiculo = "Auto"; break;
                                case 3: nombreVehiculo = "Pickup/SUV"; break;
                                default: nombreVehiculo = "Desconocido"; break;
                            }

                            if (nombreVehiculo != "Desconocido") // caso de seleccionar un numero valido
                            {
                                Console.Write("Ingrese el nombre del cliente: ");
                                clienteActivo = Console.ReadLine();

                                ticketscreados++;
                                TicketActivo = true;
                                nombreVehiculoActivo = nombreVehiculo;

                                Console.ForegroundColor= ConsoleColor.Green;
                                Console.WriteLine("Ticket creado con exito!!");
                                Console.WriteLine("nombre del cliente: "+ clienteActivo);
                                Console.WriteLine("ticket numero: "+ ticketscreados);
                                Console.WriteLine("nombre del vehiculo" +nombreVehiculoActivo);
                                Console.ResetColor();
                            }
                            else //caso de ingresar 4 u cualquier otro digito que no sea de las opciones
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine("Error: Tipo de vehículo no válido.");
                                Console.ResetColor();
                            }
                         

                        }
                        break;
                    }

                case "B": // cobro de ticket
                    {
                        if (TicketActivo == false) // si no se ha creado un ticket
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ERROR: No hay ningún vehículo en el parqueo.");
                            Console.ResetColor ();
                        }
                        else // si si se creo un ticket previamente
                        {
                            double tarifaPorHora = 0;
                            if (nombreVehiculoActivo == "Moto") tarifaPorHora = 5.0;
                            else if (nombreVehiculoActivo == "Auto") tarifaPorHora = 10.0;
                            else if (nombreVehiculoActivo == "Pickup/SUV") tarifaPorHora = 15.0;
                            double montoFinal = 0;

                            //  Cálculo Base y Multa de 6 horas
                            if (tiemposim <= 15) // si es menor o igual a 15 min
                            {
                                montoFinal = 0;
                            }
                            else // si es mayor a 15 minutos
                            {
                                double horasSimuladas = tiemposim / 60.0;
                                montoFinal = horasSimuladas * tarifaPorHora;

                                if (tiemposim >= 360 && tiemposim < 720) // > 6 horas y menor a 12 horas entonces
                                {
                                    montoFinal = montoFinal + 25; // multa de 25Q
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("(!) Multa de Q25 aplicada por superar 6 horas.");
                                    Console.ResetColor();
                                }
                                else if (tiemposim >= 720) // multa de 12 horas
                                {
                                    montoFinal = montoFinal * 1.20; // Aplica recargo del 20%
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("(!) RECARGO DEL 20% aplicado por superar las 12 horas.");
                                    Console.ResetColor();
                                }
                            }

                            // 2. Descuento VIP
                            Console.Write("¿Cliente VIP? (S/N): ");
                            string esVIP = Console.ReadLine().ToUpper();
                            if (esVIP == "S")
                            {
                                montoFinal = montoFinal * 0.90;
                                Console.ForegroundColor= ConsoleColor.Green;
                                Console.WriteLine("(-) Descuento VIP del 10% aplicado.");
                                Console.ResetColor();
                            }
                            Console.ForegroundColor =ConsoleColor.Green; // resultado final si todo sale bien
                            Console.WriteLine("TICKET CERRADO");
                            Console.WriteLine("NOMBRE DELCLIENTE: " + clienteActivo);
                            Console.WriteLine("TIEMPO TOTAL: " + tiemposim + " min");
                            Console.WriteLine("MONTO FINAL A PAGAR: Q" + montoFinal);
                            Console.ResetColor();
                            dineroRecaudado = dineroRecaudado + montoFinal;
                            ticketscerrados++;
                            TicketActivo = false;
                            tiemposim = 0; // Reset para el siguiente vehículo
                        }
                        break;
                    }

                case "C": // ver estado 
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--- ESTADO ACTUAL ---");
                        Console.WriteLine("Capacidad total: " + capacidad);
                        Console.WriteLine("Espacios ocupados: " + (ticketscreados - ticketscerrados));
                        Console.WriteLine("Tickets creados: " + ticketscreados);
                        Console.WriteLine("Tickets cerrados: " + ticketscerrados);
                        Console.WriteLine("Total recaudado: Q" + dineroRecaudado);
                        Console.WriteLine("tiempo simulado: " + tiemposim);
                        Console.ResetColor ();
                        break;
                    }

                case "D": // pasar tiempo
                    {
                        int minutos;
                        Console.WriteLine("solicita minutos pasados"); // solicitar tiempo
                        minutos = Convert.ToInt32(Console.ReadLine());
                        tiemposim = minutos + tiemposim;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("tiempo acumulado total = " + tiemposim);
                        Console.ResetColor();
                        if (tiemposim >= 360 && tiemposim < 720) // multa de 6 horas advertencia
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Advertencia multa proxima (6 horas alcanzadas)");
                            Console.ResetColor();
                        }
                        else if (tiemposim >= 720) // multa de 12 horas permanencia extrema
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("ADVERTENCIA: RECARGO POR PERMANENCIA EXTREMA ACTIVO (12 horas)");
                            Console.ResetColor();
                        }
                        break;
                    }

                case "F": // salida
                    {
                        if (TicketActivo == false) // si no hay tickets abiertos
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Final del turno");
                            Console.WriteLine("tickets cerrados este turno: " + ticketscerrados);
                            Console.WriteLine("dinero recaudado este turno: " + dineroRecaudado);
                            Console.WriteLine("turno numero: " + codigoTurno + " cerrado con exito presione para salir");
                            Console.ResetColor();
                            continuar = false;
                        }
                        else // si hay tickets sin cerrar
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine(" ERROR: ticket no cerrado. Cierre el ticket para finalizar");
                            Console.ResetColor();
                        }
                        break;
                    }
            }
        }
    }
}