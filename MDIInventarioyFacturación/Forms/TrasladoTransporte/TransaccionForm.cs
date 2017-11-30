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
    public partial class TransaccionForm : Form
    {

        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";
        dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado connection = new dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado(stringpad);

        public TransaccionForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToString("yyy/MM/dd");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            connection.OpenConnection();

            dataGridView1.DataSource = connection.llenarDataGridView("select mi.codigoMovimientoInventario as Movimiento,mi.fecha, bd.nombre as Bodega from movimientoinventario mi inner join tipomovimientoiventario tm on mi.TipoMovimientoIventario_idTipoMovimientoIventario = tm.idTipoMovimientoIventario inner join bodega bd on mi.bodega_idBodegaDestino = bd.idBodega where mi.fecha = '"+textBox1.Text+"'; ");


            connection.CloseConnection();



        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            Program.codigoT = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            
            connection.OpenConnection();
            connection.ActualizarRegistro("UPDATE movimientoinventario set viaje_idViaje = '" + Program.noviaje.ToString() + "' where codigoMovimientoInventario ='" + Program.codigoT.ToString()+"'");
            dataGridView2.DataSource = connection.llenarDataGridView("select mi.codigoMovimientoInventario as Movimiento,mi.fecha, bd.nombre as Bodega from movimientoinventario mi inner join tipomovimientoiventario tm on mi.TipoMovimientoIventario_idTipoMovimientoIventario = tm.idTipoMovimientoIventario inner join bodega bd on mi.bodega_idBodegaDestino = bd.idBodega where mi.viaje_idViaje = '" + Program.noviaje.ToString()+ "'; ");

            dataGridView3.DataSource = connection.llenarDataGridView("select pr.descripcion,dm.Cantidad from detallemovimiento dm inner join productos pr on dm.productos_idProducto = pr.idProducto inner join  movimientoinventario mi on dm.movimientoInventario_codigoMovimientoInventario = mi.codigoMovimientoInventario  where mi.codigoMovimientoInventario = '"+Program.codigoT.ToString()+"' ; ");




            connection.CloseConnection();
            

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
