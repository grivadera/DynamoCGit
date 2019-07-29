using DynamoC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoC
{    

    public partial class FrmDetalleVariable : Form
    {
        Elemento _elemento;

        public FrmDetalleVariable()
        {
            InitializeComponent();
        }

        private void btnPaso_Click(object sender, EventArgs e)
        {
            double TiempoFinal = Modelo.UnPaso();
            
        }

        public void Mostrar(Elemento e)
        {
            _elemento = e;
            this.Show();
        }
    }
}
