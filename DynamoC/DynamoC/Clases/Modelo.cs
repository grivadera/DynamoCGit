using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoC.Clases
{
    public static class Modelo
    {
        private static Elementos _elementos = new Elementos();
        private static Niveles _niveles = new Niveles();
        private static Tasas _tasas = new Tasas();
        private static Auxiliares _auxiliares = new Auxiliares();
        private static Tablas _tablas = new Tablas();
        private static Retrasos _retrasos = new Retrasos();
        private static Smooths _smooths = new Smooths();
        private static Delay3s _delays = new Delay3s();
        private static Dictionary<string, Elemento> _diccionario = new Dictionary<string, Elemento>();
        private static string _Nombre = "";
        private static bool _inicializado = false;

        public static string Nombre
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

        public static bool Inicializado {
            get
            {
                return _inicializado;
            }
            set
            {
                _inicializado = value;
            }
        }

        internal static void CargarElementosEnLista(ref ListBox lstElementos)
        {            
            foreach (KeyValuePair<string, Elemento> e in _diccionario)
            {
                lstElementos.Items.Add(e.Key);
            }
        }

        internal static void CargarElementosEnLista(ref ListBox lstElementos,string Tipo)
        {

            //Niveles
            //Tasas
            //Auxiliares
            //Tablas
            //var orderedRankings = _diccionario.OrderBy(key => key.Value);
            lstElementos.Items.Clear();
            foreach (KeyValuePair<string, Elemento> e in _diccionario)
            {
                if (e.Value.Tipo==Tipo)
                    lstElementos.Items.Add(e.Key);
            }
        }


        public static void CargarTrayectoriasEnTabla(ref DataGridView dg, string Tipo,int Decimales)
        {

            //Niveles
            //Tasas
            //Auxiliares
            //Tablas
            //var orderedRankings = _diccionario.OrderBy(key => key.Value);
            //Agregar columnas
            dg.Columns.Clear();
            dg.Columns.Add("Variable", "Variable");
            dg.Columns.Add("Tipo", "Tipo");
            dg.Columns.Add("Orden", "Orden");

            string CadReemp = "{0:0." + string.Concat(Enumerable.Repeat("0", 2)) + "}";

            for (int j = 0; j < Reloj.TiempoActual; j++)
            {
                dg.Columns.Add("T" + j.ToString(), "T. " + j.ToString());
                dg.Columns[j + 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dg.Rows.Clear();
            int i = 0;
            foreach (KeyValuePair<string, Elemento> e in _diccionario)
            {
                //if (e.Value.Tipo == Tipo)
                //lstElementos.Items.Add(e.Key);
                dg.Rows.Add(e.Value.Nombre, e.Value.Tipo, e.Value.Orden);                
                for (int j=0;j<Reloj.TiempoActual;j++)
                {
                    dg.Rows[i].Cells[j+3].Value = String.Format(CadReemp, Double.Parse(e.Value.Valor(j).ToString()));
                }
                i++;
            }
        }

        public static void MostrarPanel()
        {
            FrmPanelVariables f = new FrmPanelVariables();
            f.Show();
        }

        internal static void ActualizarElementos()
        {
            ActualizarNiveles();
            ActualizarTablas();
            ActualizarAuxiliares();
            ActualizarTasas();
            ActualizarSmooths();
            ActualizarDelays();
        }

        internal static void tock()
        {
            _niveles.tock();
            _auxiliares.tock();
            _tasas.tock();
            _smooths.tock();
        }

        #region Actualizar Elementos
        private static void ActualizarTasas()
        {
            _tasas.Actualizar();
        }

        private static void ActualizarAuxiliares()
        {
            _auxiliares.Actualizar();
        }

        private static void ActualizarNiveles()
        {
            _niveles.Actualizar();
        }

        private static void ActualizarTablas()
        {
            _tablas.Actualizar();
        }

        private static void ActualizarSmooths()
        {
            _smooths.Actualizar();
        }

        private static void ActualizarDelays()
        {
            _delays.Actualizar();
        }

        #endregion

        #region Agregar Elementos

        internal static void Agregar(Elemento e)
        {
            _elementos.Agregar(e);
            
        }


        internal static int Agregar(Nivel e)
        {
            _diccionario.Add(e.Nombre, e);
            return(_niveles.Agregar(e));
        }

        internal static void Agregar(Tasa tasa)
        {
            _diccionario.Add(tasa.Nombre, tasa);
            _tasas.Agregar(tasa);
        }

        internal static void Agregar(Auxiliar auxiliar)
        {
            _diccionario.Add(auxiliar.Nombre, auxiliar);
            _auxiliares.Agregar(auxiliar);
        }

        internal static void Agregar(Tabla tabla)
        {
            _diccionario.Add(tabla.Nombre, tabla);
            _tablas.Agregar(tabla);
        }

        internal static int Agregar(Retraso e)
        {
            _diccionario.Add(e.Nombre, e);
            return(_retrasos.Agregar(e));
        }

        internal static int Agregar(Smooth e)
        {
            _diccionario.Add(e.Nombre, e);
            return (_smooths.Agregar(e));
        }

        internal static int Agregar(Delay3 e)
        {
            _diccionario.Add(e.Nombre, e);
            return (_delays.Agregar(e));
        }
        #endregion

        public static Elemento Identificar(string nombre)
        {
            return (_diccionario[nombre]);
        }

        public static double Correr()
        {
            Resetear();
            Inicializar();
            /*
              for (var i = 1 ; i <= 100 ; i++) {
                warmupAuxen();
                warmupRates();
                tock();
                }
             */

            while (!Reloj.Finalizado)
            {
                Reloj.PasoTemporal();
            }
            return Reloj.TiempoActual;
        }

        public static double UnPaso()
        {
            Reloj.PasoTemporal();
            return Reloj.TiempoActual;
        }

        public static double Correr(int TiempoInicial,int TiempoFinal)
        {
            Reloj.TiempoInicial = TiempoInicial;
            Reloj.TiempoFinal = TiempoFinal;
            return (Correr());
        }

        private static void Inicializar()
        {
            //throw new NotImplementedException();
        }

        private static void Resetear()
        {
            _niveles.Resetear();
            _tasas.Resetear();
            _auxiliares.Resetear();
            _smooths.Resetear();
        }

        public static void Crear(string Nombre, double DT)
        {
            Modelo.Nombre = Nombre;
            Reloj.Establecer_DT(1);
            _auxiliares.Inicializar();
        }

        public static double ObtenerValor(string variable)
        {
            Elemento ElRet;
            _diccionario.TryGetValue(variable, out ElRet);
            return (ElRet.ValorActual());
        }

        public static void MostrarTray()
        {
            FrmTrayectorias t = new FrmTrayectorias();
            t.Mostrar();
        }
    }
}
