using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    class Smooths : Elementos
    {
        public int Agregar(Smooth s)
        {
            return (base.Agregar(s));
        }

        internal void tock()
        {
            foreach (Smooth n in base._elementos)
            {
                n.tick();
            }
        }

        internal void Resetear()
        {
            foreach (Smooth n in base._elementos)
            {
                n.reset();
            }
        }

        internal void Actualizar()
        {
            //throw new NotImplementedException();
            foreach (Smooth n in base._elementos)
            {
                n.update();
            }
        }

        internal void AgregarLista(ref System.Windows.Forms.ListBox l)
        {
            //throw new NotImplementedException();
            foreach (Smooth n in base._elementos)
            {
                l.Items.Add(n.Nombre);
            }
        }

    }
}
