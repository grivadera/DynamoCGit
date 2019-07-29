using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public class Smooth : Elemento
    {

        /*
            Tercer Orden:
            LV2=INTEG((LV1-LV2)/DL,input)
            LV1=INTEG((IN-LV1)/DL,input)
            DL=delay time/3
            
         */
        //Variables para emular delays para 3 orden
        Nivel _level;
        Nivel _level1;
        Nivel _level2;
        Tasa _flow;
        Tasa _flow2;
        Tasa _flow3;
        double _DL = 0;

        /// <summary>
        /// 
        /// </summary>

        double _Delay = 0;
        Boolean _PrimeraLlamada = true;
        Auxiliar _aux;
        int _orden = 1;
        public Smooth(string Nombre,double Delay,int Orden,Auxiliar Aux)
        {
            _Nombre = Nombre;
            _Delay = Delay;
            Tipo = "Smooth";
            Unidades = "Sin Dimensión";
            _orden = Orden;
            //Nivel _TheInput = new Nivel("TheInput-"+_Nombre,0); 
            _valorInicial = 0;// ValorInicial;
            _aux = Aux;
            _DL = _Delay / Orden;
            if (_orden==3)
            {
                //Crear Stocks Auxiliares
                //Nivel
                
                _level = new Nivel("_level_"+_Nombre,_valorInicial);
                _level.UpdateFn = () => (_level.j + Reloj.DT * _flow3.j);
                _flow3 = new Tasa("_flow3" + _Nombre);
                _flow3.UpdateFn = () => (_level2.k - _level.k) / _DL;

                //Nivel 1

                _level1 = new Nivel("_level1_" + _Nombre, 0);
                _level1.UpdateFn = () => (_level1.j + Reloj.DT * _flow.j);
                _flow = new Tasa("_flow" + _Nombre);
                _flow.UpdateFn = () => (Aux.k - _level1.k) / _DL;

                //Nivel 2
                _level2 = new Nivel("_level2_" + _Nombre, _level.k);
                _level2.UpdateFn = () => (_level2.j + Reloj.DT * _flow2.j);
                _flow2 = new Tasa("_flow2" + _Nombre);
                _flow2.UpdateFn = () => (_level1.k - _level2.k) / _DL;
                
            }
            
            _Numero = Modelo.Agregar(this);            
        }

        /*
        public void Inicializar()
        {
            if (InitFn!=null)
                _TheInput_j = this.InitFn();
            _TheInput_k = _ValorInicial;
            _k = _TheInput_k;
            _j = _k;
        }
        */

        public void reset()
        {
            //this.j = this.k = this.initVal;            
            //data = [ { x: startTime, y: this.k} ];
            _k = _valorInicial;
            _j = _k;
            _data.x = Reloj.TiempoInicial;
            _data.y = _k;
        }
        /*
        public void reset()
        {
            _PrimeraLlamada = true;
            _k = 0;
            _j = _k;
        }
        */

        public new double update()
        {
            /*
            if (_PrimeraLlamada)
            {
                _TheInput_k = _ValorInicial;
                _k = _TheInput_k;
                _j = _k;
                _PrimeraLlamada = false;
                return _k;
            }
            else
            {

                _TheInput_j = _aux.j;
                _k = _j + Reloj.DT * (_TheInput_j - _j) / _Delay;
                AgregarValorATabla(_k);
                return _k;
            }
            */
            if (_orden==1)
                { 
                    if (_PrimeraLlamada)
                        {
                            _k = _aux.k;
                            _j = _k;
                            _PrimeraLlamada = false;
                        }
                    else
                        { 
                            _k = (_aux.j - _j)/_Delay+_j;            
                        }
                }
            else
            {
                //Orden mayor
                /*
                    Tercer Orden:
                    LV2=INTEG((LV1-LV2)/DL,input)
                    LV1=INTEG((IN-LV1)/DL,input)
                    DL=delay time/3

                 */
                if (_PrimeraLlamada)
                {
                    _level.k = _aux.k;
                    _k = _aux.k;
                    _PrimeraLlamada = false;
                }
                else
                {
                    _k = _level.k;
                }
            }

            AgregarValorATabla(_k);
            return _k;
        }

    }
}
