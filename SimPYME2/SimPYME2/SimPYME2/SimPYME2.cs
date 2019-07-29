using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamoC.Clases;
using RandomC;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimPYME2
{
    class SimPYME2
    {
        private static Nivel Inventario = new Nivel("Inventario", 0); //
        private static Nivel Dinero = new Nivel("Dinero", 0); //
        private static Nivel UnidadesVendidas = new Nivel("Unidades Vendidas",0);
        private static Auxiliar Demanda = new Auxiliar("Demanda", 0, 1); // 
        private static Auxiliar GananciasNetas = new Auxiliar("Ganancias Netas", 0, 2); //
        private static Auxiliar CostoSalarios = new Auxiliar("Costo Salarios",0,3); //        
        private static Auxiliar CostosInventario = new Auxiliar("Costos Inventario", 0, 4); // 
        private static Auxiliar CostosTotales = new Auxiliar("Costos Totales", 0, 5); // 
        

        private static Tasa Produccion = new Tasa("Produccion");
        private static Tasa Ventas = new Tasa("Ventas");

        public static double Precio = 100;
        public static double ProductividadMedia = 10;
        public static double VariacionProdMedia = 2;
        public static double PromedioVtasMensuales = 8;
        public static double FactorAfecInf = 1.80f;
        public static double PorcIncVend = .50f;
        public static double PorcImpuestos = .30f;
        public static double CostoInvPorUnidadAlmacenada = .50f;
        public static double CostoVariableUnitario = 20;
        public static double SalarioPromedio = 1000;
        public static double DineroInicial = 1000;
        public static double InventarioInicial = 1000;
        public static int CantVendedores = 2;

        private static Tabla ExpInf = new Tabla("ExpInf");

        private static void Inicializar()
        {
            Modelo.Crear("Simulador de Mediana Empresa", 1);
            ExpInf.Usotabla = Tabla.UsoTabla.Reloj;
            double[] param = { ProductividadMedia, VariacionProdMedia };
            GVA.Distribucion d= GVA.Distribucion.Normal;
            GVA.TipoGenerador t = GVA.TipoGenerador.MarsagliaMWC;
            GVA VAProductividad = new GVA(d,param,t,1);
            Inventario.EstablecerValorInicial(InventarioInicial);
            Inventario.UpdateFn = () => Funciones.MAX(0,(Inventario.j + (Produccion.k - UnidadesVendidas.k) * Reloj.DT));
            Produccion.UpdateFn = () => (VAProductividad.Generar());
            Demanda.UpdateFn = () => (PromedioVtasMensuales * (PorcIncVend * CantVendedores) - (ExpInf.k) / 100f * FactorAfecInf * PromedioVtasMensuales);
            UnidadesVendidas.UpdateFn = () => Funciones.MIN(Demanda.k,Inventario.k); //Unidades
            Ventas.UpdateFn = () => (Precio * UnidadesVendidas.k); //$
            CostoSalarios.UpdateFn = () => (CantVendedores * SalarioPromedio); //$
            GananciasNetas.UpdateFn = () => (Ventas.k - (Ventas.k * PorcImpuestos)); //$
            CostosInventario.UpdateFn = () => (CostoInvPorUnidadAlmacenada*Inventario.k); //$
            CostosTotales.UpdateFn = () => (CostoSalarios.k + CostosInventario.k); //$
            Dinero.EstablecerValorInicial(DineroInicial);
            Dinero.UpdateFn = () => (Dinero.j+(GananciasNetas.k-CostoSalarios.k-CostosInventario.k)*Reloj.DT); //$

        }

        public static void Correr()
        {
            Inicializar();
            //Inflacion.UpdateFn = () => (ExpInf.k);
            double TiempoFinal = Modelo.Correr(0, 20);
            System.Windows.Forms.MessageBox.Show("Simulación Finalizada en Tiempo " + TiempoFinal.ToString(),"Atención",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
            //Modelo.MostrarPanel();

        }

        public static void MostrarPanel()
        {
            Modelo.MostrarPanel();
        }

        public static void UnPaso()
        {
            if (!Modelo.Inicializado)
                Inicializar();
            double TiempoFinal = Modelo.UnPaso();
        }

        public static double ObtenerValor(string Variable)
        {
            return (Modelo.ObtenerValor(Variable));
        }

        internal static void MostrarTray()
        {
            Modelo.MostrarTray();
        }

        public static void GraficarEnPic(Chart c,string Variable)
        {
            Modelo.Identificar(Variable).GraficarEnPic(c);
        }

        internal static string TiempoActual()
        {
            return (Reloj.TiempoActual.ToString());
        }

    }
}
