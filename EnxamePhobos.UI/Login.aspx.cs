using EnxamePhobos.BLL;
using EnxamePhobos.DDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            lblMessage.Font.Size = 25;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //instanciando objetos
                UsuarioDTO usuario = new UsuarioDTO();
                UsuarioBLL objBLL = new UsuarioBLL();

                //pegando os dados do usuario
                string objNome = txtNome.Text;
                string objSenha = txtSenha.Text;

                //chamar o metodo BLL
                usuario = objBLL.AutenticarUsuario(objNome, objSenha);

                //checar tipo usuario
                if (usuario!=null)
                {
                    switch (usuario.TipoUsuario_id)
                    {
                        case "1":
                            Session["Usuario"] = txtNome.Text.Trim();
                            Response.Redirect("adm/ManageUser.aspx");
                            //lblMessage.Text = "Administrador";
                            break;
                        case "2":
                            Session["Usuario"] = txtNome.Text.Trim();
                            Response.Redirect("user/ConsultaUser.aspx");
                            //lblMessage.Text = "Outros";
                            break;
                    }
                }
                else
                {
                    lblMessage.Text = "Usuário não cadastrado!";
                }

            }
            catch (Exception)
            {
                lblMessage.Text = "Usuário não cadastrado!";
            }
        }
    }
}