using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public class Auxiliar : Elemento
    {
        public Auxiliar(string Nombre,double ValorInicial,int Orden)
        {
            _Nombre = Nombre;
            base._valorInicial = ValorInicial;
            Tipo = "Auxiliar";
            base.Orden = Orden;
            _j = _k;
            Modelo.Agregar(this);
        }

        internal void reset()
        {
            _k = _valorInicial;
            _j = _k;
            _data.x = 0;
            _data.y = 0;
        }

        public double k
        {
            get
            {
                return _k;
            }
        }

        public double j
        {
            get
            {
                return _j;
            }

        }

    }
}
