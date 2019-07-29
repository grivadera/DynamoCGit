using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Retrasos : Elementos
    {
        public int Agregar(Retraso e)
        {
            return (base.Agregar(e));
        }

        internal void tock()
        {
            foreach (Retraso n in base._elementos)
            {
                n.tick();
            }
        }

        internal void Resetear()
        {
            foreach (Retraso n in base._elementos)
            {
                //n.reset();
            }
        }

        internal void Actualizar()
        {
            //throw new NotImplementedException();
            foreach (Retraso n in base._elementos)
            {
                n.update();
            }
        }

        internal void AgregarLista(ref System.Windows.Forms.ListBox l)
        {
            //throw new NotImplementedException();
            foreach (Retraso n in base._elementos)
            {
                l.Items.Add(n.Nombre);
            }
        }


    }
}

