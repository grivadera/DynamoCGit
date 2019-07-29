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
    public partial class FrmPanelVariables : Form
    {

        public FrmPanelVariables()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void FrmPanelVariables_Load(object sender, EventArgs e)
        {
            Modelo.CargarElementosEnLista(ref this.lstElementos);

        }

        private void lstElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTabla(lstElementos.SelectedItem.ToString());
        }

        private void CargarTabla(string nombre)
        {
            Modelo.Identificar(nombre).CargarTablaEnGrid(this.dGridValores);
            Modelo.Identificar(nombre).GraficarEnPic(this.chart1);
            txtDefinicion.Text = Modelo.Identificar(nombre).Ecuacion;
        }

        private void cboTipoElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoElementos.SelectedItem.ToString() == "Todas")
                Modelo.CargarElementosEnLista(ref this.lstElementos);
            else
                Modelo.CargarElementosEnLista(ref this.lstElementos, cboTipoElementos.SelectedItem.ToString());

        }
    }
}

