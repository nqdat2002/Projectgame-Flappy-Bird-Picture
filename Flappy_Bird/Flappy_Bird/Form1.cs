using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 9;
        int Score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            label1.Text = "Score : " + Score;
            if (pipeBottom.Left < -50)
            {
                pipeBottom.Left = 800;
                Score += 2;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 900;
                Score += 2;
            }

            if (FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds)
               || FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds)
               || FlappyBird.Bounds.IntersectsWith(ground.Bounds)
               )
            {
                Endgame();
            }

            if(Score > 20)
            {
                pipeSpeed += 5;
            }

            if (FlappyBird.Top < -25)
            {
                Endgame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void Endgame()
        {
            gameTime.Stop();
            label1.Text += " Game over !!!";
        }

    }
}
