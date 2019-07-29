using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimMED
{
    public partial class FrmPanelPrincipal: Form
    {
        public FrmPanelPrincipal()
        {
            InitializeComponent();
        }

        private void correrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimMED.Correr();
            SimMED.CargarTrayectoriasEnTabla(ref this.dataGridView1);
        }

        private void pasoAPasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tiempo Actual " + SimMED.TiempoActual();
            SimMED.UnPaso();
            MostrarValores();
            SimMED.CargarTrayectoriasEnTabla(ref this.dataGridView1);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MostrarValores()
        {
            txtPrecio.Text = SimMED.Precio.ToString();   
            txtIngresosNetos.Text= String.Format("{0:0.00}", SimMED.ObtenerValor("Ingresos Netos"));
            txtPorcion_del_Mercado.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Porcion del Mercado"));
            txtTamanio_Mercado.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Tamaño del Mercado"));
            txtVentas.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Ventas"));
            txtCompetencia.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Competencia"));
            txtMarketing.Text = SimMED.ObtenerValor("Marketing").ToString();
            txtSatisfaccion.Text = SimMED.ObtenerValor("Satisfaccion").ToString();
            txtCalidad_Estandar.Text = SimMED.ObtenerValor("Calidad Estandar").ToString();
            txtCalidad.Text = SimMED.ObtenerValor("Calidad").ToString();
            txtAgresividad.Text = SimMED.Agresividad.ToString();
            txtProductividad.Text = SimMED.ObtenerValor("Productividad").ToString();
            txtMejora.Text = SimMED.ObtenerValor("Mejora").ToString();
            txtGanancias.Text = SimMED.ObtenerValor("Ganancias").ToString();
            txtGanancias_Antes_Impuestos.Text = SimMED.ObtenerValor("Ganancias antes de Intereses e Impuestos").ToString();
            txtGananciasNetas.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Ganancias Netas"));
            txtDividendos.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Dividendos"));
            txtRetencion.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Retencion"));
            txtTecnologia.Text = SimMED.ObtenerValor("Tecnologia").ToString();
            txtImpuestos.Text = String.Format("{0:0.00}", SimMED.ObtenerValor("Impuestos"));

        }

        private void toolStripBtnPasoAPaso_Click(object sender, EventArgs e)
        {
            pasoAPasoToolStripMenuItem_Click(this, null);
        }

        private void toolStripBtnVerTray_Click(object sender, EventArgs e)
        {            
            SimMED.MostrarTray();            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>0)
            {
                string NombVar = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                SimMED.GraficarEnPic(charTray, NombVar);
                lblEcuacion.Text=SimMED.Ecuacion(NombVar);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripBtnVerTablas_Click(object sender, EventArgs e)
        {
            SimMED.MostrarPanel(); 
        }
    }
}
