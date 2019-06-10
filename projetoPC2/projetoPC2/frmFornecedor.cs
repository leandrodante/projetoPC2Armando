using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoPC2
{
    public partial class frmFornecedor : Form
    {
        bool set_cnpj = false;
        bool set_email = false;
        public frmFornecedor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            toHome();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toHome();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        void Limpar()
        {
            txtName.Text = "";
            txtTel.Text = "";
            txtContato.Text = "";
            txtEmail.Text = "";
            txtCNPJ.Text = "";
            txtObs.Text = "";
            set_cnpj = false;
            set_email = false;
            txtEmail.BackColor = Color.White;
            txtCNPJ.BackColor = Color.White;
        }
        void toHome()
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
           
        }

        private void validarCNPJ(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ.Text;
            if (Validations.IsCnpj(cnpj))
            {
                txtCNPJ.BackColor = Color.LightGreen;
                set_cnpj = true;
            }
            else
            {

                MessageBox.Show("CNPJ Inválido!");
                txtCNPJ.BackColor = Color.LightYellow;
                set_cnpj = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        void Salvar()
        {
           string cnpj = txtCNPJ.Text;
           string contato = txtContato.Text;
           string email = txtEmail.Text;
           string name = txtName.Text;
           string tel = txtTel.Text;
           string obs = txtObs.Text;
            if (set_cnpj && set_email)
            {
                StreamWriter wtr = new StreamWriter("C:\\projetoPC2\\fornecedor.txt", true);
                wtr.WriteLine(name + "," + tel + "," + contato + "," + email + "," + cnpj + "," + obs);
                wtr.Close();
                MessageBox.Show("Fornecedor Cadastrado!");
                Limpar();
            }
            else
            {
                MessageBox.Show("Preencha os campos corretamente!");
            }
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
