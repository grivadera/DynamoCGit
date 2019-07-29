using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamoC.Clases;

namespace DynamoC
{
    public partial class FrmTrayectorias : Form
    {
        public FrmTrayectorias()
        {
            InitializeComponent();
        }

        public void Mostrar()
        {
            //Cargar nombres de variables
            //foreach (Elemento e in Modelo.Elementos)
            //{

            //}
            Modelo.CargarTrayectoriasEnTabla(ref this.dataGridView1, "",2);
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                string nombre = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                txtEcuacion.Text = Modelo.Identificar(nombre).Ecuacion;
            }
        }
    }
}
