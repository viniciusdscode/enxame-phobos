using DGVPrinterHelper;
using EnxamePhobos.BLL;
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
    public partial class FrmFilme : Form
    {
        public FrmFilme()
        {
            InitializeComponent();
        }

        FilmeBLL objBLL = new FilmeBLL();

        private void FrmFilme_Load(object sender, EventArgs e)
        {
            gvInativo();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            FilmeBLL objBLL = new FilmeBLL();
            gv1.DataSource = objBLL.ListarFilme();
            gvAtivo();
            PopularCBOGenero();
            CarregaImg();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            string objFiltro = cboGenero.Text.ToString();

            gv1.DataSource = objBLL.FiltarFilmeBLL(objFiltro);
            CarregaImg();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            gv1.Visible = false;
            cboGenero.Visible = false;
            btnFiltro.Visible = false;
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

        
        private void CarregaImg()
        {
            foreach (DataGridViewRow row in gv1.Rows)
            {
                DataGridViewImageColumn col = new DataGridViewImageColumn();
                col.Name = "Img";
                col.HeaderText = "Imagem";
                col.ImageLayout = DataGridViewImageCellLayout.Zoom;
                row.Cells["Img"].Value = Image.FromFile(row.Cells["UrlImg"].Value.ToString());
            }
        }

        public void PopularCBOGenero()
        {

            cboGenero.DataSource = objBLL.CarregarDDList();
            cboGenero.ValueMember = "ID";
            cboGenero.DisplayMember = "DescricaoGenero";
            cboGenero.Refresh();
        }

        public void gvAtivo()
        {
            gv1.Visible = true;
            cboGenero.Visible = true;
            btnFiltro.Visible = true;
        }

        public void gvInativo()
        {
            gv1.Visible = false;
            cboGenero.Visible = false;
            btnFiltro.Visible = false;
        }

    }
}
