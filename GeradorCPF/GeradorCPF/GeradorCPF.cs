using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GeradorCPF
{
    public partial class GeradorCPF : Form
    {
        //Iniciando o programa:
        public GeradorCPF()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.ActiveControl = btnBug;
            txtCPF.TextAlign = HorizontalAlignment.Center;
        }

        //Instanciand o objeto "m" na classe que manipula o CPF:
        ManipulaCPF m = new ManipulaCPF();

        //TextBox onde se encontra o CPF:
        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = btnBug;
        }

        //Botão que gera o CPF ao ser clicado:
        private void btnGerar_Click(object sender, EventArgs e)
        {
            txtCPF.Text = m.GerarCpf();
            this.ActiveControl = btnBug;
        }

        //Botão que copia o texto do CPF para a área de transfêrencia:
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtCPF.Text);
            } 
            catch
            {
                txtCPF.Text = "";
            }
            
            this.ActiveControl = btnBug;
        }
    }
}
