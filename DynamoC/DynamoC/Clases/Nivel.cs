using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DynamoC.Clases
{
    public class Nivel : Elemento
    {
        
        //Constructor
        public Nivel(string Nombre, double ValorInicial)
        {
            Constructor(Nombre, ValorInicial, "Unidades");
        }

        public Nivel(string Nombre, double ValorInicial,Boolean Sistema)
        {
            _sistema = Sistema;
            Constructor(Nombre, ValorInicial,"Unidades");
        }

        public Nivel(string Nombre, double ValorInicial,string Unidades)
        {
            Constructor(Nombre, ValorInicial,Unidades);
        }

        private void Constructor(string Nombre, double ValorInicial,string Unidades)
        {
            _Nombre = Nombre;
            //if (_Nombre == "Dinero")
            //    Debug.Fail("Aqui");
            base._valorInicial = ValorInicial;
            Tipo = "Nivel";
            _unidades = Unidades;
            reset();
            _Numero = Modelo.Agregar(this);
        }

        public void EstablecerValorInicial(double ValorInicial)
        {
            base._valorInicial = ValorInicial;
            _k = _valorInicial;
            _j = _k;
        }

        //
        public void reset()
        {
            //this.j = this.k = this.initVal;            
            //data = [ { x: startTime, y: this.k} ];
            _k = _valorInicial;
            _j = _k;
            _data.x = Reloj.TiempoInicial;
            _data.y = _k;
        }

        public double k
        {
            get
            {
                return _k;
            }
            set
            {
                _k = value;
            }
        }

        public double j
        {
            get
            {
                return _j;
            }
            set
            {
                _k = value;
            }

        }


    }
}
