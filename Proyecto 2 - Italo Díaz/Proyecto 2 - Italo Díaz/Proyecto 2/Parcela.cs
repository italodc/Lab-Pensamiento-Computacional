using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Parcela
    {
        public bool EstaOcupada { get; private set; } = false;
        public int TipoSiembra { get; private set; } = 0;
        public int MesesCrecimiento { get; private set; } = 0;
        public int MesesFaltantes { get; private set; } = 0;
        public double IngresosCosecha { get; private set; } = 0.0;
        public string NombreSiembra { get; private set; } = "";

        //Siembra un cultivo en esta parcela.
        public void Sembrar(TipoCultivo tipo)
        {
            EstaOcupada = true;
            TipoSiembra = tipo.Codigo;
            NombreSiembra = tipo.Nombre;
            MesesCrecimiento = tipo.Meses;
            MesesFaltantes = tipo.Meses;
            IngresosCosecha = tipo.Ingreso;
        }

        //Avanza un mes de crecimiento.
        //Devuelve true si la cosecha fue completada este mes.
        public bool AvanzarMes()
        {
            if (!EstaOcupada) return false;
            MesesFaltantes--;
            if (MesesFaltantes > 0) return false;

            // Cosechar: vaciar la parcela
            Vaciar();
            return true;
        }

        //Reinicia la parcela a estado vacío.
        public void Vaciar()
        {
            EstaOcupada = false;
            TipoSiembra = 0;
            MesesCrecimiento = 0;
            MesesFaltantes = 0;
            IngresosCosecha = 0;
            NombreSiembra = "";
        }

        //Símbolo visual para el mapa: '-' libre, inicial del cultivo si ocupada.
        public char SimboloMapa() =>
            EstaOcupada ? NombreSiembra[0] : '-';

        public override string ToString()
        {
            if (!EstaOcupada)
                return "  Estado           : LIBRE\n  Ingresos esperados: Q 0.00";

            return $"  Estado            : OCUPADA\n" +
                   $"  Cultivo           : {NombreSiembra}\n" +
                   $"  Meses crecimiento : {MesesCrecimiento}\n" +
                   $"  Meses faltantes   : {MesesFaltantes}\n" +
                   $"  Ingresos esperados: Q {IngresosCosecha:F2}";
        }
    }
}
