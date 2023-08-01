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
    public partial class FrmExcluirUsuario : Form
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objModelo = new UsuarioDTO();


        public FrmExcluirUsuario()
        {
            InitializeComponent();
        }

        public void PopularCBO()
        {
            

            cbo1.DataSource = objBLL.CarregaDDList();
            cbo1.ValueMember = "Id";
            cbo1.DisplayMember = "Descricao";
            cbo1.Refresh();

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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            txtSearch.Focus();
        }

        private void FrmExcluirUsuario_Load(object sender, EventArgs e)
        {
            cpInativo();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
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
            cpInativo();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show($"Deseja excluir {objModelo.Nome}?", "Atenção", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                objModelo.Id = int.Parse(txtId.Text);
                objBLL.DeleteUser(objModelo.Id);
                txtData.Text = string.Empty;
                cbo1.Text = string.Empty;
                Limpar.ClearControl(this);
                MessageBox.Show($"Usuario {objModelo.Nome} Excluido !!!");
            }
            else if (confirmar == DialogResult.No)
            {
                FrmExcluirUsuario obj = new FrmExcluirUsuario();
                obj.ShowDialog();
            }

        }

    }
}

