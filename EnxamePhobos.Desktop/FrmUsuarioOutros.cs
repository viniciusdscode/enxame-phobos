using DGVPrinterHelper;
using EnxamePhobos.BLL;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnxamePhobos.Desktop
{
    public partial class FrmUsuarioOutros : Form
    {
        public FrmUsuarioOutros()
        {
            InitializeComponent();
        }

        private void FrmUsuarioOutros_Load(object sender, EventArgs e)
        {
            gv1.Visible = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            gv1.Visible = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            UsuarioBLL objBLL = new UsuarioBLL();


            gv1.DataSource = objBLL.ListarUsuario();
            gv1.Visible = true;
            gv1.ReadOnly = true;
            

        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = lblTitulo.Text;
            printer.PageNumbers = true;
            printer.PorportionalColumns = true;
            printer.Footer = DateTime.Now.ToString();
            printer.PrintDataGridView(gv1);
        }


    }
}
