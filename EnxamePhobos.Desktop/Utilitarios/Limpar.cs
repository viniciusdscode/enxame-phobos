using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnxamePhobos.Desktop.Utilitarios
{
    public static class Limpar
    {
        public static void ClearControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                ClearControl(c);
            }
        }
    }
}
