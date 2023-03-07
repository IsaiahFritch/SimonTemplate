using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //Variables
        int guessNumber = 0;
        int waitTime = 50; //250

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //Clear pattern and run ComputerTurn
            Form1.pattern.Clear();
            guessNumber = 0;
            Refresh();
            Thread.Sleep(waitTime);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //Add next number to the pattern
            Random rand = new Random();
            Form1.pattern.Add(rand.Next(1,5));

            //Show generated pattern
            for (int i = 0; i < Form1.pattern.Count(); i++)
            {
                switch (Form1.pattern[i])
                {
                    case 1: 
                        greenButton.BackColor = Color.LimeGreen;
                        Refresh();
                        Thread.Sleep(waitTime);
                        greenButton.BackColor = Color.ForestGreen;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;
                    case 2:
                        redButton.BackColor = Color.Pink;
                        Refresh();
                        Thread.Sleep(waitTime);
                        redButton.BackColor = Color.DarkRed;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;
                    case 3:
                        yellowButton.BackColor = Color.Yellow;
                        Refresh();
                        Thread.Sleep(waitTime);
                        yellowButton.BackColor = Color.Goldenrod;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;
                    case 4:
                        blueButton.BackColor = Color.LightBlue;
                        Refresh();
                        Thread.Sleep(waitTime);
                        blueButton.BackColor = Color.DarkBlue;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;
                }
            }
        }

        //Button Clicks
        private void greenButton_Click(object sender, EventArgs e)
        {
            ButtonClick(1);
        }
        private void redButton_Click(object sender, EventArgs e)
        {
            ButtonClick(2);
        }
        private void yellowButton_Click(object sender, EventArgs e)
        {
            ButtonClick(3);
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            ButtonClick(4);
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //Launch GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());
        }
        public void ButtonClick(int colour)
        {
            guessNumber++;
            if (colour == Form1.pattern[guessNumber - 1])   
            {
                // TODO play sound
                switch (colour)
                {
                    case 1:
                        greenButton.BackColor = Color.LimeGreen;
                        Refresh();
                        Thread.Sleep(waitTime);
                        greenButton.BackColor = Color.ForestGreen;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;

                    case 2:
                        redButton.BackColor = Color.Pink;
                        Refresh();
                        Thread.Sleep(waitTime);
                        redButton.BackColor = Color.DarkRed;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;

                    case 3:
                        yellowButton.BackColor = Color.Yellow;
                        Refresh();
                        Thread.Sleep(waitTime);
                        yellowButton.BackColor = Color.Goldenrod;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;

                    case 4:
                        blueButton.BackColor = Color.LightBlue;
                        Refresh();
                        Thread.Sleep(waitTime);
                        blueButton.BackColor = Color.DarkBlue;
                        Refresh();
                        Thread.Sleep(waitTime);
                        break;
                }
            }
            else if (colour != Form1.pattern[guessNumber - 1])
            {
                GameOver();
            }
            if (guessNumber == Form1.pattern.Count())
            {
                guessNumber = 0;
                ComputerTurn();
            }
        }
    }
}
