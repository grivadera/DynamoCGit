using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public static class Funciones
    {
        static int _pasoDelay = 0;

        public static double DELAY_FIXED(Elemento e,double Duracion)
        {
            //Funcion igual a DELAY de Stella y a DELAY FIXED de Vensim
            //Returns the value of the input delayed by the delay time.
            //The initial value is the value of the variable on the left - hand side of the equation at the start of the simulation.  
            //The delay time can be an expression, but only its initial value is used.

            //DELAY(<input>,<delay duration>[,<initial>])
            //if (Inicial > 0) input = Inicial;
            //return (Input / Duracion);

            // Obtener si existe lo ingresado hace Duracion tiempo
            // 
            if (Reloj.TiempoActual > Duracion)
            //return e.Valor(int.Parse((Reloj.TickActual - Duracion).ToString()));
            {   _pasoDelay++; 
                return e.Valor(_pasoDelay);
            }
            else
                return 0;
        }

        public static double INTEG(Nivel nivel,Tasa tasa)
        {
            //Aqui se pueden usar los diferentes métodos de integración
            //Euler . Por defecto
            //Rugger-Kutta 2
            //Rugger-Kutta 4
            return (nivel.j + tasa.k * Reloj.DT);

        }

        public static double SMOOTH(Nivel nivel, Tasa tasa,double demora)
        {
            //nivel : Lado izquierdo
            //expected demand=SMOOTH(demand, time to form expectations)

            //This equation is exactly the same as:
            //expected demand = INTEG((demand - expected demand) / time to form expectations,demand)

            //nivel.k = 1;
            return (0);
        }

        public static double STEP(double height, double step_time)
        {
            return ((Reloj.TiempoActual >= step_time) ? height : 0);
        }

        public static double PULSE(double volume,double first_pulse, double interval)
        {
            if (Reloj.TiempoActual == first_pulse)
                return (volume / Reloj.DT);
            else
                return (0);
        }

        public static double MIN(double valor1, double valor2)
        {
            if (valor1 < valor2) return valor1; else return valor2;
        }

        public static double MAX(double valor1, double valor2)
        {
            if (valor1 > valor2) return valor1; else return valor2;
        }

        public static double RAMP(double slope, double time=0)
        {
            double Valor = 0;
            if (time==0)
            {
                Valor = slope * Reloj.TiempoActual;
            }
            else
            {
                if (Reloj.TiempoActual == time)
                {
                    Valor = slope * Reloj.TiempoActual;
                }
            }
            return Valor;
        }
    }
}
