namespace DynamoC
{
    partial class FrmValoresTabla
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGridValores = new System.Windows.Forms.DataGridView();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridValores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGridValores);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 364);
            this.groupBox2.TabIndex = 2;
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
            this.dGridValores.Location = new System.Drawing.Point(17, 19);
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
            // FrmValoresTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 526);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmValoresTabla";
            this.Text = "FrmValoresTabla";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridValores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGridValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}