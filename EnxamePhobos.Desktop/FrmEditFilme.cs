using EnxamePhobos.BLL;
using EnxamePhobos.DDO;
using EnxamePhobos.Desktop.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnxamePhobos.Desktop
{
    public partial class FrmEditFilme : Form
    {
        FilmeDTO objModeloFilme = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();

        public FrmEditFilme()
        {
            InitializeComponent();
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string objSearch = txtSearch.Text;

            objModeloFilme = objBLL.SearchByNameFilmDsk(objSearch);
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                txtTitulo.Text = string.Empty;
                txtTitulo.BackColor = Color.Red;
                MessageBox.Show("O nome não existe ou o campo está vazio !!", "Atenção !!", MessageBoxButtons.OK);
                txtTitulo.BackColor = DefaultBackColor;
                txtTitulo.Focus();
                return;
            }
            else if(objSearch != null)
            {
                txtId.Text = objModeloFilme.Id.ToString();
                txtTitulo.Text = objModeloFilme.Titulo;
                txtProdutora.Text = objModeloFilme.Produtora;
                pc1.ImageLocation = objModeloFilme.UrlImg;

                PopularCBOGenero();
                PopularCBOClassif();

                cboGenero.Text = objModeloFilme.Genero_Id;
                cboClassif.Text = objModeloFilme.Classificacao_Id;
                

            }
            cpAtivo();

        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens |*.bmp;*.jpg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string img = dialog.FileName.ToString();
                pc1.ImageLocation = img;

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FilmeDTO objEdit = new FilmeDTO();
            objEdit.Titulo = txtTitulo.Text;
            objEdit.Produtora = txtProdutora.Text;

            //save urlimg
            string nomeImg = txtTitulo.Text + ".jpg";
            string pasta = @"C:\Users\vinicius.ssantos79\source\repos\EnxamePhobos\EnxamePhobos.Desktop\imgSave\";
            string caminhoImg = Path.Combine(pasta, nomeImg);
            objEdit.UrlImg = caminhoImg;

            //save img
            Image a = pc1.Image;
            a.Save(caminhoImg);

            //cbos
            objEdit.Genero_Id = cboGenero.SelectedValue.ToString();
            objEdit.Classificacao_Id = cboClassif.SelectedValue.ToString();

            objBLL.UpdateFilm(objEdit);
            Limpar.ClearControl(this);

            MessageBox.Show($"Filme {objEdit.Titulo} Editado com sucesso!!");
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
            cboClassif.DataSource = objBLL.CarregarDDListClassif();
            cboClassif.ValueMember = "ID";
            cboClassif.DisplayMember = "DescricaoClassificacao";
            cboClassif.Refresh();
        }

        private void FrmEditFilme_Load(object sender, EventArgs e)
        {
            cpInativo();
        }

        public void cpAtivo()
        {
            txtTitulo.Enabled = true;
            txtProdutora.Enabled = true;
            btnImg.Enabled = true;
            cboGenero.Enabled = true;
            cboClassif.Enabled = true;
        }

        public void cpInativo()
        {
            txtId.Enabled = false;
            txtTitulo.Enabled = false;
            txtProdutora.Enabled = false;
            btnImg.Enabled = false;
            cboGenero.Enabled = false;
            cboClassif.Enabled = false;
        }
    }
}
