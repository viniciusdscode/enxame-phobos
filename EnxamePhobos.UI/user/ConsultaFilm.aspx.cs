using EnxamePhobos.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.user
{
    public partial class ConsultaFilm : System.Web.UI.Page
    {

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
    }
}