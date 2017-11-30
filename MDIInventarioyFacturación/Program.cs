using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MDIInventarioyFacturación
{
    static class Program
    {

        public static int idcuentas = 0;
        public static string nombrecuenta = "";

        /* Variables globales para El Listado De Precios
           No tocar */
        public static int idPorcentaje = 0;
        public static string Descripcion = "";
        public static int idCliente = 0;
        public static string nombreCliente = "";


        /*Gloval Variable that store the "tipo de movimiento"*/
        public static int idTipoDeMovimiento = 0;
        public static String nombreDelMovimienot = "";
        public static int IngreOEgreMov = 0;

        /*Creacion de la instancia para la conecion*/
        public static String stringpad = "server=localhost;user id=root;database=hotelfase2";

        /*Variables glovales para la seleccion de bodega*/
        public static int idBodega = 0;
        public static String nombreDeLaBodega = "";

        /*Variables glovales para la selecion de el producto*/
        public static int idProducto = 0;
        public static String nombreDelProducto = "";
        public static int precioUnitario = 0;

        /*Variables traslado y transporte*/
        public static int noviaje = 0;
        public static int dpi = 0;
        public static string nombre = "";
        public static int id = 0;
        public static int codigoT = 0;
        public static string bodegaS = "";
        public static string bodegaE = "";
        public static string nombreD = "";
        public static int nombreC = 0;



        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
