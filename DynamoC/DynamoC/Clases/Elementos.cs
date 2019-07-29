using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Elementos
    {
        protected ArrayList _elementos = new ArrayList();
        private int _cantActual = 0;
        public int Agregar(Elemento e)
        {
            _elementos.Add(e);
            _cantActual++;
            return (_cantActual);
        }

    }


}
