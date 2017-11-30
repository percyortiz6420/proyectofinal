using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllconnectionDatabaseTraslado;

namespace MDIInventarioyFacturación.Forms.TrasladoTransporte
{
    public partial class Agregar_Vehiculo : Form
    {
        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";
        dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado connection = new dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado(stringpad); 

        public Agregar_Vehiculo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.OpenConnection();
            connection.InsertarRegistro("INSERT INTO vehiculo(tipo, capacidad, placa) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');");
            MessageBox.Show("Dato Ingresado!");
            connection.CloseConnection();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void Agregar_Vehiculo_Load(object sender, EventArgs e)
        {

        }
    }
}
