using AtencionTramites.Model.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Interfaces.UltimusIntegration;
using Ultimus.Utilitarios;

namespace AtencionTramites.Model.Classes
{
    public class UltimusUtility
    {
        public static string SetFormatCurrency(decimal? monto)
        {
            if (!monto.HasValue)
            {
                return string.Empty;
            }
            NumberFormatInfo nfi = Constantes.esPA.NumberFormat;
            nfi.CurrencyDecimalDigits = 2;
            return monto.Value.ToString("C", nfi);
        }

        public static string ObtenerFechaTipo1(DateTime? date)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }
            return string.Format("{0} de {1} de {2}", date.Value.Day, date.Value.ToString("MMMM", Constantes.esPA), date.Value.Year);
        }

        public static string ObtenerFechaTipo2(DateTime? date)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }
            return string.Format("a los {0} ({1}) días del mes de {2} de {3} ({4})", NumeroALetras(date.Value.Day), date.Value.Day, date.Value.ToString("MMMM", Constantes.esPA), NumeroALetras(date.Value.Year), date.Value.Year);
        }

        public static string ObtenerFechaTipo3(DateTime? date)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }
            return string.Format("{0} {1} {2}", date.Value.Day, date.Value.ToString("MMMM", Constantes.esPA), date.Value.Year);
        }

        public static string ObtenerFechaTipo4(DateTime? date)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }
            return date.Value.ToString("dd/MMMM/yyyy hh:mm:ss tt", Constantes.esPA);
        }

        public static string ObtenerFechaTipo5(DateTime? date)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }
            return string.Format(date.Value.ToString("MMMM dd yyyy, a {0} hh:mm:ss tt", Constantes.esPA), "las");
        }

        public static double DateDiffMonths(DateTime start, DateTime end)
        {
            return (end - start).TotalHours;
        }

        public static int DateDiffDays(DateTime start, DateTime end, bool onlyBusinessDays)
        {
            int ret = 0;
            if (Convert.ToInt64(start.ToString("yyyyMMdd")) <= Convert.ToInt64(end.ToString("yyyyMMdd")))
            {
                DateTime i = start;
                while (i <= end)
                {
                    if (onlyBusinessDays)
                    {
                        if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != 0)
                        {
                            ret++;
                        }
                    }
                    else
                    {
                        ret++;
                    }
                    i = i.AddDays(1.0);
                }
            }
            return ret;
        }

        public static string NumeroALetras(decimal? nro)
        {
            if (!nro.HasValue)
            {
                return string.Empty;
            }
            long entero = Convert.ToInt64(Math.Truncate(nro.Value));
            int decimales = Convert.ToInt32(Math.Round((nro.Value - (decimal)entero) * 100m, 2));
            string dec = "";
            if (decimales > 0)
            {
                dec = " CON " + decimales + "/100";
            }
            return toText(Convert.ToDouble(entero)) + dec;
        }

        private static string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0.0)
            {
                Num2Text = "CERO";
            }
            else if (value == 1.0)
            {
                Num2Text = "UNO";
            }
            else if (value == 2.0)
            {
                Num2Text = "DOS";
            }
            else if (value == 3.0)
            {
                Num2Text = "TRES";
            }
            else if (value == 4.0)
            {
                Num2Text = "CUATRO";
            }
            else if (value == 5.0)
            {
                Num2Text = "CINCO";
            }
            else if (value == 6.0)
            {
                Num2Text = "SEIS";
            }
            else if (value == 7.0)
            {
                Num2Text = "SIETE";
            }
            else if (value == 8.0)
            {
                Num2Text = "OCHO";
            }
            else if (value == 9.0)
            {
                Num2Text = "NUEVE";
            }
            else if (value == 10.0)
            {
                Num2Text = "DIEZ";
            }
            else if (value == 11.0)
            {
                Num2Text = "ONCE";
            }
            else if (value == 12.0)
            {
                Num2Text = "DOCE";
            }
            else if (value == 13.0)
            {
                Num2Text = "TRECE";
            }
            else if (value == 14.0)
            {
                Num2Text = "CATORCE";
            }
            else if (value == 15.0)
            {
                Num2Text = "QUINCE";
            }
            else if (value < 20.0)
            {
                Num2Text = "DIECI" + toText(value - 10.0);
            }
            else if (value == 20.0)
            {
                Num2Text = "VEINTE";
            }
            else if (value < 30.0)
            {
                Num2Text = "VEINTI" + toText(value - 20.0);
            }
            else if (value == 30.0)
            {
                Num2Text = "TREINTA";
            }
            else if (value == 40.0)
            {
                Num2Text = "CUARENTA";
            }
            else if (value == 50.0)
            {
                Num2Text = "CINCUENTA";
            }
            else if (value == 60.0)
            {
                Num2Text = "SESENTA";
            }
            else if (value == 70.0)
            {
                Num2Text = "SETENTA";
            }
            else if (value == 80.0)
            {
                Num2Text = "OCHENTA";
            }
            else if (value == 90.0)
            {
                Num2Text = "NOVENTA";
            }
            else if (value < 100.0)
            {
                Num2Text = toText(Math.Truncate(value / 10.0) * 10.0) + " Y " + toText(value % 10.0);
            }
            else if (value == 100.0)
            {
                Num2Text = "CIEN";
            }
            else if (value < 200.0)
            {
                Num2Text = "CIENTO " + toText(value - 100.0);
            }
            else if (value == 200.0 || value == 300.0 || value == 400.0 || value == 600.0 || value == 800.0)
            {
                Num2Text = toText(Math.Truncate(value / 100.0)) + "CIENTOS";
            }
            else if (value == 500.0)
            {
                Num2Text = "QUINIENTOS";
            }
            else if (value == 700.0)
            {
                Num2Text = "SETECIENTOS";
            }
            else if (value == 900.0)
            {
                Num2Text = "NOVECIENTOS";
            }
            else if (value < 1000.0)
            {
                Num2Text = toText(Math.Truncate(value / 100.0) * 100.0) + " " + toText(value % 100.0);
            }
            else if (value == 1000.0)
            {
                Num2Text = "MIL";
            }
            else if (value < 2000.0)
            {
                Num2Text = "MIL " + toText(value % 1000.0);
            }
            else if (value < 1000000.0)
            {
                Num2Text = toText(Math.Truncate(value / 1000.0)) + " MIL";
                if (value % 1000.0 > 0.0)
                {
                    Num2Text = Num2Text + " " + toText(value % 1000.0);
                }
            }
            else if (value == 1000000.0)
            {
                Num2Text = "UN MILLON";
            }
            else if (value < 2000000.0)
            {
                Num2Text = "UN MILLON " + toText(value % 1000000.0);
            }
            else if (value < 1000000000000.0)
            {
                Num2Text = toText(Math.Truncate(value / 1000000.0)) + " MILLONES ";
                if (value - Math.Truncate(value / 1000000.0) * 1000000.0 > 0.0)
                {
                    Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000.0) * 1000000.0);
                }
            }
            else if (value == 1000000000000.0)
            {
                Num2Text = "UN BILLON";
            }
            else if (value < 2000000000000.0)
            {
                Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
            }
            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000.0)) + " BILLONES";
                if (value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0 > 0.0)
                {
                    Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
                }
            }
            return Num2Text;
        }

        public static string ObtenerNumeroRadicado(string SiglaEntidad, string SiglaCorrespondencia, DateTime Fecha, string CodigoDependencia, int Secuencial)
        {
            return Fecha.ToString("yyyy") + CodigoDependencia.PadLeft(6, '0') + Convert.ToString(Secuencial).PadLeft(5, '0') + SiglaCorrespondencia;
        }

        public static string ObtenerNumeroRadicadoDepartamental(DateTime Fecha, int SecuencialDepartamental)
        {
            return Fecha.ToString("yyyyMMdd") + "-" + Convert.ToString(SecuencialDepartamental).PadLeft(9, '0');
        }

        public static string GenerarClaveSHA1(string cadena)
        {
            byte[] data = new UTF8Encoding().GetBytes(cadena);
            byte[] result = new SHA1CryptoServiceProvider().ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}