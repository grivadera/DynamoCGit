using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomC
{
    internal class GNA
    {
        //internal enum TipoGenerador {  MarsagliaMWC, RandomCS };
        GVA.TipoGenerador _tipo;
        SimpleRNG _mwc;
        Random _r;
        uint _semilla = 0;

        public uint Semilla
        {
            get
            {
                return _semilla;
            }
            set
            {
                _semilla = value;
            }
        }
        internal GNA(GVA.TipoGenerador Tipo,uint semilla)
        {
            _tipo = Tipo;
            switch (_tipo) 
            {
                case GVA.TipoGenerador.MarsagliaMWC:
                    {
                        _mwc = new SimpleRNG();
                        _semilla = semilla;
                        break;
                    }
                case GVA.TipoGenerador.RandomCS:
                    {
                        _r = new Random();                        
                        break;                       
                    }

            }
        }

        public uint SgteNumero()
        {
            uint res = 0;
            switch (_tipo)
            {
                case GVA.TipoGenerador.MarsagliaMWC:
                    {
                        res = _mwc.GetUint();
                        break;
                    }
                case GVA.TipoGenerador.RandomCS:
                    {
                        res=(uint) _r.Next();
                        break;
                    }

            }
            return res;
        }


    }
}
