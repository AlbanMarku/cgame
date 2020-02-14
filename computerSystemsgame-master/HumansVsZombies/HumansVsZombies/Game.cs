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
    public partial class Game : Form
    {
        Button[,] btn = new Button[51, 51];
        int xpos = 20;
        int ypos = 20;
        Human newHuman = new Human(0, 0, 0, true);
        bool[,] wallLocations = new bool[51, 51]; // to store the location of the walls
        bool[,] coinLocations = new bool[51, 51]; // store locations of a coin
        Zombie[] hoarde = new Zombie[12];
        int zomNumber = 0;
        
      //  Zombie zom1 = new Zombie(13, 13);
        Random r = new Random();
        Player newPlayer = new Player(" temp", 0 ); // change this later 
        public Game()
        {
            InitializeComponent();
            // grid generator 


            for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
            {
                for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
                {

                    btn[x, y] = new Button();
                    btn[x, y].SetBounds((10 * x) + 220, (10 * y) + 30, 10, 10);
                    btn[x, y].TabStop = false;
                    btn[x, y].FlatStyle = FlatStyle.Flat;
                    btn[x, y].FlatAppearance.BorderSize = 0;
                    btn[x, y].BackColor = Color.White;
                    Controls.Add(btn[x, y]);
                    wallLocations[x, y] = false;
                    coinLocations[x, y] = false;
                }
            }
            addWalls();
            //addZombies(zom1, 13, 13);
            for(int i =0; i < hoarde.Length;i ++)
            {
                hoarde[i] = new Zombie(14,14);
            }
            addCoins();
            gameTimer.Start();
            label1.Text = "Items collected: " + newPlayer.playerScore;






        }
        public void addZombies( Zombie newZombie, int x, int y)
        {
            newZombie.zombieXLocation = x;
            newZombie.zombieYLocation = y;
            btn[x, y].BackColor = Color.Green;

        }
        public void moveZombies(Zombie zom)
        {
            int tempx, tempy;
            tempx = zom.zombieXLocation;
            tempy = zom.zombieYLocation;
            if (( zom.zombieXLocation >xpos)&&(wallLocations[tempx-1, tempy] != true))
            {
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.White;
                zom.zombieXLocation--;
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.Green;

            }
            if ((zom.zombieXLocation < xpos)&& (wallLocations[tempx+1, tempy] != true))
            {
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.White;
                zom.zombieXLocation++;
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.Green;

            }
            if ((zom.zombieYLocation > ypos)&& (wallLocations[tempx, tempy-1] != true))
            {
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.White;
                zom.zombieYLocation--;
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.Green;

            }
            if ((zom.zombieYLocation < ypos)&& (wallLocations[tempx, tempy+1] != true))
            {
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.White;
                zom.zombieYLocation++;
                btn[zom.zombieXLocation, zom.zombieYLocation].BackColor = Color.Green;

            }
            if((zom.zombieXLocation == newHuman.humanXLocation)&&(zom.zombieYLocation == newHuman.humanYLocation))
            {
               // MessageBox.Show("Youve been eaten!");
                gameTimer.Stop();
            }
            

        }
        private void addCoins()
        {
            int posx;
            int posy;
            do
            {
                posx = r.Next(1, 50);
                posy = r.Next(1, 50);

            }
            while (wallLocations[posx, posy] == true);
            coinLocations[posx, posy] = true;
            btn[posx, posy].BackColor = Color.Gold;





        }
        private void addWalls()
        {
            int limitOneBlock = r.Next(30, 70);
            int limitMouthBlock = r.Next(10, 40);
            int limitLineBLock = r.Next(10, 20);
            while (limitOneBlock < 100)//Affects amount of one blocks
            {
                int posx = r.Next(1, 50);
                int posy = r.Next(1, 50);
                limitOneBlock++;
                for (int i = 0; i < btn.GetLength(0); i++)
                {
                    for (int j = 0; j < btn.GetLength(1); j++)
                    {
                        if (btn[posx - 1, posy].BackColor != Color.FromName("red") && btn[posx + 1, posy].BackColor != Color.FromName("red") && btn[posx, posy - 1].BackColor != Color.FromName("red") && btn[posx, posy + 1].BackColor != Color.FromName("red"))
                        {
                            btn[posx, posy].BackColor = Color.Red;
                            wallLocations[posx, posy] = true;
                        }
                    }
                }

            }
            while (limitMouthBlock < 50)
            {
                int posx = r.Next(1, 48);
                int posy = r.Next(1, 50);
                limitMouthBlock++;
                for (int i = 0; i < btn.GetLength(0); i++)
                {
                    for (int j = 0; j < btn.GetLength(1); j++)
                    {
                        if (i != 0 && btn[posx - 1, posy].BackColor != Color.FromName("red") && btn[posx + 1, posy].BackColor != Color.FromName("red") && btn[posx, posy - 1].BackColor != Color.FromName("red") && btn[posx, posy + 1].BackColor != Color.FromName("red"))
                        {
                            btn[posx, posy].BackColor = Color.Red;
                            btn[posx, posy - 1].BackColor = Color.Red;
                            btn[posx + 1, posy - 1].BackColor = Color.Red;
                            btn[posx + 2, posy - 1].BackColor = Color.Red;
                            btn[posx + 2, posy].BackColor = Color.Red;

                            wallLocations[posx, posy] = true;
                            wallLocations[posx, posy - 1] = true;
                            wallLocations[posx + 1, posy - 1] = true;
                            wallLocations[posx + 2, posy - 1] = true;
                            wallLocations[posx + 2, posy] = true;


                        }
                    }
                }
            }

            while (limitLineBLock < 30)
            {
                int posx = r.Next(1, 50);
                int posy = r.Next(1, 46);
                limitLineBLock++;
                for (int i = 0; i < btn.GetLength(0); i++)
                {
                    for (int j = 0; j < btn.GetLength(1); j++)
                    {
                        if (btn[posx - 1, posy].BackColor != Color.FromName("red") && btn[posx + 1, posy].BackColor != Color.FromName("red") && btn[posx, posy - 1].BackColor != Color.FromName("red") && btn[posx, posy + 1].BackColor != Color.FromName("red"))
                        {
                            btn[posx, posy].BackColor = Color.Red;
                            btn[posx, posy + 1].BackColor = Color.Red;
                            btn[posx, posy + 2].BackColor = Color.Red;
                            btn[posx, posy + 3].BackColor = Color.Red;

                            wallLocations[posx, posy] = true;
                            wallLocations[posx, posy + 1] = true;
                            wallLocations[posx, posy + 2] = true;
                            wallLocations[posx, posy + 3] = true;
                        }
                    }
                }
            }

        }


        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Left)
           // {
                
                //btn[29, 20].BackColor = Color.Black;
            //}

        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tempX, tempY;
            tempX = xpos;
            tempY = ypos;
            int[,] temp;
            if ((e.KeyChar == 'w')&& (wallLocations[tempX, tempY-1] != true))
            {
                btn[xpos, ypos].BackColor = Color.White;
                ypos--;
                btn[xpos, ypos].BackColor = Color.Black;
                newHuman.humanXLocation = xpos;
                newHuman.humanYLocation = ypos;
                
            }
            if ((e.KeyChar == 's')&& (wallLocations[tempX, tempY+1] != true))
            {
                btn[xpos, ypos].BackColor = Color.White;
                ypos++;
                btn[xpos, ypos].BackColor = Color.Black;
                newHuman.humanXLocation = xpos;
                newHuman.humanYLocation = ypos;
            }
            if ((e.KeyChar == 'd')&& (wallLocations[tempX+1, tempY] != true))
            {
                btn[xpos, ypos].BackColor = Color.White;
                xpos++;
                btn[xpos, ypos].BackColor = Color.Black;
                newHuman.humanXLocation = xpos;
                newHuman.humanYLocation = ypos;
            }
             if ((e.KeyChar == 'a')&& (wallLocations[tempX-1, tempY] != true))
            {
                btn[xpos, ypos].BackColor = Color.White;
                xpos--;
                btn[xpos, ypos].BackColor = Color.Black;
                newHuman.humanXLocation = xpos;
                newHuman.humanYLocation = ypos;
            }

            if(coinLocations[xpos,ypos] == true) // if a coin is collected 
            {
                btn[xpos, ypos].BackColor = Color.White;
                newPlayer.playerScore ++;
                label1.Text = "Items collected: " + newPlayer.playerScore;
                addCoins();
                zomNumber++;
                
                


            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i <= zomNumber; i++)
            {
                if (hoarde[i] != null)
                {
                    moveZombies(hoarde[i]);
                }
            }

        }
    }
}
