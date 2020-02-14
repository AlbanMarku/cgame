using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HumansVsZombies
{
    
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
            loadingScreentimer.Start();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
       
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void loadingScreentimer_Tick(object sender, EventArgs e)
        {
            progressBar2.Increment(5);

           


            
            if (progressBar2.Value >= progressBar2.Maximum)
            {
                loadingScreentimer.Stop();// stop the timer
                Hide();
                var newForm = new MainMenu();
                newForm.Show();
            }
        }
    }
}
