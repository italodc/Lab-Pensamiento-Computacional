using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class CuentaBancaria
    {
        public string Titular;
        public string NumeroCuenta;
        public decimal Saldo;

        // Constructor
        public CuentaBancaria(string titular, string numeroCuenta, decimal saldo)
        {
            Titular = titular;
            NumeroCuenta = numeroCuenta;
            Saldo = saldo;
        }

        // Mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine("Titular: " + Titular);
            Console.WriteLine("Número de cuenta: " + NumeroCuenta);
            Console.WriteLine("Saldo: Q" + Saldo);
            Console.WriteLine();
        }

        // Depositar
        public void Depositar(decimal monto)
        {
            Console.WriteLine("Saldo antes del depósito: Q" + Saldo);
            Saldo += monto;
            Console.WriteLine("Se depositaron Q" + monto);
            Console.WriteLine("Saldo después del depósito: Q" + Saldo);
            Console.WriteLine();
        }

        // Retirar
        public void Retirar(decimal monto)
        {
            Console.WriteLine("Saldo antes del retiro: Q" + Saldo);

            if (Saldo >= monto)
            {
                Saldo -= monto;
                Console.WriteLine("Se retiraron Q" + monto);
            }
            else
            {
                Console.WriteLine("Fondos insuficientes.");
            }

            Console.WriteLine("Saldo después del retiro: Q" + Saldo);
            Console.WriteLine();
        }
    }
}
