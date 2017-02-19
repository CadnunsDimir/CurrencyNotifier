using System;
using System.Collections.Generic;
using CadnunsDev.CurrencyNotifier.Core.Models;
using Dapper;

namespace CadnunsDev.CurrencyNotifier.Core.DB
{
    public class CurrencyLogDbQueries : DbQueries
    {
        internal void Insert(CurrencyLog log)
        {
            var copy = log.Copy();
            //copy.Value *= 100;
            UsingConnection(conn => conn.ExecuteScalar<int>(Constantes.CurrencyLogInsert, copy));
        }

        internal List<CurrencyLog> GetFromCurrency(Currency moeda)
        {
            var lista = new List<CurrencyLog>();
            UsingConnection(conn => lista.AddRange(conn.Query<CurrencyLog>(Constantes.CurrencyLogSelect, new { CurrencyId = moeda.Id })));
            return lista;
        }
    }
}
