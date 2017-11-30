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
    public partial class Agregar_Unidad : Form
    {
      

        public Agregar_Unidad()
        {
            InitializeComponent();
        }



        public static String stringpad = "Driver = { MySQL ODBC 3.51 Driver}; Dsn=conexion;";
        dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado connection = new dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado(stringpad);

        private void Button1_Click(object sender, EventArgs e)
        {
            



        }

        private void Agregar_Unidad_Load(object sender, EventArgs e)
        {
           

            txtbodegadestino.AutoCompleteCustomSource = dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado.Autocomplete();
            txtbodegadestino.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbodegadestino.AutoCompleteSource = AutoCompleteSource.CustomSource;


            txtbodegaprocedencia.AutoCompleteCustomSource = dllconnectionDatabaseTraslado.dllconnectionDatabaseTraslado.Autocomplete();
            txtbodegaprocedencia.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbodegaprocedencia.AutoCompleteSource = AutoCompleteSource.CustomSource;
         



        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PilotoForm pf = new PilotoForm();
            pf.ShowDialog();
            lblnombre.Text = Program.nombre;
            lbldpi.Text = Program.dpi.ToString();
            lblresultadopiloto.Text = Program.id.ToString();
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            connection.OpenConnection();
            dataGridView1.DataSource = connection.llenarDataGridView("select * from vehiculo  where  placa  like'" + textBox4.Text + "%'");
            connection.CloseConnection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            Lblcapacidad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblUnidad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lblunidadseleccionada.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DateTimePicker1.Focus();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void navegador1_Load(object sender, EventArgs e)
        {
             
        }

        private void navegador1_RecibidorAnterior(object sender, EventArgs e)
        {

            

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_atras_Click(object sender, EventArgs e)
        {

            
            this.Hide();

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

           
            connection.OpenConnection();

            connection.ActualizarRegistro("UPDATE viaje set fechaPrevistaOperacion ='" + DateTimePicker1.Value.ToString("yyyy-MM-dd") + "',observaciones ='" + txtobservaciones.Text + "',vehiculo_idVehiculo ='" + lblunidadseleccionada.Text + "',bodegaProcedencia ='" + txtbodegaprocedencia.Text + "',bodegaDestino ='" + txtbodegadestino.Text + "' , piloto_idpiloto = '"+lblresultadopiloto.Text+"' where idviaje ='" + Program.noviaje.ToString() + "';");

            connection.CloseConnection();

            
            Lblcapacidad.Text = "";
            lbldpi.Text = "";
            lblnombre.Text = "";
            txtbodegaprocedencia.Text = "";
            txtbodegadestino.Text = "";
            dataGridView1.DataSource = null;
            dataGridView3.DataSource = null;
            lblresultadopiloto.Text = "";
            lblUnidad.Text = "";
            lblunidadseleccionada.Text = "";
            
            
            txtobservaciones.Text = "";

            btn_imprimir.Enabled = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           TransaccionForm pf = new TransaccionForm();
            pf.ShowDialog();

            connection.OpenConnection();
            dataGridView3.DataSource = connection.llenarDataGridView("select mi.codigoMovimientoInventario as Movimiento,mi.fecha, bd.nombre as Bodega from movimientoinventario mi inner join tipomovimientoiventario tm on mi.TipoMovimientoIventario_idTipoMovimientoIventario = tm.idTipoMovimientoIventario inner join bodega bd on mi.bodega_idBodegaDestino = bd.idBodega where mi.viaje_idViaje = '" + Program.noviaje.ToString() + "'; ");
            connection.CloseConnection();
            
            

        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {

            connection.OpenConnection();

            connection.InsertarRegistro("INSERT INTO viaje(fechaPrevistaOperacion,observaciones,vehiculo_idVehiculo,bodegaProcedencia,bodegaDestino,piloto_idpiloto)VALUES('X','X',1,'X','X',1);");

            dataGridView2.DataSource = connection.llenarDataGridView("select idViaje from viaje order by idViaje desc limit 1;");
            Program.noviaje = Int32.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            connection.CloseConnection();
            
            GBObs.Enabled = true;
            GBpiloto.Enabled = true;
            GBTrans.Enabled = true;
            GBUnidad.Enabled = true;
            btn_guardar.Enabled = true;
            btn_eliminar.Enabled = true;
        }

        private void GBTrans_Enter(object sender, EventArgs e)
        {

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            connection.OpenConnection();

            connection.ActualizarRegistro("alter view  VistaImprimir as select v.idViaje,v.fechaPrevistaOperacion,v.observaciones, e.placa, e.tipo , p.nombre, p.dpi, v.bodegaDestino,v.bodegaProcedencia from viaje v inner join piloto p on v.piloto_idpiloto=p.idpiloto inner join vehiculo e on v.vehiculo_idVehiculo = e.idVehiculo where v.idViaje = '" + Program.noviaje.ToString()+"';");
            connection.ActualizarRegistro("alter view Vistaproductos as select mi.codigoMovimientoInventario as No_movimiento,dm.Cantidad,pr.descripcion,dm.CostoTotal from movimientoinventario mi inner join detallemovimiento dm on mi.codigoMovimientoInventario = dm.movimientoInventario_codigoMovimientoInventario inner join productos pr on dm.productos_idProducto = pr.idProducto inner join viaje vj on mi.viaje_idViaje = vj.idViaje where vj.idViaje = '"+Program.noviaje.ToString()+"'; ");

            connection.CloseConnection();
            ReporteProducto rp = new ReporteProducto();
            rp.Show();
            ReporteEnvio re = new ReporteEnvio();
            re.Show();
           
        }

        private void cmbprocedencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
