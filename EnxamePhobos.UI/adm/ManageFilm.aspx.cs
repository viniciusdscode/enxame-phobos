using EnxamePhobos.BLL;
using EnxamePhobos.DDO;
using EnxamePhobos.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class ManageFilm : System.Web.UI.Page
    {
        FilmeDTO objModeloFilme = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtId.Enabled = false;
                PopularGVFilme();
                PopularDDL1();
            }

        }

        //VALIDATION
        public bool ValidatePage()
        {
            bool validator;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite o Titulo !!";
                txtTitulo.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite a Produtora !!";
                txtProdutora.Focus();
                validator = false;
            }
            else
            {
                validator = true;
            }
            return validator;

            //else if (string.IsNullOrEmpty(lblClassificacao_Id.Text))
            //{
            //    lblClassificacao_Id.Text = "Selecione a Classificação do Filme !!";
            //    rbl1.Focus();
            //    validator = false;
            //}
            //else if (string.IsNullOrEmpty(lblddl1.Text))
            //{
            //    lblddl1.Text = "Selecione o Genero do Filme !!";
            //    ddl1.Focus();
            //    validator = false;
            //}


        }

        public void PopularGVFilme()
        {
            gv1.DataSource = objBLL.ListarFilme();
            gv1.DataBind();
        }


        //Insert / Update
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {
                //dados
                objModeloFilme = new FilmeDTO();
                objModeloFilme.Titulo = txtTitulo.Text.Trim();
                objModeloFilme.Produtora = txtProdutora.Text.Trim();

                //cadastro imagem
                if (fUp1.HasFile)
                {
                    string str = fUp1.FileName;
                    fUp1.PostedFile.SaveAs(Server.MapPath("~/resource/img/" + str));
                    string CaminhoImg = "~/resource/img/" + str.ToString();
                    objModeloFilme.UrlImg = CaminhoImg;
                }
                else
                {
                    lblMessage.Text = "Deu Merda !!";
                }

                //radiobutton
                objModeloFilme.Classificacao_Id = rbl1.SelectedValue;
                //genero
                objModeloFilme.Genero_Id = ddl1.SelectedValue;


                if (string.IsNullOrEmpty(txtId.Text))
                {
                    //passando objeto preenchido no metodo cadastrar
                    objBLL.CadastrarFilmeBLL(objModeloFilme);
                    PopularGVFilme();
                    lblMessage.Text = $"Filme {objModeloFilme.Titulo} Cadastrado com sucesso";
                    Limpar.ClearControl(this);
                    txtSearchFilm.Focus();
                }

                else
                {
                    //passando objeto preenchido no metodo editar
                    objModeloFilme.Id = int.Parse(txtId.Text);
                    objBLL.UpdateFilm(objModeloFilme);
                    PopularGVFilme();
                    Limpar.ClearControl(this);
                    txtSearchFilm.Focus();
                    lblMessage.Text = $"Filme {objModeloFilme.Titulo} Editado com sucesso";

                }
            }


        }

        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.CarregarDDList();
            ddl1.DataBind();
        }

        //busca name
        public void SearchFilme()
        {
            string objSearch = txtSearchFilm.Text;

            objModeloFilme = objBLL.SearchByNameFilm(objSearch);
            txtId.Text = objModeloFilme.Id.ToString();
            txtTitulo.Text = objModeloFilme.Titulo.ToString();
            txtProdutora.Text = objModeloFilme.Produtora.ToString();
            lblfUp1.Text = objModeloFilme.UrlImg.ToString();
            lblClassificacao_Id.Text = objModeloFilme.Classificacao_Id.ToString();
            ddl1.SelectedValue = objModeloFilme.Genero_Id.ToString();
            txtSearchFilm.Text = string.Empty;
            txtTitulo.Focus();

        }

        protected void btnSearchFilm_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchFilm.Text))
            {
                lblSearchFilm.Text = "Digite a Busca !!";
                txtSearchFilm.Focus();
                return;
            }
            SearchFilme();
            lblSearchFilm.Text = string.Empty;
        }

        //search by id
        public void CarregaDados()
        {
            int objSearch = int.Parse(txtId.Text);

            objModeloFilme = objBLL.SearchByIdFilm(objSearch);
            txtId.Text = objModeloFilme.Id.ToString();
            txtTitulo.Text = objModeloFilme.Titulo.ToString();
            txtProdutora.Text = objModeloFilme.Produtora.ToString();
            lblfUp1.Text = objModeloFilme.UrlImg.ToString();
            lblClassificacao_Id.Text = objModeloFilme.Classificacao_Id.ToString();
            ddl1.SelectedValue = objModeloFilme.Genero_Id.ToString();
        }

        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //passando a linha selecionada para a tela
            txtId.Text = gv1.SelectedRow.Cells[1].Text;
            CarregaDados();
            PopularDDL1();
        }

        //delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objModeloFilme.Id = int.Parse(txtId.Text);
            objBLL.DeleteUser(objModeloFilme.Id);
            PopularGVFilme();
            Limpar.ClearControl(this);
        }

        //Clear
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            PopularGVFilme();
            Limpar.ClearControl(this);
            txtSearchFilm.Focus();
        }

        public void FiltrarGVFilme()
        {
            string objFilter = txtFiltro.Text;
            gv1.DataSource = objBLL.FiltarFilmeBLL(objFilter);
            gv1.DataBind();

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            string objFilter = txtFiltro.Text;
            var result = objBLL.FiltarFilmeBLL(objFilter);

            if (string.IsNullOrEmpty(txtFiltro.Text) || (result.Count == 0))
            {
                lblFiltro.ForeColor = System.Drawing.Color.White;
                Limpar.ClearControl(this);
                lblFiltro.Text = "Digite um gênero existente !!";
                txtFiltro.Focus();
                PopularGVFilme();
            }
            else
            {
                FiltrarGVFilme();
                Limpar.ClearControl(this);
                txtFiltro.Focus();
            }
        }
    }
}