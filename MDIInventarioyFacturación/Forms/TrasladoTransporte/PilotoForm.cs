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
using MDIInventarioyFacturación;

namespace MDIInventarioyFacturación.Forms.TrasladoTransporte
{
    public partial class PilotoForm : Form
    {

        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";
        dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado connection = new dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado(stringpad);
        public PilotoForm()
        {
            InitializeComponent();
        }

       

        private void PilotoForm_Load(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Program.id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.dpi = Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

            connection.OpenConnection();
            dataGridView1.DataSource = connection.llenarDataGridView("select * from piloto  where  nombre  like'" + textBox4.Text + "%'");
            connection.CloseConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
