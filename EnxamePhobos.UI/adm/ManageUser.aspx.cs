using EnxamePhobos.BLL;
using EnxamePhobos.DDO;
using EnxamePhobos.UI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class ManageUser : System.Web.UI.Page
    {
        UsuarioDTO objModelo = new UsuarioDTO();
        UsuarioBLL objBLL = new UsuarioBLL();

        //popular DropDownList
        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.CarregaDDList();
            ddl1.DataBind();
        }

        //popular gridview
        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarUsuario();
            gv1.DataBind();
        }

        //search by name
        public void Search()
        {
            string objSearch = txtSearch.Text;
            objModelo = objBLL.SearchByName(objSearch);
            txtId.Text = objModelo.Id.ToString();
            txtNome.Text = objModelo.Nome.ToString();
            txtEmail.Text = objModelo.Email.ToString();
            txtSenha.Text = objModelo.Senha.ToString();
            txtDtNasc.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objModelo.TipoUsuario_id.ToString();
            txtSearch.Text = string.Empty;
            txtNome.Focus();
        }

        //search by id
        public void CarregaDados()
        {
            int objSearch = int.Parse(txtId.Text);

            objModelo = objBLL.SearchById(objSearch);
            txtId.Text = objModelo.Id.ToString();
            txtNome.Text = objModelo.Nome.ToString();
            txtEmail.Text = objModelo.Email.ToString();
            txtSenha.Text = objModelo.Senha.ToString();
            txtDtNasc.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objModelo.TipoUsuario_id.ToString();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtId.Enabled = false;
                PopularDDL1();
                PopularGV();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblSearch.Text = "Digite a Busca !!";
                txtSearch.Focus();
                return;
            }
            Search();
            lblSearch.Text = string.Empty;
        }

        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //passando a linha selecionada para a tela
            txtId.Text = gv1.SelectedRow.Cells[1].Text;
            CarregaDados();
            PopularDDL1();

        }

        //VALIDATION
        public bool ValidatePage()
        {
            bool validator;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblNome.Text = "Digite o Nome !!";
                txtNome.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblEmail.Text = "Digite o Email !!";
                txtEmail.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                lblSenha.Text = "Digite o Senha !!";
                txtSenha.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtDtNasc.Text))
            {
                lblDtNasc.Text = "Digite o Data De Nascimento !!";
                txtDtNasc.Focus();
                validator = false;
            }
            else
            {
                validator = true;
            }
            return validator;

        }


        //CRUD - Insert / Update
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {
                //preenchendo dados
                objModelo = new UsuarioDTO();
                objModelo.Nome = txtNome.Text.Trim();
                objModelo.Email = txtEmail.Text.Trim();
                objModelo.Senha = txtSenha.Text.Trim();
                //ajustando data
                DateTime dt = DateTime.Parse(txtDtNasc.Text);
                objModelo.DataNascUsuario = dt;
                objModelo.TipoUsuario_id = ddl1.SelectedValue;

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    //passando objeto preenchido no metodo cadastrar
                    objBLL.CadastrarUsuario(objModelo);
                    PopularGV();
                    lblMessage.Text = $"Usuário {objModelo.Nome} cadastrado com sucesso !!";
                    Limpar.ClearControl(this);
                    txtSearch.Focus();
                }

                else
                {
                    //passando objeto preenchido no metodo editar
                    objModelo.Id = int.Parse(txtId.Text);
                    objBLL.UpdateUser(objModelo);
                    PopularGV();
                    Limpar.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"Usuário {objModelo.Nome} editado com sucesso !!";

                }
            }

        }

        //CRUD - Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objModelo.Id = int.Parse(txtId.Text);
            objBLL.DeleteUser(objModelo.Id);
            PopularGV();
            Limpar.ClearControl(this);
        }

        //Clear
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            PopularGV();
            Limpar.ClearControl(this);
            txtSearch.Focus();
        }
    }
}
