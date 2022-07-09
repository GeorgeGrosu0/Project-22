using System.Diagnostics;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
namespace project_2
{
    public partial class Form5 : Form
    {
        public static List<Universitate> jsonData;//variab globala
        
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }
        //Deserelizare cu JSON (OBIECT-STRING)  :
         public void ThreadUniversitati()
        {
            var client = new HttpClient();
            var ep = new Uri("http://universities.hipolabs.com/search?name=middle");
            var res = client.GetAsync(ep).Result;
            var JSON = res.Content.ReadAsStringAsync().Result;//bag in json tot textul
            jsonData = JsonConvert.DeserializeObject<List<Universitate>>(JSON);

            if (res != null)//daca s-au pus obiectele in res , afisam in labeluri itemele :
            {
                var dist = 0;
                foreach (var item in jsonData)
                {
                    Label lb1 = new Label();
                    lb1.Text = item.name;
                    lb1.Location = new Point(13, dist + 12);
                    lb1.AutoSize = true;
                    lb1.Click += (s, e) =>
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            string url = item.web_pages[0];//accesezx primul website
                            url = url.Replace("&", "^&");
                            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });//porneste webul cu linkul de pe itemul apasat
                        }
                    };

                    Label lb2 = new Label();
                    lb2.Text = item.country;
                    lb2.Location = new Point(10, dist + 30);
                    lb2.AutoSize = true;
                    lb2.Click += (s, e) =>
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            string url = item.web_pages[0];
                            url = url.Replace("&", "^&");
                            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                        }
                    };

                    Label lb3 = new Label();
                    lb3.Text = item.alpha_two_code;
                    lb3.Location = new Point(10, dist + 50);
                    lb3.AutoSize = true;
                    lb3.Click += (s, e) =>
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            string url = item.web_pages[0];
                            url = url.Replace("&", "^&");
                            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                        }
                    };

                    dist += 70;
                    this.Invoke(new MethodInvoker(delegate ()//this invoke = ii spun formei ce sa faca 
                    {
                        this.Controls.Add(lb1); this.Controls.Add(lb2); this.Controls.Add(lb3);
                        this.AutoScroll = true;
                    }
                    ));
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Dispose();
            ThreadStart George = new ThreadStart(ThreadUniversitati);
            Thread thread = new Thread(ThreadUniversitati);
            thread.Start();
        }


        public class Universitate
        {
            public string[] web_pages { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string alpha_two_code { get; set; }
        }

    }
}
