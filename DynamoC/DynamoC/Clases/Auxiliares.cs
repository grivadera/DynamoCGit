using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Auxiliares : Elementos
    {

        ArrayList _auxiliares;
        public class comparadorAux : IComparer
        {

            int IComparer.Compare(Object x, Object y)
            {
                Auxiliar Auxiliarx = (Auxiliar)x;
                Auxiliar Auxiliary = (Auxiliar)y;
                return ((Auxiliarx.Orden == Auxiliary.Orden) ? 0 : (Auxiliarx.Orden > Auxiliary.Orden) ? 1 : -1) ;
            }

        }
        private int _cantActual = 0;
        public int Agregar(Auxiliar e)
        {
            return (base.Agregar(e));
        }

        internal void Resetear()
        {
            foreach (Auxiliar a in base._elementos)
            {
                a.reset();
            }

        }

        internal void Actualizar()
        {
            foreach (Auxiliar a in _auxiliares)
            {
                //if (a.Nombre == "Ganancias antes de Intereses e Impuestos") Debug.Fail("para");
                //if (a.Nombre == "Ganancias") Debug.Fail("para");
                
                a.update();
                Debug.Print(a.Orden + " - Actualizando Auxiliar " + a.Nombre + " en tiempo " + Reloj.TiempoActual + " Valor k = " + a.k + " - j = " + a.j);
            }
        }

        internal void tock()
        {
            foreach (Auxiliar a in base._elementos)
            {
                a.tick();
            }
        }

        internal void Inicializar()
        {
            _auxiliares = new ArrayList(base._elementos.Cast<Auxiliar>()
                                                 .Where(d => d.Tipo == "Auxiliar")
                                                 .ToList());
            _auxiliares.Sort(new comparadorAux());
        }
    }
}
