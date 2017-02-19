using CadnunsDev.CurrencyNotifier.Core;
using CadnunsDev.CurrencyNotifier.Core.DB;
using CadnunsDev.CurrencyNotifier.Core.Extensions;
using CadnunsDev.CurrencyNotifier.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadnunsDev.CurrencyNotifier
{
    public partial class NewCurrencyForm : Form
    {
        private CurrencyDbQueries _dbQueries;

        public NewCurrencyForm()
        {
            InitializeComponent();
            _dbQueries = new CurrencyDbQueries();
        }

        public Currency NewCurrency { get; internal set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new Currency
            {
                Code = tboxCurrencyCode.Text,
                ExchangeBaseCurrencyCode = tboxExchangeCode.Text,
                ExchageValue = tboxExchageValue.Text.ToDecimal(),
                LastUpdate = DateTime.Now
            };
            if (model.IsValid())
            {
                _dbQueries.Insert(model);
                NewCurrency = model;
                Close();
            }
            else
            {

            }
        }
    }
}
