using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadnunsDev.CurrencyNotifier.Core.Extensions;

namespace CadnunsDev.CurrencyNotifier.Core.DB.Types
{
    public class DecimalTypeHadler : SqlMapper.TypeHandler<decimal>
    {
        //public object Parse(Type destinationType, object value)
        //{
        //    return value.ToString().Replace('.', ',').ToDecimal();
        //}

        //public void SetValue(IDbDataParameter parameter, object value)
        //{
        //    parameter.Value = value;
        //}
        public override decimal Parse(object value)
        {
            return value.ToString().Replace('.', ',').ToDecimal();
        }

        public override void SetValue(IDbDataParameter parameter, decimal value)
        {
            parameter.Value = value;
        }
    }
}
