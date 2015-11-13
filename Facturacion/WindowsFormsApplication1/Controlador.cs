using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.DataSet1TableAdapters;

namespace WindowsFormsApplication1
{
    class Controlador
    {
        productoTableAdapter adaProducto = new productoTableAdapter();

        public void altaProducto(Producto p)
        {
            adaProducto.Insert(p.Nombre, p.Precio, p.Stock, p.IdCategoria);
            MessageBox.Show("SE CREO NUEVO PRODUCTO");
        }

        public void bajaProducto(Producto p)
        {
            string message = "Esta seguro que desea eliminar este producto";
            string caption = "Eliminar producto";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                adaProducto.DeleteQueryProducto(p.IdProducto);
                MessageBox.Show("PRODUCTO ELIMINADO");
            }
        }

        public void modificarProducto(int idProducto, Producto p)
        {
            string message = "Esta seguro que desea modificar datos del Producto";
            string caption = "Modificar Producto";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                adaProducto.UpdateQueryProducto(p.Nombre, p.Precio, 
                    p.Stock, p.IdCategoria, idProducto);
                MessageBox.Show("PRODUCTO MODIFICADO!!!");
            }

        }

        public void buscarProducto(int id, Producto p)
        {
            DataSet1 datos = new DataSet1();
            adaProducto.Fill(datos.producto);
            if (datos.producto.FindByid_producto(id) != null)
            {
                p.IdProducto = datos.producto.FindByid_producto(id).id_producto;
                p.Nombre = datos.producto.FindByid_producto(id).nombre;
                //MessageBox.Show("nombre de producto = " + p.Nombre);
                p.Precio = datos.producto.FindByid_producto(id).precio;
                p.Stock = datos.producto.FindByid_producto(id).stock;
                p.IdCategoria = datos.producto.FindByid_producto(id).id_categoria;
            }
            else
            {
                p.IdProducto = 0;
                p.Nombre = "";
                p.Precio = 0;
                p.Stock = 0;
                p.IdCategoria = 0;
                MessageBox.Show("NO EXISTE EL PRODUCTO CON ID = " + id);
            }
        }
    }
}
