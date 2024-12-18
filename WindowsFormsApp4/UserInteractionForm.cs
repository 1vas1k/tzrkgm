using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp4
{
    public partial class UserInteractionForm : Form
    {
        public UserInteractionForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(800, 600);

            // create obstacle
            obstacle1 = new Panel
            {
                BackColor = Color.Red,
                Size = new Size(70, 70),
                Location = new Point(300, 150)
            };
            // add obstacle on the form
            this.Controls.Add(obstacle1);
            initialImagePosition = new Point(100, 100);

        }

        private Panel obstacle1;
        private Point initialImagePosition;
        Timer moveTimer = new Timer();
        int xSpeed = 20;
        int ySpeed = 20;

        // move PictureBox on press the button
        private void moveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X >= ClientSize.Width - pictureBox1.Width || pictureBox1.Location.X <= 0)
            {
                xSpeed = -xSpeed;
            }
            if (pictureBox1.Location.Y >= ClientSize.Height - pictureBox1.Height || pictureBox1.Location.Y <= 50)
            {
                ySpeed = -ySpeed;
            }



            pictureBox1.Location = new Point(pictureBox1.Location.X + xSpeed, pictureBox1.Location.Y + ySpeed);
        }

        // set PictureBox on start position
        private void resetButton_Click(object sender, EventArgs e)
        {
            moveTimer.Stop();
            pictureBox1.Location = initialImagePosition;
            xSpeed = Math.Abs(xSpeed);
            ySpeed = Math.Abs(ySpeed);
        }


        // start infinity move of PictureBox with x and y speed
        private void InfMoveButton_Click(object sender, EventArgs e)
        {
            moveTimer.Tick += (s, eventArgs) =>
            {

                if (IsColliding(pictureBox1, obstacle1))
                {
                    if (pictureBox1.Location.X < obstacle1.Location.X)
                    {
                        xSpeed = -Math.Abs(xSpeed);  // change vector of movement if met right side of obstacle
                    }
                    else
                    {
                        xSpeed = Math.Abs(xSpeed);   // change vector of movement if met left side of obstacle
                    }

                    if (pictureBox1.Location.Y < obstacle1.Location.Y)
                    {
                        ySpeed = -Math.Abs(ySpeed);  // change vector of movement if met top side of obstacle
                    }
                    else
                    {
                        ySpeed = Math.Abs(ySpeed);   // change vector of movement if met bottom side of obstacle
                    }
                }

                // change vector of movement if met one of the sides
                if (pictureBox1.Location.X >= ClientSize.Width - pictureBox1.Width || pictureBox1.Location.X <= 0)
                {
                    xSpeed = -xSpeed;
                }
                if (pictureBox1.Location.Y >= ClientSize.Height - pictureBox1.Height || pictureBox1.Location.Y <= 50)
                {
                    ySpeed = -ySpeed;
                }

                // update position
                pictureBox1.Location = new Point(pictureBox1.Location.X + xSpeed, pictureBox1.Location.Y + ySpeed);
            };
            moveTimer.Start();
        }

        // method that check the colliding with obstacle
        private bool IsColliding(Control pictureBox, Panel obstacle)
        {
            Rectangle pictureBoxRect = pictureBox.Bounds;
            Rectangle obstacleRect = obstacle.Bounds;

            return pictureBoxRect.IntersectsWith(obstacleRect);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
                private void Form1_Load(object sender, EventArgs e)
        {

        }

        // open second form
        private void openButton_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            secondForm.Show();
        }
    }
}
