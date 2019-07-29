using DynamoC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivadasYRetrasos
{
    static class DerivadasYRetardos
    {
        
        private static Nivel Integral_de_F_de_T = new DynamoC.Clases.Nivel("Integral de F de T", 0);
        private static Tasa F_de_T = new DynamoC.Clases.Tasa("F de T");

        private static Auxiliar A = new Auxiliar("A",1);
        private static Auxiliar B = new Auxiliar("B", 10);
        private static Auxiliar C = new Auxiliar("C", 2);
        private static Auxiliar D = new Auxiliar("D", 3);

        private static Auxiliar Retraso_de_Integral_de_F_de_T = new Auxiliar("Retraso de Integral de F de T",0);
        private static Auxiliar Derivada_de_Integral_de_F_de_T = new Auxiliar("Derivada de Integral de F de T", 0);

        private static Auxiliar Error = new Auxiliar("Error", 0);
        

        public static void Correr()
        {
            
            Modelo.Nombre = "Derivadas y Retardos";
            Reloj.Establecer_DT(0.25);
            Integral_de_F_de_T.UpdateFn = () => (Integral_de_F_de_T.j + F_de_T.j * Reloj.DT);
            A.UpdateFn = () => (1);
            B.UpdateFn = () => (10);
            C.UpdateFn = () => (2);
            D.UpdateFn = () => (3);
            F_de_T.UpdateFn = () => (A.k + B.k * Math.Pow(Reloj.TiempoActual, C.k) - Math.Pow(Reloj.TiempoActual,D.k));
            Retraso_de_Integral_de_F_de_T.UpdateFn = () => (Funciones.DELAY_FIXED(Integral_de_F_de_T,Reloj.DT));
            Derivada_de_Integral_de_F_de_T.UpdateFn = () => ((Integral_de_F_de_T.j - Retraso_de_Integral_de_F_de_T.j)/Reloj.DT);
            Error.UpdateFn = () => (Reloj.TiempoActual>0 ? (Derivada_de_Integral_de_F_de_T.j-F_de_T.j)/F_de_T.j:0);
            double TiempoFinal = Modelo.Correr(0, 20);
            System.Windows.Forms.MessageBox.Show("Simulación Finalizada en Tiempo:" + TiempoFinal.ToString());
            Modelo.MostrarPanel();
            

        }



    }
}
