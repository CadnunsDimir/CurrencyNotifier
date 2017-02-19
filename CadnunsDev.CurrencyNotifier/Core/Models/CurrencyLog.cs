using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadnunsDev.CurrencyNotifier.Core.Models
{
    public class CurrencyLog
    {
        public int CurrencyId { get; set; }

        public CurrencyLog Copy()
        {
            return (CurrencyLog)MemberwiseClone();
        }

        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
