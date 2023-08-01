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
    public partial class FrmCadastrarUsuario : Form
    {

        TipoUsuarioDTO objTpUsuario = new TipoUsuarioDTO();
        UsuarioDTO objModelo = new UsuarioDTO();
        UsuarioBLL objBLL = new UsuarioBLL();

        public FrmCadastrarUsuario()
        {
            InitializeComponent();
        }

        public void PopularCBO()
        {

            cbo1.DataSource = objBLL.CarregaDDList();
            cbo1.ValueMember = "Id";
            cbo1.DisplayMember = "Descricao";
            cbo1.DataSource.ToString();

        }

        private void FrmCadastrarUsuario_Load(object sender, EventArgs e)
        {
            PopularCBO();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            txtData.Text = string.Empty;
            txtNome.Focus();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {
                UsuarioDTO objCad = new UsuarioDTO();

                objCad.Nome = txtNome.Text.Trim();
                objCad.Email = txtEmail.Text.Trim();
                objCad.Senha = txtSenha.Text.Trim();
                objCad.DataNascUsuario = DateTime.Parse(txtData.Text);
                objCad.TipoUsuario_id = cbo1.SelectedValue.ToString();

                UsuarioBLL objCadastraUsuario = new UsuarioBLL();
                objCadastraUsuario.CadastrarUsuario(objCad);
                Limpar.ClearControl(this);
                txtData.Text = string.Empty;
                txtNome.Focus();

                MessageBox.Show($"Usuário {objCad.Nome} cadastrado com sucesso !!");

            }

        }

        public bool ValidatePage()
        {
            bool validator;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.BackColor = Color.Red;
                MessageBox.Show("Digite o Nome !!", "Atenção", MessageBoxButtons.OK);
                txtNome.BackColor = DefaultBackColor;
                txtNome.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Red;
                MessageBox.Show("Digite o Email !!", "Atenção", MessageBoxButtons.OK);
                txtEmail.BackColor = DefaultBackColor;
                txtEmail.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.BackColor = Color.Red;
                MessageBox.Show("Digite a Senha !!", "Atenção", MessageBoxButtons.OK);
                txtSenha.BackColor = DefaultBackColor;
                txtSenha.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtData.Text) || txtData.Text.Length < 10)
            {
                txtData.BackColor = Color.Red;
                MessageBox.Show("Digite a Data De Nascimento !!", "Atenção", MessageBoxButtons.OK);
                txtData.BackColor = DefaultBackColor;
                txtData.Focus();
                validator = false;
            }
            else
            {
                validator = true;
            }
            return validator;

        }

    }
}
