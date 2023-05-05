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
            PopularGV();
        }

        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarFilme();
            gv1.DataBind();
        }

        //search by name
        public void Search()
        {
            string objSearch = txtSearchFilm.Text;
            objModeloFilme = objBLL.SearchByFilm(objSearch);
            txtId.Text = objModeloFilme.Id.ToString();
            txtTitulo.Text = objModeloFilme.Titulo.ToString();
            txtProdutora.Text = objModeloFilme.Produtora.ToString();
            txtUrl.Text = objModeloFilme.UrlImg.ToString();
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
            Search();
            lblSearchFilm.Text = string.Empty;
        }


    }
}