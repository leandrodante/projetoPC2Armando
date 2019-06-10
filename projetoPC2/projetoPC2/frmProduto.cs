using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoPC2
{
    public partial class frmProduto : Form
    {
        public frmProduto()
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

        private void button4_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCusto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nome_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        void Limpar()
        {
            txtName.Text = "";
            txtDesc.Text = "";
            txtFornecedor.Text = "";
            txtCusto.Text = "";
            txtObs.Text = "";
        }
        void toHome()
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
           
        }
        void Salvar()
        {
            string nome = txtName.Text;
            string desc = txtDesc.Text;
            string forn = txtFornecedor.Text;
            string custo = txtCusto.Text;
            string obs = txtObs.Text;

            StreamWriter wtr = new StreamWriter("C:\\projetoPC2\\produto.txt", true);
            wtr.WriteLine(nome + "," + desc + "," + forn + "," + custo + "," + obs);
            wtr.Close();
            MessageBox.Show("Produto Cadastrado!");
            Limpar();
        }
        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }

        private void textAlter(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = txtCusto.Text.Replace(",", "")
                .Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                ul /= 100;
                //Unsub the event so we don't enter a loop
                txtCusto.TextChanged -= txtCusto_TextChanged;
                //Format the text as currency
                txtCusto.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                txtCusto.TextChanged += txtCusto_TextChanged;
                txtCusto.Select(txtCusto.Text.Length, 0);
            }
            bool goodToGo = TextisValid(txtCusto.Text);
            //enterButton.Enabled = goodToGo;
            if (!goodToGo)
            {
                txtCusto.Text = "$0.00";
                txtCusto.Select(txtCusto.Text.Length, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
