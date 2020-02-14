﻿using System;
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
    public partial class MainMenu : Form
    {
       // public Player newPlayer = new Player();
        public MainMenu()
        {
            InitializeComponent();
            
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            var newForm = new Game();
            newForm.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void highscoreBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
