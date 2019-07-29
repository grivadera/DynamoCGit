using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Niveles : Elementos
    {
        public int Agregar(Nivel e)
        {
            return (base.Agregar(e));           
        }

        internal void tock()
        {
            foreach(Nivel n in base._elementos)
            {
                n.tick();
            }
        }

        internal void Resetear()
        {
            foreach (Nivel n in base._elementos)
            {
                n.reset();
            }
        }

        internal void Actualizar()
        {
            //throw new NotImplementedException();
            
            int i = 0;
            foreach (Nivel n in base._elementos)
            {
                //if (n.Nombre == "Inventario") Debug.Fail("ok");        
                n.update();
                Debug.Print(i++ + " - Actualizando Stock " + n.Nombre + " en tiempo " + Reloj.TiempoActual + " Valor k = " + n.k + " - j = " + n.j);
            }
        }

        internal void AgregarLista(ref System.Windows.Forms.ListBox l)
        {
            //throw new NotImplementedException();
            foreach (Nivel n in base._elementos)
            {
               l.Items.Add(n.Nombre);
            }
        }


    }
}
