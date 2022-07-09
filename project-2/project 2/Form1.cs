namespace project_2
{
    public partial class Form1 : Form
    {





        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        public static class ThemeColor
        {
            public static Color PrimaryColor { get; set; }
            public static Color SecondaryColor { get; set; }
            public static List<string> ColorList = new List<string>() { "#3F51B5",
                                                                    "#009688",
                                                                    "#FF5722",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#EA676C",
                                                                    "#E41A4A",
                                                                    "#5978BB",
                                                                    "#018790",
                                                                    "#0E3441",
                                                                    "#00B0AD",
                                                                    "#721D47",
                                                                    "#EA4833",
                                                                    "#EF937E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#126881",
                                                                    "#8BC240",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0094BC",
                                                                    "#E4126B",
                                                                    "#43B76E",
                                                                    "#7BCFE9",
                                                                    "#B71C46"};
            public static Color ChangeColorBrightness(Color color, double correctionFactor)
            {
                double red = color.R;
                double green = color.G;
                double blue = color.B;
                //If correction factor is less than 0, darken color.
                if (correctionFactor < 0)
                {
                    correctionFactor = 1 + correctionFactor;
                    red *= correctionFactor;
                    green *= correctionFactor;
                    blue *= correctionFactor;
                }
                //If correction factor is greater than zero, lighten color.
                else
                {
                    red = (255 - red) * correctionFactor + red;
                    green = (255 - green) * correctionFactor + green;
                    blue = (255 - blue) * correctionFactor + blue;
                }
                return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Show();
        }

        public static implicit operator Form1(Form3 v)
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form6 = new Form6();
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form7 = new Form7();
            form7.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(project_2.Form5.jsonData == null)
            {
                MessageBox.Show("Nu s-a facut requestul!");
            } else
            {
                var form8 = new Form8();
                form8.Show();
                this.Hide();
            }
        }
    }
}