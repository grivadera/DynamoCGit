using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomC
{
    public class GVA
    {
        GNA _gna;

        Distribucion _dist;

        public enum Distribucion : int
        {
            Uniforme = 1,
            Empirica = 2,
            Exponencial = 3,
            Normal = 4,
            Lognormal = 5,
            Poisson = 6
        }

        public enum TipoGenerador
            { MarsagliaMWC,
              RandomCS };

        Dictionary<string, double> _parametros;

        private double Uniforme()
        {
            return (_parametros["a"] + (_parametros["b"] - _parametros["a"]) * _gna.SgteNumero());
        }

        private double Uniforme01()
        {
            // 0 <= u < 2^32
            uint u = _gna.SgteNumero();
            // The magic number below is 1/(2^32 + 2).
            // The result is strictly between 0 and 1.
            return (u + 1.0) * 2.328306435454494e-10;
        }

        private double Exponencial(double a)
        {
            return (a * (double)Math.Log(_gna.SgteNumero()) * (-1));
        }

        public double Normal01()
        {
            // Use Box-Muller algorithm
            double u1 = Uniforme01();
            double u2 = Uniforme01();
            double r = Math.Sqrt(-2.0 * Math.Log(u1));
            double theta = 2.0 * Math.PI * u2;
            return r * Math.Sin(theta);
        }

        // Get normal (Gaussian) random sample with specified mean and standard deviation
        public double Normal()
        {
            if (_parametros["Desviacion Estandar"] <= 0.0)
            {
                string msg = string.Format("Forma debe ser positiva. Received {0}.", _parametros["desviacionestandar"]);
                throw new ArgumentOutOfRangeException(msg);
            }
            return _parametros["Media"] + _parametros["Desviacion Estandar"] * Normal01();
        }

        public GVA(Distribucion d, double[] parametros,TipoGenerador tipogenerador,uint semilla)
        {
            _dist = d;
            _gna = new GNA(tipogenerador,semilla);

            _parametros = new Dictionary<string, double>();
            //Segun el tipo de distribucion colocar parametros
            switch (_dist)
            {
                case Distribucion.Uniforme:
                    _parametros.Add("a", parametros[0]);
                    _parametros.Add("b", parametros[1]);
                    break;
                case Distribucion.Exponencial:
                    _parametros.Add("a", parametros[0]);
                    break;
                case Distribucion.Empirica:
                    break;
                case Distribucion.Normal:
                    _parametros.Add("Media", parametros[0]);
                    _parametros.Add("Desviacion Estandar", parametros[1]);
                    break;
            }

        }

        public double Generar()
        {
            double valor = 0;
            switch (_dist)
            {
                case Distribucion.Uniforme:
                    valor = Uniforme();
                    break;
                case Distribucion.Normal:
                    valor = Normal();
                    break;
            }
            return (valor);
        }

    }
}

