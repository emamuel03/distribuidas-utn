using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.DataSet1TableAdapters;

namespace WindowsFormsApplication1
{
    public partial class VentanaProducto : Form
    {
        public VentanaProducto()
        {
            InitializeComponent();
        }

        Producto p = new Producto();
        Controlador controlador = new Controlador();
        public static int id;
        VModificarProducto vmp = new VModificarProducto();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            p.Nombre = txtNombre.Text;
            p.Precio = double.Parse(txtPrecio.Text);
            p.Stock = int.Parse(txtStock.Text);
           // MessageBox.Show(comboCategoria.SelectedValue.ToString());
            p.IdCategoria = Convert.ToInt16(comboCategoria.SelectedValue);

            controlador.altaProducto(p);
            limpiarCampos();
            actualizarTabla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            id = int.Parse(txtIdProducto.Text);
            vmp.cargarCampos();
            vmp.Show();
            ControladorVentanas.ocultarVentanas();
            actualizarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            p.IdProducto = int.Parse(txtIdProducto.Text);

            controlador.bajaProducto(p);
            actualizarTabla();
            limpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdProducto.Text);
            controlador.buscarProducto(id, p);
            txtNombre.Text = p.Nombre;
            txtPrecio.Text = p.Precio.ToString();
            txtStock.Text = p.Stock.ToString();
            comboCategoria.SelectedValue = p.IdCategoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControladorVentanas.mostrarMenuPrincipal();
        }

        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            comboCategoria.SelectedValue = 1;
        }

        public void actualizarTabla()
        {
            var adaptador = new productoTableAdapter();
            DataSet1 datos = new DataSet1();
            adaptador.Fill(datos.producto);
            dataGridView1.DataSource = datos.producto;
        }

        private void VentanaProducto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.categoria' table. You can move, or remove it, as needed.
            this.categoriaTableAdapter.Fill(this.database1DataSet1.categoria);
            actualizarTabla();
        }
    }
}
