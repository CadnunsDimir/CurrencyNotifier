using CadnunsDev.CurrencyNotifier.Core.DB;
using CadnunsDev.CurrencyNotifier.Core.Extensions;
using CadnunsDev.CurrencyNotifier.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CadnunsDev.CurrencyNotifier.Core.AppService
{
    public class ExchangeWebService
    {
        private CurrencyDbQueries _currencyDbQueries;
        private CurrencyLogDbQueries _currencyLogDbQueries;

        public ExchangeWebService(CurrencyDbQueries currencyDbQueries, CurrencyLogDbQueries currencyLogDbQueries)
        {
            _currencyDbQueries = currencyDbQueries;
            _currencyLogDbQueries = currencyLogDbQueries;
        }



        public ExchangeWebEvent EventSuccess { get; set; }

        public delegate void ExchangeWebEvent(Currency currency, CurrencyLog log);

        private async Task UpdateValuesOfCurrencies()
        {
            var web = new HttpClient();

            var moedas = _currencyDbQueries.List();

            foreach (var moeda in moedas)
            {
                try
                {

                    var response = await web.GetAsync(Constantes.GetExchange.ToFormat(moeda.Code, moeda.ExchangeBaseCurrencyCode));
                    var txt = await response.Content.ReadAsStringAsync();
                    var valor = txt.Split(new[] { "uccResultAmount'>" }, StringSplitOptions.None)[1].Split('<')[0].Replace('.', ',').ToDecimal();

                    if (valor == 0)
                    {
                        valor = await GetCryptoCurrencyValue(moeda.Code, moeda.ExchangeBaseCurrencyCode);
                    }

                    moeda.ExchageValue = valor;
                    moeda.LastUpdate = DateTime.Now;
                    var log = new CurrencyLog
                    {
                        CurrencyId = moeda.Id,
                        Date = moeda.LastUpdate,
                        Value = valor
                    };
                    _currencyDbQueries.Update(moeda);
                    _currencyLogDbQueries.Insert(log);
                    EventSuccess(moeda, log);
                }
                catch (Exception ex)
                {

                }
            }
            
        }

        private async Task<decimal> GetCryptoCurrencyValue(string fromCurrency, string toCurrency, bool tryAgain = true, bool invertvaluesOnURL = false)
        {

            //var codesCrytoMoedas = new[] { "XMR", "BTC" };



            //var fromIsCripto = codesCrytoMoedas.Contains(fromCurrency);

            //var fromUrl = fromCurrency;
            //var toUrl = toCurrency;

            //if (fromIsCripto)
            //{
            //    fromUrl = toCurrency;
            //    toCurrency = to
            //}

            var web = new HttpClient();

            var url = Constantes.GetCriptoCrExchage.ToFormat(fromCurrency, toCurrency);
            if (invertvaluesOnURL)
            {
                url = Constantes.GetCriptoCrExchage.ToFormat(toCurrency, fromCurrency);
            }

            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            //var response = await web.GetAsync(Constantes.GetCriptoCrExchage.ToFormat(fromCurrency, toCurrency));
            //var txt = await response.Content.ReadAsStringAsync();
            //var doc = XElement.Parse(txt);
            var doc = feed.Items.FirstOrDefault().Summary.Text;
            //var html = doc.Element("item").Element("description").Value
            //    .Replace("<![CDATA[", "")
            //    .Split(new[] {"<br/>" }, StringSplitOptions.RemoveEmptyEntries);

            var html = doc.Split(new[] { "<br/>" }, StringSplitOptions.RemoveEmptyEntries); ;

            if (doc.Contains(fromCurrency) && doc.Contains(toCurrency))
            {
                //var item = fromIsCripto ? 1 : 0;

                var linha1 = html[0].Split(' ');
                var linha2 = html[1].Split(' ');

                var dados = linha1[1].Contains(fromCurrency) ? linha1 : linha2;
                 
                var valorFrom = dados[0].Replace('.', ',').ToDecimal();
                var valorTo = dados[3].Replace('.', ',').ToDecimal();
                var value = valorTo / valorFrom;
                return value;
            }
            else if (tryAgain)
            {
                return await GetCryptoCurrencyValue(fromCurrency, toCurrency, false, true);
            }
            else
            {
                throw new Exception("Invalid cripto coin");
            }

        }

        public async Task Run()
        {
            await UpdateValuesOfCurrencies();
        }
    }
}
