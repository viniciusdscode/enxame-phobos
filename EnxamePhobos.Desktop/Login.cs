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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnfechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
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
                if (usuario != null)
                {
                    switch (usuario.TipoUsuario_id)
                    {
                        case "1":
                            Session.nomeUsuario = txtNome.Text.Trim();
                            FrmMain obj = new FrmMain();
                            obj.Show();
                            this.Visible = false;
                            break;
                        case "2":
                            Session.nomeUsuario = txtNome.Text.Trim();
                            FrmMainOutros objOutros = new FrmMainOutros();
                            objOutros.Show();
                            this.Visible = false;
                            break;


                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Usuario não cadastrado !!", "Atenção", MessageBoxButtons.OK);
                Limpar.ClearControl(this);
                txtNome.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            txtNome.Focus();
        }


    }

}
