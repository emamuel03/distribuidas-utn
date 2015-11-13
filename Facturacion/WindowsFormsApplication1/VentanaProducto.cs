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
        
        VModificarProducto vmp = new VModificarProducto();

        //inicio un varable estatica 
        //para pasarle como parametro al metodo cargarCampos()
        public static int id;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            p.Nombre = txtNombre.Text;
            p.Precio = double.Parse(txtPrecio.Text);
            p.Stock = int.Parse(txtStock.Text);
            p.IdCategoria = Convert.ToInt16(comboCategoria.SelectedValue);

            controlador.altaProducto(p);
            limpiarCampos();
            actualizarTabla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarProducto();
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
            limpiarCampos();
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

            /* el metodo fillByProducto es un join creado en el data set
            entre las tablas producto y categoria */
            adaptador.FillByProducto(datos.producto);
            dataGridView1.DataSource = datos.producto;

        }

        public void modificarProducto()
        {
            id = int.Parse(txtIdProducto.Text);
            controlador.buscarProducto(id, p);

            // si el producto existe en la tabla el Id del producto es distinto de 0
            
            if (p.IdProducto != 0)
            {
                
                vmp.cargarCampos();
                vmp.Show();
                ControladorVentanas.ocultarVentanas();

                /*SE DEBE DE ESTA MANERA ABRIR LA VENTANA VModificarProducto 
                PARA EVITAR VOLVER A INSTANCIAR LA CLASE VModificarProducto
                Y PERDER EL PARAMETRO ID QUE LE ESTAMOS PASANDO*/
            }
        }

        private void VentanaProducto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.categoria' table. You can move, or remove it, as needed.
            this.categoriaTableAdapter.Fill(this.database1DataSet1.categoria);
            actualizarTabla();

            //CONFIGUARCION DEL Grid View
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[2].HeaderText = "PRECIO UNITARIO";
            dataGridView1.Columns[3].HeaderText = "STOCK";
            //la columna 4 del GridView no se muestra
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "CATEGORIA";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            txtIdProducto.Text = dataGridView1[0, i].Value.ToString();
        }

    }
}
