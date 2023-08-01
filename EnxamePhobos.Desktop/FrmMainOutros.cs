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
    public partial class FrmMainOutros : Form
    {
        public FrmMainOutros()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarioOutros obj = new FrmUsuarioOutros();
            obj.ShowDialog();
        }

        private void btnFilmes_Click(object sender, EventArgs e)
        {

        }
        private void usuarioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmUsuarioOutros obj = new FrmUsuarioOutros();
            obj.ShowDialog();
        }

        private void filmeToolStripMenuItem3_Click(object sender, EventArgs e)
        {

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


        private void btnSair_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Session.nomeUsuario} ,sua sessão será encerrada !!", "Atenção", MessageBoxButtons.OK);
            Application.Exit();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Session.nomeUsuario} ,sua sessão será encerrada !!", "Atenção", MessageBoxButtons.OK);
            Application.Exit();
        }

        private void FrmMainOutros_Load(object sender, EventArgs e)
        {
            lblSession.Text = $"Seja Bem vindo {Session.nomeUsuario} a Enxame Phobos Anomaly!! sua sessão foi iniciada às {DateTime.Now.ToString("t")}";
        }

    }
}
