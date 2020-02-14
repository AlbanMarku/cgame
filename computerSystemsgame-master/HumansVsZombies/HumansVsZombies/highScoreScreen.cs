using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumansVsZombies
{
    public partial class highScoreScreen : Form
    {
        public highScoreScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\alban\Downloads\test.txt");
            sw.WriteLine(inputNameBox);
            sw.Close();


            StreamReader sr = new StreamReader(@"C:\Users\alban\Downloads\test.txt");
            richTextBox1.Text = sr.ReadToEnd();

            sr.Close();
        }
    }
}
