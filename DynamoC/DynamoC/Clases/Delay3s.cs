using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Delay3s : Elementos
    {
        public int Agregar(Delay3 s)
        {
            return (base.Agregar(s));
        }

        internal void tock()
        {
            foreach (Delay3 n in base._elementos)
            {
                n.tick();
            }
        }

        internal void Resetear()
        {
            foreach (Delay3 n in base._elementos)
            {
                n.reset();
            }
        }

        internal void Actualizar()
        {
            //throw new NotImplementedException();
            foreach (Delay3 n in base._elementos)
            {
                n.update();
            }
        }

        internal void AgregarLista(ref System.Windows.Forms.ListBox l)
        {
            //throw new NotImplementedException();
            foreach (Delay3 n in base._elementos)
            {
                l.Items.Add(n.Nombre);
            }
        }

    }
}
