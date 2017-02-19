using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadnunsDev.CurrencyNotifier.Core.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal ExchageValue { get; set; }

        public Currency Copy()
        {
            return (Currency)this.MemberwiseClone();
        }

        public string ExchangeBaseCurrencyCode { get; set; }
        public DateTime LastUpdate { get; set; }

        internal bool IsValid()
        {
            return true;
        }
    }
}
