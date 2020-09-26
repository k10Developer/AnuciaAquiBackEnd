using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Infra.Helpers
{
    public static class Extension
    {
        public static bool IsBetween(this DateTime data, DateTime dataInicia, DateTime dataFinal)
        {
            return data >= dataInicia && data <= dataFinal;
        }

        public static string TSQLToAnsi(this string value)
        {
            var query = value.Replace("[", "\"").Replace("]", "\"");
            return query;
        }
    }
}
