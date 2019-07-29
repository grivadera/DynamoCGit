using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamoC.Clases;

namespace PruebasRetardos
{
    class PruebasRetardos
    {

        //private static int DELAY_TIME = 10;
        private static Tasa Entrada = new Tasa("Entrada");
        private static Delay3 Retraso = new Delay3("Retraso", 5, Entrada);
        //private static Auxiliar INPut = new Auxiliar("INPut", 0);
        //private static Smooth Smoothed_output = new Smooth("Smoothed_output", DELAY_TIME,3,INPut);

        public static void Correr()
        {

            Modelo.Nombre = "Derivadas y Retardos";
            Reloj.Establecer_DT(1);

            //INPut.UpdateFn = () => (100+Funciones.STEP(20,10));
            //INPut.UpdateFn = () => (Funciones.PULSE(10,0,9999));
            Entrada.UpdateFn = () => (Funciones.PULSE(10, 0, 9999));

            //Smoothed_output.InitFn = () => (INPut.k);
            //Smoothed_output.UpdateFn = () => (INPut.k);
            //Smoothed_output.Inicializar();
            double TiempoFinal = Modelo.Correr(0, 100);
            System.Windows.Forms.MessageBox.Show("Simulación Finalizada en Tiempo:" + TiempoFinal.ToString());
            Modelo.MostrarPanel();


        }



    }
}
