using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Interfaces.UltimusIntegration;
using Ultimus.Utilitarios;

namespace AtencionTramites.Model.Classes
{
    public class UltimusUtility
    {
        public static void SetProperties(object source, object target)
        {
            var customerType = target.GetType();
            foreach (var prop in source.GetType().GetProperties())
            {
                if (prop != null && prop.CanRead && !prop.Name.Contains("Auditoria"))
                {
                    var propGetter = prop.GetGetMethod();
                    var valueToSet = propGetter.Invoke(source, null);
                    var prop2 = customerType.GetProperty(prop.Name);
                    if (prop2 != null && prop2.CanWrite)
                    {
                        var propSetter = prop2.GetSetMethod();
                        propSetter.Invoke(target, new[] { valueToSet });
                    }
                }
            }
        }

        public static string GetValue(object value)
        {
            return GetValue(value, null, null, null);
        }

        public static string GetValue(object value, string left_symbol, string right_symbol, int? decimals)
        {
            string ret = string.Empty;
            if (value is bool)
            {
                if (Convert.ToBoolean(value))
                {
                    ret = "Sí";
                }
                else
                {
                    ret = "No";
                }
            }
            else if (value is DateTime)
            {
                ret = string.Format("{0} de {1} de {2}", Convert.ToDateTime(value).Day, Convert.ToDateTime(value).ToString("MMMM", Constantes.esPA), Convert.ToDateTime(value).Year);
            }
            else if (value is decimal || value is double)
            {
                string format = "#,##0";
                if (decimals == null)
                {
                    string[] res = Convert.ToString(value).Split('.');
                    int precision = 0;
                    if (res.Length == 2 && res[1].Any(q => q != '0'))
                    {
                        precision = res[1].Length;
                        if (precision > 0)
                        {
                            format = "#,##0.".PadRight(6 + precision, '0');
                        }
                    }
                }
                else
                {
                    format = "#,##0.".PadRight(6 + decimals.Value, '0');
                }
                ret = Convert.ToDecimal(value).ToString(format);
            }
            else
            {
                ret = Convert.ToString(value);
            }
            if (!string.IsNullOrEmpty(ret))
            {
                if (!string.IsNullOrEmpty(left_symbol) && !string.IsNullOrEmpty(right_symbol))
                {
                    ret = string.Format("{0} {1} {2}", left_symbol, ret, right_symbol);
                }
                else if (!string.IsNullOrEmpty(left_symbol))
                {
                    ret = string.Format("{0} {1}", left_symbol, ret);
                }
                else if (!string.IsNullOrEmpty(right_symbol))
                {
                    ret = string.Format("{0} {1}", ret, right_symbol);
                }
            }
            return ret;
        }

        public static int YearsDiff(DateTime start, DateTime end)
        {
            int ret = 0;
            if (end > start)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                TimeSpan span = end - start;
                ret = (zeroTime + span).Year - 1;
            }
            return ret;
        }

        public static string ObtenerEmail(string Id)
        {
            string ret = string.Empty;
            using (UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController())
            {
                UltimusUser UltimusUser = UltimusIntegrationAPIController.GetUserInformation(Id);
                if (UltimusUser != null)
                {
                    ret = UltimusUser.EmailAddress;
                }
            }
            return ret;
        }

        public static List<StepFormsList> ObtenerFormularios(UltimusIncident Tarea, string QueryString)
        {
            return ObtenerFormularios(Tarea.Process, Tarea.Step, QueryString);
        }

        public static List<StepFormsList> ObtenerFormularios(string Process, string Step, string QueryString)
        {
            UltimusFormAPIController UltimusFormAPIController = new UltimusFormAPIController();
            List<StepFormsList> menu = UltimusFormAPIController.ObtenerFormularios(Process, Step);
            if (menu != null)
            {
                foreach (StepFormsList StepFormsList in menu)
                {
                    StringBuilder ret = new StringBuilder();
                    Crypt crypt = new Crypt();
                    ret.AppendFormat(StepFormsList.FormPath);
                    if (QueryString != null)
                        ret.AppendFormat(QueryString);

                    StepFormsList.FormPath = ret.ToString();
                }
            }
            return menu;
        }

        public static string Serializar(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}