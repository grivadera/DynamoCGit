using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamoC.Clases;

namespace Fisheries
{
    static class Fisheries
    {
        /* Fish Model Basic 
        private static Nivel Fish = new Nivel("Fish", 200);
        private static Tasa Reproduccion = new Tasa("Reproduccion");
        private static Tabla Tasa_Reproduccion = new Tabla("Tasa_Reproduccion", "TasaReproduccion.dat");
        */

        private static Nivel Fish = new Nivel("Fish", 200);
        private static Tasa Reproduccion = new Tasa("Reproduccion");
        private static Tasa Extraccion = new Tasa("Extraccion");
        private static Tabla Tasa_Reproduccion = new Tabla("Tasa_Reproduccion", "TasaReproduccion.dat");
        private static Auxiliar Tasa_Extraccion = new Auxiliar("Tasa_Extraccion", 0.03f);
        private static Auxiliar Precio = new Auxiliar("Precio", 5.0f);
        private static Auxiliar Ingresos = new Auxiliar("Ingresos",0);
        public static void Correr()
        {
            /* Fish Model Basic 
            Modelo.Nombre = "Fisheries";
            Fish.UpdateFn = () => (Fish.j + Reloj.dtf * Reproduccion.j);
            Tasa_Reproduccion.UpdateFn = () => (0.05f);//(Fish.k);
            Reproduccion.UpdateFn = () => (Fish.k * Tasa_Reproduccion.k);
            
            float TiempoFinal = Modelo.Correr(0, 20);
            System.Windows.Forms.MessageBox.Show("Simulación Finalizada en Tiempo:"+TiempoFinal.ToString());
            Modelo.MostrarPanel();
            */

            Modelo.Nombre = "Fisheries Extendido";
            Fish.UpdateFn = () => (Fish.j + (Reproduccion.j-Extraccion.j)* Reloj.dtf);
            Tasa_Reproduccion.UpdateFn = () => (Fish.k);
            Tasa_Extraccion.UpdateFn = () => (0.03f);
            Precio.UpdateFn = () => (5.0f);
            Ingresos.UpdateFn = () => (Extraccion.k * Precio.k);
            Reproduccion.UpdateFn = () => (Fish.k * Tasa_Reproduccion.k);
            Extraccion.UpdateFn = () => (Fish.k * Tasa_Extraccion.k);

            double TiempoFinal = Modelo.Correr(0, 20);
            System.Windows.Forms.MessageBox.Show("Simulación Finalizada en Tiempo:" + TiempoFinal.ToString());
            Modelo.MostrarPanel();


        }

    }
}
