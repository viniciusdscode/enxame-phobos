using EnxamePhobos.BLL;
using EnxamePhobos.DDO;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Session.nomeUsuario} ,sua sessão será encerrada !!", "Atenção", MessageBoxButtons.OK);
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Session.nomeUsuario} ,sua sessão será encerrada !!", "Atenção", MessageBoxButtons.OK);
            Application.Exit();
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            lblSession.Text = $"Seja Bem Vindo {Session.nomeUsuario} a Enxame Phobos Anomaly!! Sua sessão iniciou às {DateTime.Now.ToString("t")}";
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastrarUsuario obj = new FrmCadastrarUsuario();
            obj.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastrarUsuario obj = new FrmCadastrarUsuario();
            obj.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmEditUsuario obj = new FrmEditUsuario();
            obj.ShowDialog();
        }

        private void usuarioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmUsuario obj = new FrmUsuario();
            obj.ShowDialog();
        }

        private void usuarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmExcluirUsuario obj = new FrmExcluirUsuario();
            obj.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            FrmExcluirUsuario obj = new FrmExcluirUsuario();
            obj.ShowDialog();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEditUsuario obj = new FrmEditUsuario();
            obj.ShowDialog();
        }

        private void filmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastrarFilme obj = new FrmCadastrarFilme();
            obj.ShowDialog();
        }

        private void filmeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEditFilme obj = new FrmEditFilme();
            obj.ShowDialog();
        }

        private void filmeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmExcluirFilme obj = new FrmExcluirFilme();
            obj.ShowDialog();
        }

        private void filmeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmFilme obj = new FrmFilme();
            obj.ShowDialog();
        }
    }
}
