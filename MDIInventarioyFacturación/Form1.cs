using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MDIInventarioyFacturación.Forms.MovInventario;
using MDIInventarioyFacturación.Forms.ListPrecios;
using capaDatos;
using capaDiseño;



namespace MDIInventarioyFacturación
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void enlaceConContabilidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mantenimiento form = new Mantenimiento();
            form.MdiParent = this;
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void entradasYSalidaInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoMovimiento formMov = new NuevoMovimiento();
            formMov.MdiParent = this;
            formMov.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comisiones menu = new comisiones();
            menu.Show();
        }

        private void listadoDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ListadoPrecio listas = new ListadoPrecio();
            listas.MdiParent = this;
            listas.Show();
        }

        private void actualizarListasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizarPorcentajes porcentaje = new actualizarPorcentajes();
            porcentaje.MdiParent = this;
            porcentaje.Show();
        }

        private void trasladoEntreBodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {

           


        }

        private void nuevoEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {


            MDIInventarioyFacturación.Forms.TrasladoTransporte.Agregar_Unidad Unidad = new MDIInventarioyFacturación.Forms.TrasladoTransporte.Agregar_Unidad();
            Unidad.MdiParent = this;
            Unidad.Show();

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {


            MDIInventarioyFacturación.Forms.TrasladoTransporte.Agregar_Piloto piloto = new MDIInventarioyFacturación.Forms.TrasladoTransporte.Agregar_Piloto();
            piloto.MdiParent = this;
            piloto.Show();


        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {


            MDIInventarioyFacturación.Forms.TrasladoTransporte.ModificarPiloto Mpiloto = new MDIInventarioyFacturación.Forms.TrasladoTransporte.ModificarPiloto();
            Mpiloto.MdiParent = this;
            Mpiloto.Show();


        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDIInventarioyFacturación.Forms.TrasladoTransporte.Agregar_Vehiculo Avehiculo = new MDIInventarioyFacturación.Forms.TrasladoTransporte. Agregar_Vehiculo();
            Avehiculo.MdiParent = this;
            Avehiculo.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDIInventarioyFacturación.Forms.TrasladoTransporte.Modificar_Vehiculo Mvehiculo = new MDIInventarioyFacturación.Forms.TrasladoTransporte.Modificar_Vehiculo();
            Mvehiculo.MdiParent = this;
            Mvehiculo.Show();
        }
    }
}
