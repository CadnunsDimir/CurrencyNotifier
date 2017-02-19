namespace CadnunsDev.CurrencyNotifier
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.iconeSistema = new System.Windows.Forms.NotifyIcon(this.components);
            this.btNewCurrency = new System.Windows.Forms.Button();
            this.tabelaMoedas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaMoedas)).BeginInit();
            this.SuspendLayout();
            // 
            // iconeSistema
            // 
            this.iconeSistema.Icon = ((System.Drawing.Icon)(resources.GetObject("iconeSistema.Icon")));
            this.iconeSistema.Text = "notifyIcon1";
            this.iconeSistema.Visible = true;
            this.iconeSistema.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iconeSistema_MouseDoubleClick);
            // 
            // btNewCurrency
            // 
            this.btNewCurrency.Location = new System.Drawing.Point(182, 12);
            this.btNewCurrency.Name = "btNewCurrency";
            this.btNewCurrency.Size = new System.Drawing.Size(90, 23);
            this.btNewCurrency.TabIndex = 0;
            this.btNewCurrency.Text = "Nova Moeda";
            this.btNewCurrency.UseVisualStyleBackColor = true;
            this.btNewCurrency.Click += new System.EventHandler(this.btNewCurrency_Click);
            // 
            // tabelaMoedas
            // 
            this.tabelaMoedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaMoedas.Location = new System.Drawing.Point(13, 51);
            this.tabelaMoedas.Name = "tabelaMoedas";
            this.tabelaMoedas.Size = new System.Drawing.Size(259, 198);
            this.tabelaMoedas.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabelaMoedas);
            this.Controls.Add(this.btNewCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CurrencyNotifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaMoedas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon iconeSistema;
        private System.Windows.Forms.Button btNewCurrency;
        private System.Windows.Forms.DataGridView tabelaMoedas;
    }
}

