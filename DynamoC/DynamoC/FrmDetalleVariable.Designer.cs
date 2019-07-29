namespace DynamoC
{
    partial class FrmDetalleVariable
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGridValores = new System.Windows.Forms.DataGridView();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPaso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGridValores)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dGridValores
            // 
            this.dGridValores.AllowUserToAddRows = false;
            this.dGridValores.AllowUserToDeleteRows = false;
            this.dGridValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridValores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tiempo,
            this.Valor});
            this.dGridValores.Location = new System.Drawing.Point(12, 159);
            this.dGridValores.Name = "dGridValores";
            this.dGridValores.RowHeadersVisible = false;
            this.dGridValores.Size = new System.Drawing.Size(525, 291);
            this.dGridValores.TabIndex = 1;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPaso);
            this.groupBox2.Location = new System.Drawing.Point(17, 463);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 71);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnPaso
            // 
            this.btnPaso.Location = new System.Drawing.Point(338, 19);
            this.btnPaso.Name = "btnPaso";
            this.btnPaso.Size = new System.Drawing.Size(86, 36);
            this.btnPaso.TabIndex = 0;
            this.btnPaso.Text = "Paso";
            this.btnPaso.UseVisualStyleBackColor = true;
            this.btnPaso.Click += new System.EventHandler(this.btnPaso_Click);
            // 
            // FrmDetalleVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 545);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dGridValores);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDetalleVariable";
            this.Text = "FrmDetalleVariable";
            ((System.ComponentModel.ISupportInitialize)(this.dGridValores)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGridValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPaso;
    }
}