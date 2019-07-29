using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoC.Clases
{
    public class Delay3 : Elemento
    {
        private double _delay = 1;
        private bool _primerallamada = true;
        private double _retrasosporetapa;
        private double alfa_j = 0;
        private double alfa_k = 0;
        private double beta_j = 0;
        private double beta_k = 0;
        private double gama_j = 0;
        private double gama_k = 0;
        private Tasa _entrada;

        public Delay3(string Nombre, double delay,Tasa Entrada)
        {
            _Nombre = Nombre;
            _delay = delay;
            _entrada = Entrada;
            _retrasosporetapa = _delay / 3;
            _j = 0;
            _k = 0;
            Modelo.Agregar(this);
        }

        public void Inicializar()
        {
            //_entrada_k = _ValorInicial;
            _k = _entrada.k;
            _j = _k;
            alfa_j = _entrada.j;
            alfa_k = _entrada.j;
            beta_j = _entrada.j;
            beta_k = _entrada.j;
            gama_j = _entrada.j;
            gama_k = _entrada.j;

        }

        public void reset()
        {
            _primerallamada = true;
            _k = 0;
            _j = _k;
            alfa_j = 0;
            alfa_k = 0;
            beta_j = 0;
            beta_k = 0;
            gama_j = 0;
            gama_k = 0;

        }

        public new double update()
        {
            if (_primerallamada)
            {
                _j = _entrada.k;
                _k = _j;
                alfa_j = _j;
                alfa_k = _j;
                beta_j = _j;
                beta_k = _j;
                gama_j = _j;
                gama_k = _j; 
                _primerallamada = false;             
            }
            else
            {
                alfa_k = alfa_j + Reloj.DT * (_entrada.j - alfa_j) / _retrasosporetapa;
                beta_k = beta_j + Reloj.DT * (alfa_j - beta_j) / _retrasosporetapa;
                gama_k = gama_j + Reloj.DT * (beta_j - gama_j) / _retrasosporetapa;
                alfa_j = alfa_k;
                beta_j = beta_k;
                gama_j = gama_k;
                _k = gama_k;
            }
            _data.x = Reloj.TiempoActual;
            _data.y = _k;
            _tabla.Add(_data);
            return _k;
        }


    }
}
