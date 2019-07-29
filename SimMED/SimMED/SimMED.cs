using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamoC.Clases;
using RandomC;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimMED
{
    class SimMED
    {

        //The financial and accounting variables in the model are as follows:
        private static Nivel Valor_Esperado_Pagos = new Nivel("Valor Esperado de Pagos", 0, "Pesos"); //Payoff PV = the present value of the total payoffs to the shareholders (Stock)
        private static Nivel Acciones = new Nivel("Acciones Contables", 0); //Equity = accounting equity (Stock)
        private static Auxiliar Activos_Menos_Deudas = new Auxiliar("Activos Menos Deudas", 0,22); //Assets less Debt = must be equal to the Equity (Auxiliary)
        private static Auxiliar Valor_Esperado_Total = new Auxiliar("Valor Esperado Total", 0,23); //Total PV = Payoff PV + Equity/(1+ rS )^t
        private static Nivel Ingresos_Netos = new Nivel("Ingresos Netos", 0); //Net Income = the net profit after taxes and dividends (Stock)
        private static Tasa Dividendos = new Tasa("Dividendos");//Dividends = dividends paid to the shareholders (Flow)
        private static Tasa Valor_Presente_Dividendos = new Tasa("Valor Presente de Dividendos"); //PV Div = present value of the dividends paid to the shareholders(Flow)
        private static Tasa Retencion = new Tasa("Retencion"); //Retention = amount of net income retained, increasing the equity (Flow)
        private static Tabla Ratio_Retencion = new Tabla("Ratio de Retencion"); //Retention Ratio = a ratio reflecting the dividend policy (Decision)
        private static Auxiliar Ratio_Deuda_Acciones = new Auxiliar("Ratio Deuda Acciones", 0,12);//Debt to Equity Ratio = auxiliary variable to help make better financing decisions
        private static double rS = 0.20f; //new Auxiliar("Factor de Descuento", 0); //Exogena discount factor : cost of equity capital according to CAPM formula (Exogenous)
        private static double rB = 0.01f; //new Auxiliar("Costo de Deuda", 0.01);//rB = cost of debt(Exogenous)
        private static Auxiliar Tasa_Interes_Continua = new Auxiliar("Tasa de Interes Continua", 0,15);//Continuous Interest Rate = continuously compounded interest rate[exp(rB) – 1]
        private static Tasa Ganancias_Antes_Impuestos = new Tasa("Ganancias Antes Impuestos");//EBT = Earnings before Taxes (Flow)
        private static Auxiliar Ganancias_Antes_Int_E_Imp = new Auxiliar("Ganancias antes de Intereses e Impuestos", 0,21);//EBIT = Earnings before Interest and Taxes
        public static double Precio = 100; //Price = average price for a unit of the product(Exogenous)
        private static Auxiliar Ganancias = new Auxiliar("Ganancias", 0,5);//Revenue = Sales * Price
        private static Auxiliar Ganancias_Netas = new Auxiliar("Ganancias Netas", 0,17);//Gross Profit = Revenue – Variable Costs
        private static Auxiliar Costos_Variables = new Auxiliar("Costos Variables", 0,9);//Variable Costs = Unit Cost * Sales
        private static Auxiliar Costo_Unitario = new Auxiliar("Costo Unitario", 0,8);//Unit Costs = marginal cost of producing one more product. (Inevitable + Controllable Costs)
        private static double Costos_Inevitables = 13.17; //= new Auxiliar("Costos Inevitables", 0);//Inevitable Costs = unavoidable unit costs (Exogenous)
        private static Auxiliar Costos_Controlables = new Auxiliar("Costos Controlables", 0,7);//Controllable Costs = unit costs that can be reduced through productivity
        private static double Costos_Adm_Fijos = 27; //new Auxiliar("Costos Administrativos Fijos", 0);//Fixed Administrative Costs = unavoidable fixed costs due to administration. (Exogenous)
        private static Auxiliar Expensas_Generales = new Auxiliar("Expensas Generales", 0,20);//General Expenses = Fixed Administrative Costs + Inventory Costs + All Budgets
        private static Tasa Impuestos = new Tasa("Impuestos");//Tax = tax paid out of Net Income(Flow)
        private static double Tasa_Impuestos = 0.34; //= new Auxiliar("Tasa de Impuestos", 0);//Tax Rate = tax rate according to the law (Flow)
        private static Nivel Deuda = new Nivel("Deuda", 1017);//Debt = total accumulated debt (Stock) Originariamente 1017
        private static Tasa Interes = new Tasa("Interes");//Interest = the interest associated with debts (Flow)
        private static Tasa Pago_de_Interes = new Tasa("Pago de Interes");//Interest Payment = amount of interest paid for debt(Flow)
        private static Auxiliar Emision_de_Deuda = new Auxiliar("Emision de Deuda", 0,18);//Debt Issue = amount of money borrowed according to the financing policy (Decision)
        private static Nivel Dinero = new Nivel("Dinero", 707);//Cash = total amount of cash at hand (Stock)
        private static Auxiliar Dinero_de_Prestamo = new Auxiliar("Dinero de Prestamo", 0,19);//Cash Borrowed = Debt issue + Interest - Interest Payment
        private static Tasa Dinero_Anadido = new Tasa("Dinero Añadido");//Cash Added = Depreciation + EBT + Cash Borrowed(Flow)
        private static Tasa Pagos = new Tasa("Pagos");//Payments = the amount of cash paid (Flow)
        private static Tasa Inversiones = new Tasa("Inversiones");//Investment = the amount of cash invested(Flow)
        private static Nivel Activos_Fijos = new Nivel("Activos Fijos",1035); // Fixed Asset = total investments accumulated(Stock)
        private static Tasa Depreciacion = new Tasa("Depreciacion");//Depreciation = amount of assets being depreciated(Flow)
        private static double TasaDepreciacion = 0.05;//Depreciation Rate = rate of depreciation(Exogenous)
        private static Tabla Capital_de_Inversion = new Tabla("Capital de Inversion");//Capital Budgeting = a policy determining how much to invest (Decision)
        private static Auxiliar Beneficio_Bruto = new Auxiliar("Beneficio Bruto",0,10); //Gross Profit

        //The operational variables of the model are as follows:
        private static Nivel Inventario = new Nivel("Inventario", 1000);//Inventory = total amount of product at hand (Stock)
        private static Tasa Ventas = new Tasa("Ventas");//Sales = amount of product sold (Flow)
        private static Auxiliar Costo_de_Inventario = new Auxiliar("Costo de Inventario", 0,14);//Inventory Costs = total cost of keeping inventories
        private static Tasa Produccion = new Tasa("Produccion");//Production = rate of producing the product(Decision & Flow)
        private static Auxiliar Capacidad_Produccion = new Auxiliar("Capacidad de Produccion",0,11);//Production Capacity = maximum rate of production
        private static Auxiliar Productividad = new Auxiliar("Productividad", 0,6);//Productivity: To affect Quality Improvement, Controllable Costs and Production Capacity
        private static Nivel Calidad = new Nivel("Calidad", 100);//Quality = quality of the product(Stock)
        private static Auxiliar Calidad_Estandar = new Auxiliar("Calidad Estandar", 0,13);//Standard Quality = average quality of the competitor’s products(Exogenous)
        private static Tasa Mejora = new Tasa("Mejora");//Improvement = amount of increase in the quality of the product (Flow)
        private static Auxiliar Presupuesto_Procesos = new Auxiliar("Presupuesto de Procesos", 0,24);//Process Budget = amount of money spent to improve quality (Decision)
        private static Nivel Tecnologia = new Nivel("Tecnologia", 1);//Techno = the total knowledge and technology accumulated through research (Stock)
        private static Tasa Investigacion_Y_Desarrollo = new Tasa("Investigacion Y Desarrollo");//R&D = the rate of knowledge being acquired (Flow)
        public static double Efectividad_Inv_Des = (1f / 1000f); //new Auxiliar("Efectividad de Investigación y Desarrollo", 0);//R&D Effectiveness = the effectiveness of R&D Budget (Exogenous)
        public static double Presupuesto_Inv_Des = 50; //new Auxiliar("Presupuesto para Investigación y Desarrollo", 0);//R&D Budget = the amount of money spent to improve technology(Decision)

        //The customer aspect of the model includes the following variables:

        private static Nivel Tamanio_Mercado = new Nivel("Tamaño del Mercado", 113.1, "Pesos");//Market Size = total demand of the product (Stock)
        private static Tasa Sustitucion = new Tasa("Sustitucion");//Substitution = the rate of decrease in the demand(Flow & Exogenous)//
        private static Tasa IncrementoDemanda = new Tasa("Incremento de Demanda");//Increase in Demand = the rate of increase in the demand (Flow & Exogenous)
        private static Nivel Porcion_del_Mercado = new Nivel("Porcion del Mercado", 20, "Pesos");//Market Share = the portion of the market available to us (Stock)
        private static Tasa Marketing = new Tasa("Marketing");//Marketing = the rate of increase in the Market Share due to advertising (Flow)
        private static Tasa Competencia = new Tasa("Competencia");//Competition = rate of decrease in Market Share due to competitors (Flow)
        public static double Agresividad = 0.05f; //new Auxiliar("Agresividad de Competidores", 0,18);//Aggressiveness = the strength of the competitors(Exogenous)
        private static Tasa Satisfaccion = new Tasa("Satisfaccion");//Satisfaction = rate of change in the Market Share due to the relative quality (Flow)
        private static Auxiliar Presupuesto_Publicidad = new Auxiliar("Presupuesto de Publicidad", 0,16);//Advertise Budget = amount of money spent on advertising (Decision)

        //The organizational variables are as follows:

        private static Nivel Habilidades_RH = new Nivel("Habilidades RH", 100);//HR Skills = the total skills of the human resource(Stock)
        private static Tasa Perdida_de_Habilidad = new Tasa("Perdida de Habilidad");//Skills Lost = the rate of forgetting skills(Flow)
        private static double Tasa_Reemplazo = 1f / 10f; //new Auxiliar("Tasa Reemplazo", 0);//Replacement Rate = the degree of forgetfulness of the employees (Exogenous)
        private static Tasa Entrenamiento = new Tasa("Entrenamiento");//Training = the rate of increase in personnel skills (Flow)
        private static Auxiliar Presupuesto_Entrenamiento = new Auxiliar("Presupuesto de Entrenamiento", 0,4);//Training Budget = the amount of money spent on increasing skills(Decision)
        private static double Efectividad_Entrenamiento = 1f / 100f; //new Auxiliar("Efectividad de Entrenamiento", 0);//Training Effectiveness = the effectiveness of the training budget (Exogenous)
        private static Nivel Motivacion_RH = new Nivel("Motivacion Recursos Humanos", 1);//HR Motive = the total accumulated motivation of the employees (Stock)
        private static Tasa Motivacion = new Tasa("Motivacion");//Motivation = the rate of increase in personnel motivation(Flow)
        private static double Presupuesto_Compensacion = 50; //new Auxiliar("Presupuesto de Compensacion", 0);//Compensation Budget = the amount of money spent to increase motivation (Decision)
        private static double Efectividad_Compensacion = 1f / 50f; //new Auxiliar("Efectividad de Compensacion", 0);//Compensation Effectiveness = effectiveness of the money spent on motivation (Exogenous)
        private static Tasa FaltaMotivacion = new Tasa("Falta de Motivacion");//Depression = the amount of decrease in personnel motivation (Flow)
        private static double Tasa_FaltaMotivacion = 0.05f;//new Auxiliar("Tasa de Falta de Motivacion", 0);//Depression Rate = the employees’ propensity to lose motivation (Exogenous)
        

        //Tablas
        private static Tabla ExpInf = new Tabla("ExpInf");
        //private static Tabla DemandaPrecio = new Tabla("DemandaPrecio");

        //Variables
        
       public SimMED()
        {
            Inicializar();
        }

        private static void Inicializar()
        {
            //Seteos
            Modelo.Crear("Simulador de Mediana Empresa", 1);

            Valor_Esperado_Total.UpdateFn = () => (Valor_Esperado_Pagos.k + Activos_Menos_Deudas.k / Math.Pow(1 + rS,Reloj.TiempoActual)); //Total_PV = Payoff__PV + Asset_less_Debt / (1 + rS) ^ TIME
            Valor_Esperado_Total.Ecuacion = "Valor_Esperado_Pagos.k + Activos_Menos_Deudas.k / Math.Pow(1 + rS,Reloj.TiempoActual)";

            Valor_Esperado_Pagos.UpdateFn = () => (Valor_Esperado_Pagos.j + (Valor_Presente_Dividendos.j * Reloj.DT)); //Nivel
            Valor_Esperado_Pagos.Ecuacion = "Valor_Presente_Dividendos * Reloj.DT";

            Valor_Presente_Dividendos.UpdateFn = () => (Dividendos.k/ (Math.Pow(1 + rS,Reloj.TiempoActual))); //Ingreso a Valor Esperado de Pagos
            Valor_Presente_Dividendos.Ecuacion = "Dividendos/ (Math.Pow(1 + rS,Reloj.TiempoActual))";

            Deuda.UpdateFn = () => (Deuda.j + (Interes.k + Emision_de_Deuda.k - Pago_de_Interes.k)*Reloj.DT); //Nivel
            Deuda.Ecuacion = "Deuda.j + (Interes.k + Emision_de_Deuda.k - Pago_de_Interes.k)*Reloj.DT";

            Interes.UpdateFn = () => (Deuda.j*Tasa_Interes_Continua.k); //Ingreso a deuda
            Interes.Ecuacion = "Deuda.j*Tasa_Interes_Continua.k";

            Emision_de_Deuda.UpdateFn = () => (2000 / Ratio_Deuda_Acciones.k); //Ingreso a deuda
            Emision_de_Deuda.Ecuacion = "2000 / Ratio_Deuda_Acciones.k";
            Pago_de_Interes.UpdateFn = () => (Funciones.MIN(Deuda.k*Tasa_Interes_Continua.k, Ganancias_Antes_Int_E_Imp.k)); //Egreso de deuda
            Pago_de_Interes.Ecuacion = "Funciones.MIN(Deuda.k*Tasa_Interes_Continua.k, Ganancias_Antes_Int_E_Imp.k)";

            Acciones.UpdateFn = () => (Acciones.j+(Retencion.k*Reloj.DT)); //Nivel
            Retencion.UpdateFn = () => (Funciones.PULSE(1, 1, 1) * Funciones.MIN(Ingresos_Netos.k*Ratio_Retencion.k,Ingresos_Netos.k)); //Ingreso a Acciones

            Ratio_Deuda_Acciones.UpdateFn = () => (Deuda.k / Activos_Menos_Deudas.k); //Auxiliar
            Ratio_Deuda_Acciones.Ecuacion = "Deuda.k / Activos_Menos_Deudas.k";
            Activos_Menos_Deudas.UpdateFn = () => (Activos_Fijos.k+Dinero.k-Deuda.k); //Auxiliar
            Activos_Menos_Deudas.Ecuacion = "Activos_Fijos.k+Dinero.k-Deuda.k";

            Dinero.UpdateFn = () => (Dinero.j + (Dinero_Anadido.k + Inversiones.k - Pagos.k)*Reloj.DT); //Nivel
            Dinero.Ecuacion = "Dinero.j + (Dinero_Anadido.k + Inversiones.k - Pagos.k)*Reloj.DT";

            Dinero_Anadido.UpdateFn = () => (Depreciacion.k + Ganancias_Antes_Impuestos.k + Dinero_de_Prestamo.k); //Ingreso a Dinero
            Dinero_Anadido.Ecuacion = "Depreciacion.k + Ganancias_Antes_Impuestos.k + Dinero_de_Prestamo.k";
            Inversiones.UpdateFn = () => (Funciones.PULSE(Dinero.k * Capital_de_Inversion.k,1.01,1)); //Ingreso a Dinero
            Inversiones.Ecuacion = "Funciones.PULSE(Dinero.k * Capital_de_Inversion.k,1.01,1)";

            Pagos.UpdateFn = () => (Dividendos.k+Impuestos.k+Expensas_Generales.k); //Egreso de Dinero
            Pagos.Ecuacion = "Dividendos.k+Impuestos.k+Expensas_Generales.k";

            Dinero_de_Prestamo.UpdateFn = () => (Emision_de_Deuda.k + Interes.k - Pago_de_Interes.k); //Auxiliar

            Activos_Fijos.UpdateFn = () => (Activos_Fijos.j+(Inversiones.k-Depreciacion.k)*Reloj.DT); //Nivel
            Inversiones.UpdateFn = () => (Funciones.PULSE(Dinero.k* Capital_de_Inversion.k,1.01,1)); //Ingreso a Activos Fijos
            Depreciacion.UpdateFn = () => (TasaDepreciacion * Activos_Fijos.k); //Egreso de Activos Fijos

            Ingresos_Netos.UpdateFn = () => (Ingresos_Netos.j+(Ganancias_Antes_Impuestos.k-Dividendos.k-Retencion.k-Impuestos.k)*Reloj.DT); //Nivel
            Ganancias_Antes_Impuestos.UpdateFn = () => (Ganancias_Antes_Int_E_Imp.k-Interes.k); //Ingreso a Ingresos_Netos
            Ganancias_Antes_Impuestos.Ecuacion = "Ganancias_Antes_Int_E_Imp.k-Interes.k";
            Dividendos.UpdateFn = () => (Funciones.PULSE(1,1,1)*Funciones.MAX(Ingresos_Netos.k*(1- Ratio_Retencion.k),0)); //Egreso de Ingresos_Netos
            Retencion.UpdateFn = () => (Funciones.PULSE(1, 1, 1)*Funciones.MIN(Ingresos_Netos.k*Ratio_Retencion.k,Ingresos_Netos.k)); //Egreso de Ingresos_Netos
            Impuestos.UpdateFn = () => (Funciones.PULSE(1, 0.99, 1) * Tasa_Impuestos * Ingresos_Netos.k); //Egreso de Ingresos_Netos

            Ganancias_Antes_Int_E_Imp.UpdateFn = () => (Ganancias_Netas.k + Dinero.k * Tasa_Interes_Continua.k - Depreciacion.k - Expensas_Generales.k); //Auxiliar
            Ganancias_Antes_Int_E_Imp.Ecuacion = "Beneficio_Bruto.k + Dinero.k * Tasa_Interes_Continua.k - Depreciacion.k - Expensas_Generales.k";
            Expensas_Generales.UpdateFn = () => (Costos_Adm_Fijos + Presupuesto_Publicidad.k + Presupuesto_Entrenamiento.k + Presupuesto_Inv_Des +
                                                 Presupuesto_Compensacion + Presupuesto_Procesos.k + Costo_de_Inventario.k); //Auxiliar
            
            Beneficio_Bruto.UpdateFn = () => (Ganancias.k - Costos_Variables.k); //Auxiliar
            Beneficio_Bruto.Ecuacion = "Ganancias.k - Costos_Variables.k";

            Ganancias.UpdateFn = () => (Precio * Ventas.k); //Auxiliar    
            Ganancias.Ecuacion = "Precio * Ventas.k";
            Costos_Variables.UpdateFn = () => (Costo_Unitario.k * Ventas.k); //Auxiliar
            Costos_Variables.Ecuacion = "Costo_Unitario.k * Ventas.k";
            Costo_Unitario.UpdateFn = () => (Costos_Controlables.k + Costos_Inevitables); //Auxiliar                        
            Costo_Unitario.Ecuacion = "Costos_Controlables.k + Costos_Inevitables";
            Ganancias_Netas.UpdateFn = () => (Ganancias.k-Costos_Variables.k);//Auxiliar                        
            Ganancias_Netas.Ecuacion = "Ganancias.k-Costos_Variables.k";

            Inventario.UpdateFn = () => (Inventario.j + (Produccion.k - Ventas.k) * Reloj.DT); //Nivel
            Inventario.Ecuacion = "Produccion - Ventas";

            Produccion.UpdateFn = () => (Capacidad_Produccion.k - Inventario.k); //Entrada a Inventario
            Produccion.Ecuacion = "Capacidad_Produccion - Inventario";

            Ventas.UpdateFn = () => (Tamanio_Mercado.k * Porcion_del_Mercado.k / 100); // Salida de Inventario
            Ventas.Ecuacion = "Tamanio_Mercado * Porcion_del_Mercado / 100";

            Capacidad_Produccion.UpdateFn = () => (Productividad.k * Activos_Fijos.k / 100); // Salida de Inventario
            Capacidad_Produccion.Ecuacion = "Productividad * Activos Fijos / 100";

            Tamanio_Mercado.UpdateFn = () => (Tamanio_Mercado.j +(IncrementoDemanda.k - Sustitucion.k) * Reloj.DT); //Nivel
            Tamanio_Mercado.Ecuacion = "Tamanio_Mercado.j +(IncrementoDemanda.k - Sustitucion.k) * Reloj.DT";
            IncrementoDemanda.UpdateFn = () => (20); // Ingreso a Tamanio_Mercado
            Sustitucion.UpdateFn = () => (10); // Salida de Tamanio_Mercado

            Porcion_del_Mercado.UpdateFn = () => (Porcion_del_Mercado.j + (Marketing.k+Satisfaccion.k-Competencia.k)* Reloj.DT); //Nivel
            Porcion_del_Mercado.Ecuacion = "Porcion_del_Mercado + (Marketing+Satisfaccion-Competencia)*DT";

            Marketing.UpdateFn = () => (Presupuesto_Publicidad.k * (100 - Porcion_del_Mercado.k) / 400); //Ingreso a Porcion del Mercado
            Marketing.Ecuacion = "Presupuesto_Publicidad.k * (100 - Porcion_del_Mercado.k) / 400";
            Satisfaccion.UpdateFn = () => ((Calidad.k - Calidad_Estandar.k) - Math.Abs(Calidad.k - Calidad_Estandar.k) * Porcion_del_Mercado.k / 100f); //Ingreso a Porcion del Mercado
            Satisfaccion.Ecuacion = "Calidad.k - Calidad_Estandar.k) - Math.Abs(Calidad.k - Calidad_Estandar.k) * Porcion_del_Mercado.k / 100";
            Competencia.UpdateFn = () => (Porcion_del_Mercado.k * Agresividad); //Salida de Porcion del Mercado
            Competencia.Ecuacion = "Porcion_del_Mercado.k * Agresividad";
            Calidad.UpdateFn = () => (Calidad.j + Mejora.k * Reloj.DT); //Nivel
            Calidad.Ecuacion = "Calidad.j + Mejora.k * Reloj.DT";
            Mejora.UpdateFn = () => (Productividad.k * Presupuesto_Procesos.k / Calidad.k * 10); //Solo ingreso a Calidad
            Mejora.Ecuacion = "Productividad.k * Presupuesto_Procesos.k / Calidad.k * 10";
            Productividad.UpdateFn = () => (Motivacion_RH.k * Habilidades_RH.k * Tecnologia.k); //Auxiliar
            Productividad.Ecuacion = "Motivacion_RH.k * Habilidades_RH.k * Tecnologia.k";

            Motivacion_RH.UpdateFn = () => (Motivacion_RH.j+(Motivacion.k - FaltaMotivacion.k)*Reloj.DT); //Nivel
            Motivacion_RH.Ecuacion = "Motivacion_RH.j+(Motivacion.k - FaltaMotivacion.k)*Reloj.DT";
            Motivacion.UpdateFn = () => (Presupuesto_Compensacion * Efectividad_Compensacion / Motivacion_RH.k); //Ingreso a Motivacion
            Motivacion.Ecuacion = "Presupuesto_Compensacion * Efectividad_Compensacion / Motivacion_RH.k";
            FaltaMotivacion.UpdateFn = () => (Tasa_FaltaMotivacion * Motivacion_RH.k); //Egreso de Motivacion
            FaltaMotivacion.Ecuacion = "Tasa_FaltaMotivacion * Motivacion_RH.k";

            Habilidades_RH.UpdateFn = () => (Habilidades_RH.j + (Entrenamiento.k - Perdida_de_Habilidad.k) * Reloj.DT); //Nivel
            Habilidades_RH.Ecuacion = "Habilidades_RH.j + (Entrenamiento.k - Perdida_de_Habilidad.k) * Reloj.DT";
            Entrenamiento.UpdateFn = () => (Presupuesto_Entrenamiento.k * Efectividad_Entrenamiento/ Habilidades_RH.k); //Ingresos a Habilidades RH
            Entrenamiento.Ecuacion = "Presupuesto_Entrenamiento.k * Efectividad_Entrenamiento/ Habilidades_RH.k";
            Perdida_de_Habilidad.UpdateFn = () => (Tasa_Reemplazo * Habilidades_RH.k); //Egresos de Habilidades RH
            Perdida_de_Habilidad.Ecuacion = "Tasa_Reemplazo * Habilidades_RH.k";

            Tecnologia.UpdateFn = () => (Tecnologia.j+(Investigacion_Y_Desarrollo.k*Reloj.DT)); //Nivel
            Tecnologia.Ecuacion = "Tecnologia.j+(Investigacion_Y_Desarrollo.k*Reloj.DT)";
            Investigacion_Y_Desarrollo.UpdateFn = () => (Presupuesto_Inv_Des * Efectividad_Inv_Des / Tecnologia.k); //Ingreso solo a Tecnologia
            Investigacion_Y_Desarrollo.Ecuacion = "Presupuesto_Inv_Des * Efectividad_Inv_Des / Tecnologia.k";

            Costos_Controlables.UpdateFn = () => (60f / Math.Sqrt(Productividad.k)); //Auxiliar
            Costos_Controlables.Ecuacion = "60 / Math.Sqrt(Productividad.k)";

            Presupuesto_Publicidad.UpdateFn = () => (50); //Auxiliar
            Tasa_Interes_Continua.UpdateFn = () => (Math.Exp(rB)-1); //Auxiliar
            Tasa_Interes_Continua.Ecuacion = "Exp(rB)-1";

            Costo_de_Inventario.UpdateFn = () => (Inventario.k*0.01f); //Inventory_Costs = Inventory*0.01
            Costo_de_Inventario.Ecuacion = "Inventario.k*0.01";

            Presupuesto_Procesos.UpdateFn = () => (100 - Funciones.STEP(100, 15)); //Auxiliar
            Presupuesto_Procesos.Ecuacion = "100 - Funciones.STEP(100, 15)";
            Calidad_Estandar.UpdateFn = () => (Funciones.RAMP(1) * 10 + 100); //Auxiliar
            Calidad_Estandar.Ecuacion = "Funciones.RAMP(1) * 10 + 100";
            Presupuesto_Entrenamiento.UpdateFn = () => (50 - Funciones.STEP(50, 10)); //Auxiliar
            Presupuesto_Entrenamiento.Ecuacion = "50 - Funciones.STEP(50, 10)";


            //Market__Size(t) = Market__Size(t - dt) + (Increase_in__Demand - Substitution) * dt
            //EBIT = Gross_Profit+Cash*Continuous__Interest_Rate-Depreciation-General_Expenses


            //Tax = PULSE(1,0.99,1)*Tax_Rate*Net_Income
            //CapacidadProduccion.Unidades = "Productos/Mes";
            //Stock.UpdateFn = () => (Stock.j + (Produccion.j * Reloj.DT) - (Ventas.j * Reloj.DT));
            //Produccion.UpdateFn = () => (CapacidadProduccion.k);
            //Se supone inicialmente que se vende todo
            //Ventas.UpdateFn = () => (Demanda.k - CapacidadProduccion.k);
            //No se considera la inflacion directamente sino indirectamente en la suba del precio
            //por eso es tabla
            //IngDemanda.UpdateFn = () => (DistDemanda.Generar()); //(3000 - 200 * Precio);
            //Demanda.UpdateFn = () => (Demanda.j + (IngDemanda.j * Reloj.DT));
            Modelo.Inicializado = true;

        }

        public static void Correr()        {

            //Inflacion.UpdateFn = () => (ExpInf.k);
            if (!Modelo.Inicializado)
                Inicializar();
            double TiempoFinal = Modelo.Correr(0, 20);
            System.Windows.Forms.MessageBox.Show("Simulación Finalizada en Tiempo:" + TiempoFinal.ToString());
            //Modelo.MostrarPanel();

        }

        public static void UnPaso()
        {
            if (!Modelo.Inicializado)
                Inicializar();
            double TiempoFinal = Modelo.UnPaso();
        }

        public static string Ecuacion(string nombre)
        {
            return (Modelo.Identificar(nombre).Ecuacion);
        }
        public static void CargarTrayectoriasEnTabla(ref DataGridView dg)
        {
            Modelo.CargarTrayectoriasEnTabla(ref dg, "",2);
        }

        public static void GraficarEnPic(Chart c, string Variable)
        {
            Modelo.Identificar(Variable).GraficarEnPic(c);
        }


        public static double ObtenerValor(string Variable)
        {
            return (Modelo.ObtenerValor(Variable));
        }

        internal static void MostrarTray()
        {
            Modelo.MostrarTray();
        }

        internal static void MostrarPanel()
        {
            Modelo.MostrarPanel();
        }

        internal static string TiempoActual()
        {
            return (Reloj.TiempoActual.ToString());
        }


    }
}