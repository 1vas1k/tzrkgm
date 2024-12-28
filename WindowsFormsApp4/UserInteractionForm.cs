using System;
using System.Drawing;
using System.Windows.Forms;

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
                Size = new Size(100, 100),
                Location = new Point(300, 180)
            };
            // add obstacle on the form
            this.Controls.Add(obstacle1);
            initialImagePosition = new Point(10, 10);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            activePictureBox = pictureBox1;
            // subscribe on events
            pictureBox1.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(PictureBox_MouseUp);

            pictureBox2.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox2.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox2.MouseUp += new MouseEventHandler(PictureBox_MouseUp);

        }

        private Panel obstacle1;
        private Point initialImagePosition;
        Timer moveTimer = new Timer();
        int xSpeed = 20;
        int ySpeed = 20;
        private PictureBox activePictureBox; // current PictureBox
        private bool isDragging = false; // flag for dragging
        private bool isMooving = true; // flag for infinity move
        private Point mouseOffset; // cursor shift related of PictureBox

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (activePictureBox.Location.Y > 20)
                {
                    activePictureBox.Location = new Point(activePictureBox.Location.X, activePictureBox.Location.Y - 20);
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (activePictureBox.Bottom < ClientSize.Height - 20)
                {
                    activePictureBox.Location = new Point(activePictureBox.Location.X, activePictureBox.Location.Y + 20);
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (activePictureBox.Left > 20)
                {
                    activePictureBox.Location = new Point(activePictureBox.Location.X - 20, activePictureBox.Location.Y);
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (activePictureBox.Right < ClientSize.Width - 20)
                {
                    activePictureBox.Location = new Point(activePictureBox.Location.X + 20, activePictureBox.Location.Y);
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                activePictureBox = activePictureBox == pictureBox1 ? pictureBox2 : pictureBox1;
            }
            else if (e.KeyCode == Keys.R) {
                moveTimer.Stop();
                activePictureBox.Location = initialImagePosition;
                xSpeed = Math.Abs(xSpeed);
                ySpeed = Math.Abs(ySpeed);
            }
            else if (e.KeyCode == Keys.Space)
            {
                Console.WriteLine(isMooving);
                if (isMooving)
                {
                    moveTimer.Stop();
                    isMooving = false;
                }
                else
                {
                    moveTimer.Start();
                    isMooving = true;
                }
            }
            Invalidate(); // render
        }

        private bool IsColliding(Control pictureBox, Panel obstacle)
        {
            Rectangle pictureBoxRect = pictureBox.Bounds;
            Rectangle obstacleRect = obstacle.Bounds;

            return pictureBoxRect.IntersectsWith(obstacleRect);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // set active PictureBox
            activePictureBox = sender as PictureBox;

            if (activePictureBox != null && e.Button == MouseButtons.Left)
            {
                // run the procces of drugging
                isDragging = true;
                isMooving = false;
                moveTimer.Stop();

                // calculste cursor shift related to PictureBox
                mouseOffset = new Point(e.X, e.Y);
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && activePictureBox != null)
            {
                // calculate new position of PictureBox
                Point newLocation = activePictureBox.Location;
                newLocation.X += e.X - mouseOffset.X;
                newLocation.Y += e.Y - mouseOffset.Y;
                activePictureBox.Location = newLocation;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // end dragging
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
            
        private void Infinity_Moove(object sender)
        {
            isMooving = true;
            moveTimer.Tick += (s, eventArgs) =>
            {

                if (IsColliding(activePictureBox, obstacle1))
                {
                    if (activePictureBox.Location.X < obstacle1.Location.X)
                    {
                        xSpeed = -Math.Abs(xSpeed);  // change vector of movement if met right side of obstacle
                    }
                    else
                    {
                        xSpeed = Math.Abs(xSpeed);   // change vector of movement if met left side of obstacle
                    }

                    if (activePictureBox.Location.Y < obstacle1.Location.Y)
                    {
                        ySpeed = -Math.Abs(ySpeed);  // change vector of movement if met top side of obstacle
                    }
                    else
                    {
                        ySpeed = Math.Abs(ySpeed);   // change vector of movement if met bottom side of obstacle
                    }
                }

                // change vector of movement if met one of the sides
                if (activePictureBox.Location.X >= ClientSize.Width - activePictureBox.Width || activePictureBox.Location.X <= 0)
                {
                    xSpeed = -xSpeed;
                }
                if (activePictureBox.Location.Y >= ClientSize.Height - activePictureBox.Height || activePictureBox.Location.Y <= 0)
                {
                    ySpeed = -ySpeed;
                }

                // update position
                activePictureBox.Location = new Point(activePictureBox.Location.X + xSpeed, activePictureBox.Location.Y + ySpeed);
            };
            moveTimer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Infinity_Moove(sender);
        }
    }
}
