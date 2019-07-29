using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace DynamoC.Clases
{
    public class Tabla : Elemento
    {
        double _imin = 10000;
        double _imax = 0;
        public enum TipoArchivo { Texto, Excel,BD };
        TipoArchivo _tipoArchivo;
        public enum UsoTabla { Numerica, Reloj };
        UsoTabla _usotabla = UsoTabla.Reloj;  // Por defecto

        public Tabla(string Nombre, ArrayList Datos, int imin, int imax)
        {
            _Nombre = Nombre;
            Tipo = "Aux";
            _tabla = Datos;
            _imin = imin;
            _imax = imax;
        }

        public Tabla(string Nombre, string Archivo, TipoArchivo tipoarch)
        {
            _Nombre = Nombre;
            Tipo = "Aux";
            _tipoArchivo = tipoarch;
            LeerDeArchivo(Archivo);
            Modelo.Agregar(this);
        }

        //Si solo se da el nombre, se supone que es la base de datos en Access
        public Tabla(string Nombre)
        {
            _Nombre = Nombre;
            Tipo = "Tabla";
            _tipoArchivo = TipoArchivo.BD;
            LeerDeBaseDeDatos();
            Modelo.Agregar(this);
        }

        public double Lookup(double valor)
        {
            if (Usotabla== UsoTabla.Reloj)
            { return ((Data) _tabla[Reloj.TickActual]).y; }

            if (valor <= _imin)
            {
                return ((Data)_tabla[0]).y;
            }
            else if (valor >= _imax)
            {
                return ((Data)_tabla[_tabla.Count - 1]).y;
            }
            else
            { //interpolar
                int i = 1;
                double valorinterpolado = 0;
                while (valor >= ((Data)_tabla[i]).x) i++;

                valorinterpolado = ((Data)_tabla[i - 1]).y + (valor - ((Data)_tabla[i - 1]).x) *
                                 ((((Data)_tabla[i]).y - ((Data)_tabla[i - 1]).y) /
                                 (((Data)_tabla[i]).x - ((Data)_tabla[i - 1]).x));
                return (valorinterpolado);
            }
        }

        private int LeerDeArchivo(string Archivo)
        {

            if (_tipoArchivo == TipoArchivo.Texto)
                LeerDeTexto(Archivo);
            else
                LeerDeExcel(Archivo);
            return 0;
        }

        private int LeerDeBaseDeDatos()
        {
            string CmdText = "SELECT * FROM [" + _Nombre  + "]";
            string BaseDatos = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Datos\\Datos.accdb";
            string ConnString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "+ BaseDatos;
            OleDbDataAdapter dA = new OleDbDataAdapter(CmdText, ConnString);
            DataSet ds = new DataSet();
            dA.Fill(ds, "["+_Nombre+"]");
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                _data.x = double.Parse(dr[0].ToString());
                _data.y = double.Parse(dr[1].ToString());
                _tabla.Add(_data);
            }
            return 0;
        }

        private int LeerDeExcel(string Archivo)
        {
            //

            Archivo = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Tablas\\" + Archivo;
            string Extension = Path.GetExtension(Archivo);
            string conStr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {" + Archivo + "}; Extended Properties = 'Excel 8.0;HDR=Yes'";
            //string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Archivo
            //+ ";Extended Properties='Excel 8.0;HDR=Yes;'";

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            //connExcel.Close();

            //Read Data from First Sheet
            //connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                _data.x = double.Parse(dr[0].ToString());
                _data.y = double.Parse(dr[1].ToString());
                _tabla.Add(_data);
            }
            connExcel.Close();

            /*
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@""+ Archivo);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                    _data.x = double.Parse(xlRange.Cells[i, 1].Value2.ToString());
                    _data.y = double.Parse(xlRange.Cells[i, 2].Value2.ToString());
                    _tabla.Add(_data);
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            */

            return (0);
        }

        private int LeerDeTexto(string Archivo)
        {
            //Ver el tipo de Archivo
            //+ (char)47 
            Archivo = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Tablas\\" + Archivo;
            //C:\Users\griva\Dropbox\Postgrados\MBA-UCASAL\TrabajoFinal\DynamoC\Fisheries\bin\Debug\..\..\Tablas
            StreamReader reader = new StreamReader(Archivo, true);
            string line;
            List<string> list = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }

            string[] datos = list.ElementAt(1).Split(' ');

            foreach (string s in list)
            {
                datos = s.Split(' ');
                _data.x = double.Parse(datos[0]);
                _data.y = double.Parse(datos[1]);
                if (_data.x > _imax) _imax = _data.x;
                if (_data.x < _imin) _imin = _data.x;
                _tabla.Add(_data);
            }

            return (0);
        }

        internal double update()
        {
            if (UpdateFn != null)
                _k = Lookup(UpdateFn());
            else
            {
                _k = Lookup(0);
            }
            return (_k);
        }

        public double k
        {
            get
            {
                return _k;
            }
        }


        public double j
        {
            get
            {
                return _j;
            }

        }

        public UsoTabla Usotabla
        {
            get
            {
                return _usotabla;
            }

            set
            {
                _usotabla = value;
            }
        }
    }
}
