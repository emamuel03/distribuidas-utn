using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Validacion
    {
        public static bool soloEntero(TextBox campo, ToolTip tt)
        {
            try
            {
                int i = int.Parse(campo.Text);
                return true;
            }

            catch
            {
                int hasta = campo.Text.Length - 1;
                campo.Text = campo.Text.Substring(0, hasta);
                campo.Select(campo.Text.Length, 0);
                tt.ToolTipTitle = "Caracter Invalido";
                tt.Show("Lo sentimos, solo se permiten caracteres numericos (0-9)",
                    campo, 3000);
                return false;
            }
        }

        public static bool soloDouble(TextBox campo, ToolTip tt)
        {
            try
            {
                double d = double.Parse(campo.Text);
                return true;
            }

            catch
            {
                int hasta = campo.Text.Length - 1;
                campo.Text = campo.Text.Substring(0, hasta);
                campo.Select(campo.Text.Length, 0);
                tt.ToolTipTitle = "Caracter Invalido";
                tt.Show("Lo sentimos, solo se permiten caracteres decimales",
                    campo, 3000);
                return false;
            }
        }

        public static bool menorDeCincuenta(TextBox campo, ToolTip tt)
        {
            if (campo.Text.Length < 50)
            {
                return true;
            }
            else
            {
                int hasta = campo.Text.Length - 1;
                campo.Text = campo.Text.Substring(0, hasta);
                campo.Select(campo.Text.Length, 0);
                tt.ToolTipTitle = "Entrada Invalida";
                tt.Show("Lo sentimos, la entrada supera los 50 caracteres",
                    campo, 3000);
                return false;
            }
        }

        public static bool validacionVacio(TextBox campo, ErrorProvider ep)
        {
            if(campo.Text == string.Empty)
            {
                ep.SetError(campo, "Introduce campo...");
                return true;
            }
            else
            {
                ep.Clear();
                return false;
            }
        }
    }
}
