using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIInventarioyFacturación.Forms.TrasladoTransporte
{
    public partial class ModificarPiloto : Form
    {
        public ModificarPiloto()
        {
            InitializeComponent();
        }

        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";
        dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado connection = new dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado(stringpad);

        private void ModificarPiloto_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


            connection.OpenConnection();
            dataGridView1.DataSource = connection.llenarDataGridView("select * from piloto  where  nombre  like'" + textBox4.Text + "%'");
            connection.CloseConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.OpenConnection();

            connection.ActualizarRegistro("UPDATE piloto set nombre='" + textBox1.Text + "',dpi ='" + textBox2.Text + "',telefono='" + textBox3.Text + "' where  nombre  like'" + textBox4.Text + "%'");
            MessageBox.Show("Dato Actualizado!");
            connection.CloseConnection();



        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
    }
}
