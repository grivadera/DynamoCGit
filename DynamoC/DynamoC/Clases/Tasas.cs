using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Tasas : Elementos
    {
        ArrayList _tasas = new ArrayList();

        public int Agregar(Tasa t)
        {
            return (base.Agregar(t));
        }

        internal void Resetear()
        {
            foreach (Tasa t in base._elementos)
            {
                t.reset();
            }
        }

        internal void Actualizar()
        {
            int i = 0;
            foreach (Tasa t in base._elementos)
            {
                //if (t.Nombre == "Ventas") Debug.Fail("Para");
                t.update();
                Debug.Print(i++ + " - Actualizando Tasa " + t.Nombre + " en tiempo " + Reloj.TiempoActual + " Valor k = " + t.k + " - j = " + t.j);
            }
        }

        internal void tock()
        {
            foreach (Tasa t in base._elementos)
            {
                t.tick();
            }
        }
    }
}
