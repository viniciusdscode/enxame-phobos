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
    public partial class FrmEditUsuario : Form
    {
        UsuarioDTO objModelo = new UsuarioDTO();
        UsuarioBLL objBLL = new UsuarioBLL();

        public FrmEditUsuario()
        {
            InitializeComponent();
        }

        public void FrmEditUsuario_Load(object sender, EventArgs e)
        {
            cpInativo();
        }

        public void PopularCBO()
        {
            
            cbo1.DataSource = objBLL.CarregaDDList();
            cbo1.ValueMember = "Id";
            cbo1.DisplayMember = "Descricao";
            cbo1.Refresh();

        }

        public void SearchName()
        {
            string objSearch = txtSearch.Text;

            objModelo = objBLL.SearchByNameDesk(objSearch);
            txtId.Text = objModelo.Id.ToString();

            txtNome.Text = objModelo.Nome.ToString();
            txtEmail.Text = objModelo.Email.ToString();
            txtSenha.Text = objModelo .Senha.ToString();
            txtData.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
            cbo1.SelectedText = objModelo.TipoUsuario_id.ToString();

            txtSearch.Text = string.Empty;
            txtNome.Focus();
        }

        public void btnPesquisar_Click(object sender, EventArgs e)
        {
            string objSearch = txtSearch.Text;

            objModelo = objBLL.SearchByNameDesk(objSearch);
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtNome.Text = string.Empty;
                txtNome.BackColor = Color.Red;
                MessageBox.Show("O nome não existe ou o campo está vazio !!", "Atenção !!", MessageBoxButtons.OK);
                txtNome.BackColor = DefaultBackColor;
                txtNome.Focus();
                return;
            }
            else if (objModelo != null)
            {
                txtId.Text = objModelo.Id.ToString();
                txtNome.Text = objModelo.Nome;
                txtEmail.Text = objModelo.Email;
                txtSenha.Text = objModelo.Senha;
                txtData.Text = objModelo.DataNascUsuario.ToString();
                cbo1.SelectedText = objModelo.TipoUsuario_id;
            }
            cpAtivo();

        }

        public void btnSalvar_Click(object sender, EventArgs e)
        {
            
            objModelo = new UsuarioDTO();

            objModelo.Id = Convert.ToInt32(txtId.Text);
            objModelo.Nome = txtNome.Text.Trim();
            objModelo.Email = txtEmail.Text.Trim();
            objModelo.Senha = txtSenha.Text.Trim();
            objModelo.DataNascUsuario = DateTime.Parse(txtData.Text);
            if (cbo1.Text == "Adminastrador")
            {
                objModelo.TipoUsuario_id = "1";
            }
            else if (cbo1.Text == "Outros")
            {
                objModelo.TipoUsuario_id = "2";
            }
            else
            {
                MessageBox.Show("Tipo de usuário inválido !!");
                cbo1.SelectedText = string.Empty;
                cbo1.Focus();
                return;
            }

            UsuarioBLL objBLL = new UsuarioBLL();
            objBLL.UpdateUser(objModelo);
            Limpar.ClearControl(this);
            txtData.Text = string.Empty;
            cbo1.Text = string.Empty;
            txtSearch.Focus();

            MessageBox.Show($"Usuário {objModelo.Nome} editado com sucesso !!","Sucesso", MessageBoxButtons.OK );

            cpInativo();
        }

        public void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            cbo1.Text = string.Empty;
            txtData.Text = string.Empty;
            cpInativo();
            txtNome.Focus();
        }

        public void cpAtivo()
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtSenha.Enabled = true;
            txtData.Enabled = true;
            cbo1.Enabled = true;
        }

        public void cpInativo()
        {

            txtId.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtSenha.Enabled = false;
            txtData.Enabled = false;
            cbo1.Enabled = false;
        }
    }

}
