using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_5
{
    public partial class Form1 : Form
    {
        Game game;
        int tickCount;

        public Form1()
        {
            InitializeComponent();
            game = new Game(progressBar1);
            timer1.Enabled = false;
            timer_sec.Enabled = false;
            tickCount = 0;
            label_gameover.Visible = false;
            label_press.Visible = true;
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (game.isGameActive)
                game.DrawObjects(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.isGameActive)
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
                    game.player.Move(e);
            if (e.KeyCode == Keys.Space)
            {
                if (!game.isGameActive)
                {
                    game.isGameActive = true;
                    label_press.Visible = false;
                    label_gameover.Visible = false;
                    game.Init();
                    timer_sec.Enabled = true;
                    timer1.Enabled = true;
                }
                else
                {
                    game.player.Shoot(game.ammos);
                }
                
            }
            pictureBox1.Invalidate();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (game.isGameActive)
            {
                tickCount++;
                if (tickCount > 15)
                    tickCount = 0;

                game.GameControl();

                if (tickCount == 15)
                    game.Pursuit();
            }
            pictureBox1.Invalidate();

            if (game.isOver())
            {
                game.isGameActive = false;
                label_gameover.Visible = true;
                label_press.Visible = true;
                timer1.Enabled = false;
                timer_sec.Enabled = false;
            }
        }

        private void timer_sec_Tick(object sender, EventArgs e)
        {
            if (game.isGameActive)
                game.UpdateCooldowns();
        }
    }
}
