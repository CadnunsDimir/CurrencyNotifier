namespace CadnunsDev.CurrencyNotifier
{
    partial class GraficoCurrencyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMoeda = new System.Windows.Forms.Label();
            this.tbMoedaExchange = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbValor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moeda";
            // 
            // tbMoeda
            // 
            this.tbMoeda.AutoSize = true;
            this.tbMoeda.Location = new System.Drawing.Point(12, 36);
            this.tbMoeda.Name = "tbMoeda";
            this.tbMoeda.Size = new System.Drawing.Size(35, 13);
            this.tbMoeda.TabIndex = 1;
            this.tbMoeda.Text = "label2";
            // 
            // tbMoedaExchange
            // 
            this.tbMoedaExchange.AutoSize = true;
            this.tbMoedaExchange.Location = new System.Drawing.Point(63, 36);
            this.tbMoedaExchange.Name = "tbMoedaExchange";
            this.tbMoedaExchange.Size = new System.Drawing.Size(35, 13);
            this.tbMoedaExchange.TabIndex = 3;
            this.tbMoedaExchange.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cambiar Para";
            // 
            // tbValor
            // 
            this.tbValor.AutoSize = true;
            this.tbValor.Location = new System.Drawing.Point(139, 36);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(35, 13);
            this.tbValor.TabIndex = 5;
            this.tbValor.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Valor Atual";
            // 
            // tbData
            // 
            this.tbData.AutoSize = true;
            this.tbData.Location = new System.Drawing.Point(203, 36);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(35, 13);
            this.tbData.TabIndex = 7;
            this.tbData.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Data";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(15, 67);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "Date";
            series1.YValueMembers = "Value";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(871, 375);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // GraficoCurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 454);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMoedaExchange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMoeda);
            this.Controls.Add(this.label1);
            this.Name = "GraficoCurrencyForm";
            this.Text = "GraficoCurrencyForm";
            this.Load += new System.EventHandler(this.GraficoCurrencyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tbMoeda;
        private System.Windows.Forms.Label tbMoedaExchange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tbValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tbData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}