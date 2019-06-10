using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace projetoPC2
{
    public partial class frmCliente : Form
    {
        bool set_cpf = false;
        bool set_email = false;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toHome();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toHome();
        }

        void toHome()
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();            
        }
        void Limpar()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCPF.Text = "";
            txtObs.Text = "";
            set_cpf = false;
            set_email = false;
            txtCPF.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
        }
        void Salvar()
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            string cpf = txtCPF.Text;
            string obs = txtObs.Text;
            if (set_cpf && set_email)
            {
                StreamWriter wtr = new StreamWriter("C:\\projetoPC2\\cliente.txt", true);
                wtr.WriteLine(nome + "," + email + "," + telefone + "," +cpf + "," + obs);
                wtr.Close();
                MessageBox.Show("Cliente Cadastrado!");
                Limpar();
            }
            else
            {
                MessageBox.Show("Preencha os campos Corretamente!");
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpar();
        }


        private void validaCPF(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text;
            if (Validations.IsCpf(cpf))
            {
                txtCPF.BackColor = Color.LightGreen;
                set_cpf = true;
            }
            else
            {
                txtCPF.BackColor = Color.LightYellow;
                MessageBox.Show("CPF Inválido!");
                set_cpf = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void validarEmail(object sender, EventArgs e)
        {
            if (Validations.IsEmail(txtEmail.Text))
            {
                txtEmail.BackColor = Color.LightGreen;
                set_email = true;
            }
            else
            {
                MessageBox.Show("Email Inválido!");
                txtEmail.BackColor = Color.LightYellow;
                set_email = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
