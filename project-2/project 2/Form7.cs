using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_2
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = GetHtmlCode();//apelez functia de gasire a https ului 
            if (html == "")//daca e gol https ul 
            {
                MessageBox.Show("Google search anything!");
            }



            ////FOLOSESC variabila g drept contor care creste , adnotand fiecare poza cu g , avand astfel 
            ///denumiri diferite ale pozelor (ex pngfhjfbf1  ,dufnubbn2)

            List<string> urls = GetUrls(html);
            var dist = 5;
            int g = 0, coloana = 5;

            //locatia noului panel:
            var panel1 = new Panel();

            panel1.Size = new Size(700, 350);
            this.Controls.Add(panel1);

            panel1.Location = new Point(20, 50);


            foreach (var item in urls)
            {

                SaveImage(item, "image" + g, ImageFormat.Png);
                var pb = new PictureBox();
                if (coloana + 130 > panel1.Width)
                {
                    dist += 140;
                    coloana = 0;
                }
                pb.Load(item);
                pb.SizeMode = PictureBoxSizeMode.Normal;
                pb.Size = new Size(100, 100);
                pb.Location = new Point(coloana, dist);

                panel1.Controls.Add(pb);


                coloana += 140; g++;
            }
            panel1.AutoScroll = true;
        }


        private string GetHtmlCode()// functie de luat httpul din pagina ca dupa sa deserializez
        {
            if (textBox1.Text != "") //daca e ceva de cautat :
            {
                string url = "https://www.google.com/search?q=" + textBox1.Text + "&tbm=isch";//asa o asa arate urlul paginii cu imagini
                string data = "";

                var request = (HttpWebRequest)WebRequest.Create(url);//ma pregatesc pt web requestul paginii cu imaginile
                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return "";
                    using (var sr = new StreamReader(dataStream))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                return data;
            }
            else
            {
                return "";
            }
        }


        private void SaveImage(string imageUrl, string filename, ImageFormat format)//functie salvare
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        private List<string> GetUrls(string html)
        {
            var urls = new List<string>();

            int numehttps = html.IndexOf("src=\"https", StringComparison.Ordinal);

            while (numehttps >= 0)// iau linkurile  pozelor 
            {
                numehttps = html.IndexOf("\"", numehttps + 4, StringComparison.Ordinal);
                numehttps++;
                int partofhttps = html.IndexOf("\"", numehttps, StringComparison.Ordinal);
                string url = html.Substring(numehttps, partofhttps - numehttps);//fac diferenta pt a ajunge 
                urls.Add(url);
                numehttps = html.IndexOf("src=\"https", partofhttps, StringComparison.Ordinal);
            }
            return urls;
        }
    }
}

