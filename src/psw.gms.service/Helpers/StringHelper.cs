
using System.Text.Json;
using PSW.GMS.Common.Constants;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO.SendInboxMessage;
using PSW.RabbitMq;
using PSW.RabbitMq.ServiceCommand;
using PSW.RabbitMq.Task;
using PSW.GMS.Service.DTO;
using PSW.Lib.Logs;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PSW.GMS.Service.Helpers
{
    public static class StringHelper
    {
        public static string IsNull(string str)
        {
            try
            {
                return string.IsNullOrWhiteSpace(str) ? "N/A" : Convert.ToString(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string IsNullWithSafeHtmlTags(string str)
        {
            // PSW-45827

            try
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return "N/A";
                }

                if (str.Contains('>'))
                {
                    str = str.Replace(">", "&gt;");
                }

                if (str.Contains('<'))
                {
                    str = str.Replace("<", "&lt;");
                }

                return Convert.ToString(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string IsNull(string str, string EmptyValue = "N/A")
        {
            try
            {
                return string.IsNullOrWhiteSpace(str) ? EmptyValue : Convert.ToString(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string CamelCase(string s)
        {
            var x = s.Replace("_", " ");
            if (x.Length == 0) return "null";
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            return char.ToUpper(x[0]) + x.Substring(1);
        }

        /// <summary>
        /// EscapeZeros
        /// </summary>
        /// <param name="str">string: value</param>
        /// <param name="zeros">zeros: how many zeros to show after decimal</param>
        /// <returns></returns>
        public static string EscapeZeros(string str, string zeros)
        {
            var result = string.Empty;

            if (str.Contains("."))
            {
                string[] stringArray = str.Split('.');
                decimal valueAfterDecimal = 0;

                if (decimal.TryParse(stringArray[1], out valueAfterDecimal))
                {
                    result = valueAfterDecimal > 0 ? str : stringArray[0] + "." + zeros;
                }
                else
                {
                    result = stringArray[0];
                }
            }
            else
            {
                result = str;
            }

            return result;
        }

        public static string WhenIsNullSkipIndex(string str, int idx, string breakLine = "")
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }

            var result = " (" + idx + ") " + str;
            return (idx == 1) ? result : breakLine + result;
        }
    }
}