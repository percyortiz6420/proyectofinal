using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllconnectionDatabase;

namespace MDIInventarioyFacturación.Forms.TrasladoTransporte
{
    

    public partial class Modificar_Vehiculo : Form
    {

       

        public Modificar_Vehiculo()
        {
            InitializeComponent();
        }

        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";
        dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado connection = new dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado(stringpad);

        private void dataGridViewpredictivo1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.OpenConnection();
            
            connection.ActualizarRegistro("UPDATE vehiculo set tipo='"+ textBox1.Text +"',capacidad ='"+ textBox2.Text+"',placa='"+textBox3.Text+ "' where  placa  like'" + textBox4.Text + "%'");
            MessageBox.Show("Dato Actualizado!");
            connection.CloseConnection();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            this.Hide();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            connection.OpenConnection();
            dataGridView1.DataSource = connection.llenarDataGridView("select * from vehiculo  where  placa  like'" + textBox4.Text + "%'");
            connection.CloseConnection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void Modificar_Vehiculo_Load(object sender, EventArgs e)
        {

        }
    }
}
