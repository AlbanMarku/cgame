using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HumansVsZombies
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)//change the event to a button click or something else isntead of rtb change
        {
            string filepath = @"C:\Users\alban\Desktop\computerSystemsgame-master\HumansVsZombies\scores.rtf";//change to your location on pc.
            List<Person> people = new List<Person>();
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Person newPerson = new Person();
                newPerson.Name = entries[0];
                newPerson.Name = entries[1];
            }
            lines.Add("Sue,365");//this is a line to show it can write into the txt file. Replace with the name and score variable from the player.
            File.WriteAllLines(filepath, lines);
        }
    }
}
