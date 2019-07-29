using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public class Dependencias
    {
        protected ArrayList _dependencias = new ArrayList();
        private int _cantActual = 0;
        public int Agregar(Elemento e)
        {
            _dependencias.Add(e);
            _cantActual++;
            return (_cantActual);
        }

    }
}
