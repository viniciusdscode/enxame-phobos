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
    public partial class FrmCadastrarFilme : Form
    {
        FilmeBLL objBLL = new FilmeBLL();
        public FrmCadastrarFilme()
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

        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens |*.bmp;*.jpg;*.png;";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string img = dialog.FileName.ToString();
                pc1.ImageLocation = img;

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FilmeDTO objCad = new FilmeDTO();
            objCad.Titulo = txtTitulo.Text;
            objCad.Produtora = txtProdutora.Text;

            //save urlimg
            string nomeImg = txtTitulo.Text + ".jpg";
            string pasta = @"C:\Users\vinicius.ssantos79\source\repos\EnxamePhobos\EnxamePhobos.Desktop\imgSave\";
            string caminhoImg = Path.Combine(pasta, nomeImg);
            objCad.UrlImg = caminhoImg;

            //save img
            Image a = pc1.Image;
            a.Save(caminhoImg);

            //cbos
            objCad.Genero_Id = cboGenero.SelectedValue.ToString();
            objCad.Classificacao_Id = cboClassif.SelectedValue.ToString();

            FilmeBLL objCadastro = new FilmeBLL();
            objCadastro.CadastrarFilmeBLL(objCad);
            MessageBox.Show ($"Filme {txtTitulo.Text} Cadastrado com sucesso!!");
            Limpar.ClearControl(this);
            pc1.Image = null;
            txtTitulo.Focus();


            
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

        private void FrmCadastrarFilme_Load(object sender, EventArgs e)
        {
            PopularCBOClassif();
            PopularCBOGenero();
        }
    }
}
