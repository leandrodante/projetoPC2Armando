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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCliente frmcli = new frmCliente();
            frmcli.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFornecedor frmforn = new frmFornecedor();
            frmforn.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProduto frmprod = new frmProduto();
            frmprod.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        Timer t = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer interval
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method

            VerificarArqs();
            CarregarDashboard();
            
        }
        void CarregarDashboard()
        {
            var lineCount = File.ReadLines(@"C:\projetoPC2\cliente.txt").Count();
            lblCliC.Text = lineCount.ToString();
            lineCount = File.ReadLines(@"C:\projetoPC2\fornecedor.txt").Count();
            lblForC.Text = lineCount.ToString();
            lineCount = File.ReadLines(@"C:\projetoPC2\produto.txt").Count();
            lblProdC.Text = lineCount.ToString();
        }
        //timer eventhandler
        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            lblClock.Text = time;
        }

        void VerificarArqs()
        {
            string path = @"C:\projetoPC2";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string pathC = @"C:\projetoPC2\cliente.txt";
            if (!File.Exists(pathC))
            {
                StreamWriter sw = new StreamWriter(pathC,true);
                sw.Close();
            }
            string pathF = @"C:\projetoPC2\fornecedor.txt";
            if (!Directory.Exists(pathF))
            {
                StreamWriter sw = new StreamWriter(pathF,true);
                sw.Close();
            }
            string pathP = @"C:\projetoPC2\produto.txt";
            if (!Directory.Exists(pathP))
            {
                StreamWriter sw = new StreamWriter(pathP,true);
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sobre Nós:\nArmando Wendel 3013588\nEdilson Silva 3021939\nFelipe Augusto 3016218\nRaul Franquella 1473972");
        }
    }
}
