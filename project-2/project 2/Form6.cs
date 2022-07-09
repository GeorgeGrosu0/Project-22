using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project_2;

namespace project_2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jsCopy = project_2.Form5.jsonData;
            if (jsCopy != null)
            {
                string fileName = "date_universitati.txt";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);//sterg fisierul anterior
                }
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    foreach (var item in jsCopy)
                    {
                        sw.WriteLine(item.name + "\t" + item.country + "\t" + item.alpha_two_code + "\t" + item.web_pages[0]);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Nu exista date");//ex:apare dac adau pe csv inainte dd universitati
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
