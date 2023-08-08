using EnxamePhobos.BLL;
using EnxamePhobos.DDO;
using EnxamePhobos.Desktop.Utilitarios;
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
    public partial class FrmExcluirFilme : Form
    {

        FilmeDTO objModeloFilme = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();

        public FrmExcluirFilme()
        {
            InitializeComponent();
        }

        private void FrmExcluirFilme_Load(object sender, EventArgs e)
        {
            cpInativo();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            pc1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string objSearch = txtSearch.Text;

            objModeloFilme = objBLL.SearchByNameFilmDsk(objSearch);
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = string.Empty;
                txtSearch.BackColor = Color.Red;
                MessageBox.Show("O nome não existe ou o campo está vazio !!", "Atenção !!", MessageBoxButtons.OK);
                txtSearch.BackColor = DefaultBackColor;
                txtSearch.Focus();
                return;
            }
            else if (objSearch != null)
            {
                txtId.Text = objModeloFilme.Id.ToString();
                txtTitulo.Text = objModeloFilme.Titulo;
                txtProdutora.Text = objModeloFilme.Produtora;
                pc1.ImageLocation = objModeloFilme.UrlImg;

                PopularCBOGenero();
                PopularCBOClassif();

                cboGenero.Text = objModeloFilme.Genero_Id;
                cboClassificacao.Text = objModeloFilme.Classificacao_Id;


            }
            cpInativo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show($"Deseja excluir {objModeloFilme.Titulo}?", "Atenção", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                objModeloFilme.Id = int.Parse(txtId.Text);
                objBLL.DeleteUser(objModeloFilme.Id);
                pc1.Image = null;
                PopularCBOGenero();
                PopularCBOClassif();
                Limpar.ClearControl(this);
                MessageBox.Show($"Filme {objModeloFilme.Titulo} Obliterado !!!");
            }
            else if (confirmar == DialogResult.No)
            {
                Limpar.ClearControl(this);
                pc1.Image = null;
                PopularCBOGenero();
                PopularCBOClassif();
            }
        }

        public void PopularCBOGenero()
        {
            cboGenero.DataSource = objBLL.CarregarDDList();
            cboGenero.ValueMember = "ID";
            cboGenero.DisplayMember = "DescricaoGenero";
            cboGenero.Refresh();
        }

        public void PopularCBOClassif()
        {
            cboClassificacao.DataSource = objBLL.CarregarDDListClassif();
            cboClassificacao.ValueMember = "ID";
            cboClassificacao.DisplayMember = "DescricaoClassificacao";
            cboClassificacao.Refresh();
        }

        public void cpInativo()
        {
            txtId.Enabled = false;
            txtTitulo.Enabled = false;
            txtProdutora.Enabled = false;
            cboGenero.Enabled = false;
            cboClassificacao.Enabled = false;
        }


    }
}
