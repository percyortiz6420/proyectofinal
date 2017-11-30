using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.Odbc;

namespace dllconnectionDatabaseTraslado

{
    public class dllconnectionDatabaseTraslado
    {

       

        OdbcCommand cmd;
        OdbcDataReader dr;

        private OdbcConnection conn;
        private String connStr;

        /*Create a constructor*/
        public dllconnectionDatabaseTraslado(String coonection)
        {
            this.connStr = coonection;
        }


        /*Open a connection*/

        public bool OpenConnection()
        {
            try
            {
                conn = new OdbcConnection(connStr);
                conn.Open();
                return true;
            }
            catch (OdbcException ex)
            {
                /*Error of connection*/
                return false;
            }



        }



        /*Close the connection*/
        public bool CloseConnection()
        {

            try
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                return true;


            }
            catch (OdbcException ex)
            {
                return false;
            }


        }


        public DataTable llenarDataGridView(String sentencia)
        {

            DataTable dt = new DataTable();
            OdbcDataAdapter da = new OdbcDataAdapter(sentencia, connStr);
            da.Fill(dt);

            return dt;

        }
        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";


        public static DataTable Datos()
        {
            DataTable dt = new DataTable();

            OdbcConnection connection = new OdbcConnection(stringpad);

                    
        string consulta = "SELECT * FROM bodega"; //consulta a la tabla bodega
            OdbcCommand comando = new OdbcCommand(consulta, connection);

            OdbcDataAdapter adap = new OdbcDataAdapter(comando);


            adap.Fill(dt);
            return dt;
        }
        public static AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = Datos();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["nombre"]));
            }

            return coleccion;


        }




        public void InsertarRegistro(String sentencia)
        {
            string insertquery = sentencia;
            OdbcCommand command = new OdbcCommand(insertquery, conn);
            command.ExecuteNonQuery();

        }


        public void ActualizarRegistro(String sentencia)
        {
            string insertquery = sentencia;
            OdbcCommand command = new OdbcCommand(insertquery, conn);
            command.ExecuteNonQuery();

        }



    }
}
