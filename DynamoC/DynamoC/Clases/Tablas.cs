using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Tablas : Elementos
    {
        public int Agregar(Tabla t)
        {
            return (base.Agregar(t));
        }

        internal void Resetear()
        {
            foreach (Tabla t in base._elementos)
            {
                //t.reset();
            }
        }

        internal void Actualizar()
        {
            foreach (Tabla t in base._elementos)
            {
                t.update();
            }
        }

        internal void tock()
        {
            foreach (Tabla t in base._elementos)
            {
                t.tick();
            }
        }
    }

}

