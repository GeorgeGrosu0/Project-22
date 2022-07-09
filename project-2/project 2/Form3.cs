using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // string[] listadate = System.IO.File.ReadAllLines(letate\bin\Debug\FisierTask-uri.txt");

            string resurse = Properties.Resources.GEORGE_RESURSE;
            string[] vector = resurse.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            label1.Text = vector[0] + " " + vector[1];
            label2.Text = vector[2];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
