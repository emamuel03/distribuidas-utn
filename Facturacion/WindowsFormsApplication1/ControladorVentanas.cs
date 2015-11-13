using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ControladorVentanas
    {
        public static LogIn log = new LogIn();
        public static MenuPrincipal mp = new MenuPrincipal();
        public static VentanaProducto vp = new VentanaProducto();

        public static System.Windows.Forms.Form getMostrar()
        {
            return mp;
        }

        public static void ocultarVentanas()
        {
            log.Hide(); mp.Hide(); vp.Hide();
        }

        public static void  mostrarMenuPrincipal()
        {
            ocultarVentanas();
            mp.Show();
        }

        public static void mostrarProducto()
        {
            ocultarVentanas();
            vp.Show();
        }
    }
}
