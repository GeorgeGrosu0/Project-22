using Microsoft.Win32;
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

namespace project_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
        

        private void button2_Click(object sender, EventArgs e)
        {

            ThreadStart td = new ThreadStart(Thread);
            Thread tdr = new Thread(td);
            tdr.Start();
            regKey.SetValue("sShortTime", "h:mm");
            var wExp = Process.GetProcessesByName("explorer");
            foreach (var exp in wExp)
            {
                exp.Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart td = new ThreadStart(Thread);
            Thread tdr = new Thread(td);
            tdr.Start();
            regKey.SetValue("sShortTime", "h:mm tt");
            var wExp = Process.GetProcessesByName("explorer");
            foreach (var exp in wExp)
            {
                exp.Kill();
            }
        }

        public void Thread()
        {
            Label lbl = new Label();
            lbl.Location = new Point(10, 10);
            lbl.Text = System.DateTime.Now.ToString(regKey.GetValue("sShortTime").ToString());

            this.Invoke(new MethodInvoker(delegate ()
            {
                this.Controls.Add(lbl);
            }
            ));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
