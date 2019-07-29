namespace DynamoC
{
    partial class FrmPanelVariables
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPanelVariables));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoElementos = new System.Windows.Forms.ComboBox();
            this.lstElementos = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGridValores = new System.Windows.Forms.DataGridView();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDefinicion = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridValores)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTipoElementos);
            this.groupBox1.Controls.Add(this.lstElementos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Variables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo:";
            // 
            // cboTipoElementos
            // 
            this.cboTipoElementos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoElementos.FormattingEnabled = true;
            this.cboTipoElementos.Items.AddRange(new object[] {
            "Nivel",
            "Tasa",
            "Auxiliar",
            "Tabla",
            "Todas"});
            this.cboTipoElementos.Location = new System.Drawing.Point(58, 20);
            this.cboTipoElementos.Name = "cboTipoElementos";
            this.cboTipoElementos.Size = new System.Drawing.Size(355, 21);
            this.cboTipoElementos.TabIndex = 1;
            this.cboTipoElementos.SelectedIndexChanged += new System.EventHandler(this.cboTipoElementos_SelectedIndexChanged);
            // 
            // lstElementos
            // 
            this.lstElementos.FormattingEnabled = true;
            this.lstElementos.Location = new System.Drawing.Point(58, 46);
            this.lstElementos.Name = "lstElementos";
            this.lstElementos.Size = new System.Drawing.Size(355, 212);
            this.lstElementos.TabIndex = 0;
            this.lstElementos.SelectedIndexChanged += new System.EventHandler(this.lstElementos_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGridValores);
            this.groupBox2.Location = new System.Drawing.Point(13, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 364);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valores de Trayectoria";
            // 
            // dGridValores
            // 
            this.dGridValores.AllowUserToAddRows = false;
            this.dGridValores.AllowUserToDeleteRows = false;
            this.dGridValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridValores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tiempo,
            this.Valor});
            this.dGridValores.Location = new System.Drawing.Point(23, 20);
            this.dGridValores.Name = "dGridValores";
            this.dGridValores.RowHeadersVisible = false;
            this.dGridValores.Size = new System.Drawing.Size(389, 323);
            this.dGridValores.TabIndex = 0;
            // 
            // Tiempo
            // 
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDefinicion);
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(457, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(532, 642);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gráfica de Trayectoria";
            // 
            // txtDefinicion
            // 
            this.txtDefinicion.Location = new System.Drawing.Point(16, 474);
            this.txtDefinicion.Multiline = true;
            this.txtDefinicion.Name = "txtDefinicion";
            this.txtDefinicion.Size = new System.Drawing.Size(499, 125);
            this.txtDefinicion.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(29, 35);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(475, 415);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 441);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 671);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPanelVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 710);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPanelVariables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Variables";
            this.Load += new System.EventHandler(this.FrmPanelVariables_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridValores)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoElementos;
        private System.Windows.Forms.ListBox lstElementos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dGridValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtDefinicion;
    }
}

