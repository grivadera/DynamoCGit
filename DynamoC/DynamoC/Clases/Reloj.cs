using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public static class Reloj
    {
        static int _TiempoInicial = 0;
        static int _TiempoFinal = 0;
        static double _DT = 1;
        static double _t = 0;
        static int _tick = 0;

        public static int TiempoInicial
        {
            get
            {
                return _TiempoInicial;
            }

            set
            {
                _TiempoInicial = value;
            }
        }

        public static bool Finalizado {
            get
            {
                return(_t == TiempoFinal);
            }
        }
        public static double TiempoActual {
            get
            {
                return (_t);
            }
        }

        public static int TiempoFinal
        {
            get
            {
                return _TiempoFinal;
            }

            set
            {
                _TiempoFinal = value;
            }
        }

        internal static void PasoTemporal()
        {
            Modelo.ActualizarElementos();
            _tick++;
            tock();
            _t += _DT;
        }

        private static void tock()
        {
            Modelo.tock();
        }

        public static double DT
        {
            get
            {
                return (double.Parse(_DT.ToString()));
            }
        }

        public static void Establecer_DT(double pDT)
        {
            _DT = pDT;
        }

        public static int TickActual {

            get
            {
                return _tick;
            }

        }
    }
}
