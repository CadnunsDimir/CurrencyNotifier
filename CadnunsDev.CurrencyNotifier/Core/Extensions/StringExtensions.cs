using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadnunsDev.CurrencyNotifier.Core.Extensions
{
    public static class StringExtensions
    {
        public static decimal ToDecimal(this string value)
        {
            decimal ret = 0;
            Decimal.TryParse(value, out ret);
            return ret;
        }

        public static string ToFormat(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

    }
}
