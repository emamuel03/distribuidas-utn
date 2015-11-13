using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class VModificarProducto : Form
    {
        public VModificarProducto()
        {
            InitializeComponent();
        }

        Producto p = new Producto();
        Controlador ctr = new Controlador();

        public void cargarCampos()
        {
            txtIdProducto.Text = VentanaProducto.id.ToString();

            ctr.buscarProducto(VentanaProducto.id, p);
            txtNombre.Text = p.Nombre;
            txtPrecio.Text = p.Precio.ToString();
            txtStock.Text = p.Stock.ToString();
            comboCategoria.SelectedValue = p.IdCategoria;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            p.Nombre = txtNombre.Text;
            p.Precio = double.Parse(txtPrecio.Text);
            p.Stock = int.Parse(txtStock.Text);
            p.IdCategoria = Convert.ToInt16(comboCategoria.SelectedValue);

            ctr.modificarProducto(VentanaProducto.id, p);
            cerrarVentana();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cerrarVentana();
        }

        public void cerrarVentana()
        {
            ControladorVentanas.mostrarProducto();
            Hide();
        }

        private void VModificarProducto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.categoria' table. You can move, or remove it, as needed.
            this.categoriaTableAdapter.Fill(this.database1DataSet2.categoria);

        }
    }
}
