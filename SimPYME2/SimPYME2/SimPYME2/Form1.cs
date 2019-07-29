using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPYME2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnUnPaso_Click(object sender, EventArgs e)
        {
            SimPYME2.UnPaso();
        }

        private void btnCorrer_Click(object sender, EventArgs e)
        {
            SimPYME2.Precio = (double)numPrecio.Value;
            SimPYME2.CantVendedores = (int) numVend.Value;
            SimPYME2.SalarioPromedio = (double) numSalarioProm.Value;
            SimPYME2.InventarioInicial = (double) numInventarioInicial.Value;
            SimPYME2.DineroInicial = (double)numDineroInicial.Value;
            SimPYME2.VariacionProdMedia = (double) numVarProd.Value;
            SimPYME2.Correr();
            SimPYME2.GraficarEnPic(chartDinero, "Dinero");
            SimPYME2.GraficarEnPic(chartVentas, "Ventas");
            SimPYME2.GraficarEnPic(chartGanNeta, "Ganancias Netas");
            SimPYME2.GraficarEnPic(chartInventario, "Inventario");
            SimPYME2.GraficarEnPic(chartProduccion, "Produccion");
            SimPYME2.GraficarEnPic(chartCostoVarInv, "Costos Inventario");
            SimPYME2.GraficarEnPic(chartCostosTotales, "Costos Totales");
            SimPYME2.GraficarEnPic(chartCostosSalarios, "Costo Salarios");
            SimPYME2.GraficarEnPic(chartDemanda, "Demanda"); 


        }

        private void btnDetalleVariables_Click(object sender, EventArgs e)
        {
            SimPYME2.MostrarPanel();
        }
    }
}
