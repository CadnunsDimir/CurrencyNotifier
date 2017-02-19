using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadnunsDev.CurrencyNotifier.Core
{
    public class Constantes
    {
        /// <summary>
        /// 30 min (tempo em milisegundos)
        /// 30min x 60seg x 1000miliseg
        /// </summary>
        public const int IntervaloAtualizar = 30 * 60 * 1000;
        public const string CurrencyTable =
            @"create table currency(Id INTEGER PRIMARY KEY AUTOINCREMENT, Code, ExchageValue, ExchangeBaseCurrencyCode, LastUpdate);
                --insert into sqlite_sequence values(currency,1)";
        public const string CurrencyInsert = @"insert into currency
            (Code, ExchageValue, ExchangeBaseCurrencyCode, LastUpdate)            
            values(@Code, @ExchageValue, @ExchangeBaseCurrencyCode, @LastUpdate);select last_insert_rowid();";
        public const string CurrencyLogTable = @"create table if not exists currency_log(CurrencyId INTEGER, Value, Date)";
        public const string CurrencySelect = @"select * from currency";
        public const string CsvCurrenciesToBRL = "http://www4.bcb.gov.br/Download/fechamento/{0:yyyyMMdd}.csv";
        public const string GetExchange = "http://www.xe.com/currencyconverter/convert/?Amount=1&From={0}&To={1}";
        public const string GetCriptoCrExchage = "http://coinmill.com/rss/{0}_{1}.xml";
        public const string xPath = "//*[@id=\"ucc-container\"]/span[2]/span[2]";
        public const string CurrencyUpdate = "update currency set Code = @Code, ExchageValue=@ExchageValue, ExchangeBaseCurrencyCode=@ExchangeBaseCurrencyCode, LastUpdate=@LastUpdate where Id = @Id";
        public const string CurrencyLogInsert = "insert into currency_log values(@CurrencyId,@Value,@Date)";
        public const string CurrencyLogSelect = "select * from currency_log where CurrencyId = @CurrencyId";
    }
}