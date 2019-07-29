using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public class Tasa : Elemento
    {

        //Rate
        public Tasa(string Nombre)
        {
            _Nombre = Nombre;
            Tipo = "Tasa";
            _j = _k = 0;
            Modelo.Agregar(this);
        }

        internal void reset()
        {
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
