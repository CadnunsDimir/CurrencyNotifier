using CadnunsDev.CurrencyNotifier.Core;
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
    public partial class GraficoCurrencyForm : Form
    {
        private Currency _currency;
        private List<CurrencyLog> _logs;

        public GraficoCurrencyForm(Currency currency, List<CurrencyLog> logs)
        {
            InitializeComponent();
            _currency = currency;
            _logs = logs;
        }

        private void GraficoCurrencyForm_Load(object sender, EventArgs e)
        {
            BindCurrencyOnLabels();
            LoadDataChart();
        }

        private void LoadDataChart()
        {
            chart1.DataSource = _logs;
            //var linha = chart1.Series.FirstOrDefault();
            chart1.DataBind();
        }

        private void BindCurrencyOnLabels()
        {
            tbMoeda.Text = _currency.Code;
            tbMoedaExchange.Text = _currency.ExchangeBaseCurrencyCode;
            tbValor.Text = _currency.ExchageValue.ToString("0.00");
            tbData.Text = _currency.LastUpdate.ToString();
        }
    }
}
