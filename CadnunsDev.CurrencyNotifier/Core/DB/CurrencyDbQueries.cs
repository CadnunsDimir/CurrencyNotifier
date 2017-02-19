using CadnunsDev.CurrencyNotifier.Core.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CadnunsDev.CurrencyNotifier.Core.DB
{
    public class CurrencyDbQueries : DbQueries
    {
        public void Insert(Currency model)
        {
            var copy = model.Copy();
            //copy.ExchageValue *= 100;
            UsingConnection(conn=> model.Id =  conn.ExecuteScalar<int>(Constantes.CurrencyInsert, copy));
        }

        public IList<Currency> List()
        {
            IList<Currency> currencies = new List<Currency>();
            UsingConnection(conn =>
            {
                var lista = conn.Query(Constantes.CurrencySelect).ToList();
                currencies = conn.Query<Currency>(Constantes.CurrencySelect).ToList();
            });
            //currencies.ToList().ForEach(x => x.ExchageValue /= 100);
            return currencies;
        }

        internal void Update(Currency moeda)
        {
            var copy = moeda.Copy();
            //copy.ExchageValue *= 100;
            UsingConnection(conn => conn.ExecuteScalar<int>(Constantes.CurrencyUpdate, copy));
        }
    }
}
