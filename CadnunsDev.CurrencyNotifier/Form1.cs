using CadnunsDev.CurrencyNotifier.Core;
using CadnunsDev.CurrencyNotifier.Core.AppService;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadnunsDev.CurrencyNotifier
{
    public partial class Form1 : Form
    {
        private CurrencyDbQueries _curencyDb;
        private Thread _thread;
        private CurrencyLogDbQueries _curencyDbLob;
        private ExchangeWebService _updateService;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PutAppOnSystemTray();
        }

        private void PutAppOnSystemTray()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowIcon = false;
                iconeSistema.Visible = true;
                iconeSistema.ShowBalloonTip(1000, Text, "você será notificado sobre o valor do dolar", ToolTipIcon.Info);
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _curencyDb = new CurrencyDbQueries();
            _curencyDbLob = new CurrencyLogDbQueries();
            _updateService = new ExchangeWebService(_curencyDb, _curencyDbLob);
            _updateService.EventSuccess = (moead, log) =>
            {
                var txt = "{0} =>>>> {1} = {2:0.00}".ToFormat(moead.Code, moead.ExchangeBaseCurrencyCode, log.Value);
                //MessageBox.Show();
                iconeSistema.ShowBalloonTip(1000, "Currency Update", txt, ToolTipIcon.Info);
            };
            tabelaMoedas.DataSource = _curencyDb.List();
            tabelaMoedas.CellClick += (obj, op) =>
            {
                var moeda = (obj as DataGridView).CurrentRow.DataBoundItem as Currency;
                new GraficoCurrencyForm(moeda, _curencyDbLob.GetFromCurrency(moeda)).Show();
            };
            _thread = new Thread(async () =>
            {
            while (true)
            {

                await _updateService.Run();

                    Action action = () =>
                    {

                        tabelaMoedas.DataSource = null;
                        tabelaMoedas.DataSource = _curencyDb.List();
                    };

                if (this.Visible)
                    this.BeginInvoke(action);
                    Thread.Sleep(Constantes.IntervaloAtualizar);
                }
            });
            _thread.Start();
        }

        private void iconeSistema_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();

        }

        private void btNewCurrency_Click(object sender, EventArgs e)
        {
            var form = new NewCurrencyForm();
            form.ShowDialog();
            var model = form.NewCurrency;
            var lista = tabelaMoedas.DataSource as IList<Currency>;
            lista.Add(model);
            tabelaMoedas.DataSource = null;
            tabelaMoedas.DataSource = lista;           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _thread.Abort();
        }
    }
}
