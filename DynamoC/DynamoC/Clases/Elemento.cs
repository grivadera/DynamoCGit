using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DynamoC.Clases
{
    public class Elemento
    {
        protected string _Nombre = "";
        protected int _Numero = 0;
        private string _tipo = "General";
        protected string _unidades = "Sin Medida";
        protected ArrayList _tabla = new ArrayList();
        protected Data _data = new Data();
        protected double _valorInicial = 0;
        protected double _k = 0;
        protected double _j = 0;
        protected double _valorActfn = 0;
        private bool plotThisVar=true;
        protected Dependencias _dependencias;
        protected bool _sistema = false;
        private int _orden = 0;
        public Func<double> UpdateFn;
        public Func<double> InitFn;
        private string _Ecuacion = "";

        protected struct Data
        {
            public double x;
            public double y;
        }

        protected Elemento()
        {
            _data.x = 0;
            _data.y = 0;
            _dependencias = new Dependencias();
        }

        public void GraficarEnPic(Chart chart1)
        {
            chart1.Series.Clear(); //ensure that the chart is empty
            chart1.Series.Add("Series0");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Legends.Clear();
            foreach (Data a in _tabla)
            {
                chart1.Series[0].Points.AddXY(a.x, a.y);

            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Unidades
        {
            get
            {
                return _unidades;
            }

            set
            {
                _unidades = value;
            }
        }

        public int Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                _orden = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        public string Ecuacion
        {
            get
            {
                return _Ecuacion;
            }

            set
            {
                _Ecuacion = value;
            }
        }

        protected void warmup()
        {
            _k = _valorActfn;
        }

        //internal double UpdateFn()
        //{
        //    return (0);
        //}

        //internal double delegate UpdateFn();

        internal double update()
        {
            if (UpdateFn!=null)
                _k = UpdateFn();//_valorActfn;//UpdateFn();
            else
                _k = _valorInicial;

            if (plotThisVar)
            {
                _data.x = Reloj.TiempoActual;
                _data.y = _k;
                _tabla.Add(_data);
                //this.data.push( { x: t, y: this.k} );
                //this.plot();
            }
            return _k;
        }

        public double Valor(int Indice)
        {
            //Obtiene el valor anterior
            if (_tabla.Count > 0)
                return (((Data)_tabla[Indice]).y);
            else
                return (0);
        }

        public double ValorActual()
        {
            return _k;
        }

        public void AgregarValorATabla(double y)
        {
            _data.x = Reloj.TiempoActual;
            _data.y = _k;
            _tabla.Add(_data);
        }

        internal void tick()
        {
            //Tick de tiempo
            _j = _k;
        }

        public void CargarTablaEnGrid(DataGridView d)
        {
            d.Rows.Clear();
            foreach(Data a in _tabla)
            {
                d.Rows.Add(a.x, a.y);
                //d[i, 1].Value = a.x;
                //d[i, 2].Value = a.y;
                //i++;
            }
        }
    }
}