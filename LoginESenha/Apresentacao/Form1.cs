using LoginESenha.Apresentacao;
using LoginESenha.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginESenha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastreSe_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txtlogin.Text, txtSenha.Text);
            if (controle.mensagem.Equals(""))
            {


                if (controle.tem)
                {
                    MessageBox.Show("logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BemVindo bv = new BemVindo();
                    bv.Show();
                }
                else
                {
                    MessageBox.Show("Verifique o Login ou a senha.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
