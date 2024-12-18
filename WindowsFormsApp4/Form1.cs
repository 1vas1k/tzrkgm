using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            // setup current active PictureBox as pictureBox1 by default
            activePictureBox = pictureBox1;

            pictureBox1.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(PictureBox_MouseUp);

            pictureBox2.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox2.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox2.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
        }

        private PictureBox activePictureBox; // current PictureBox
        private bool isDragging = false; // flag for dragging
        private Point mouseOffset; // cursor shift related of PictureBox

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                activePictureBox = activePictureBox == pictureBox1 ? pictureBox2 : pictureBox1;
            }
            int moveDistance = 10; // distance for moving the PictureBox

            // change coordinates of pictureBox1 depending of pressed button
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
            Invalidate(); // render
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // set active PictureBox
            activePictureBox = sender as PictureBox;

            if (activePictureBox != null && e.Button == MouseButtons.Left)
            {
                // run the procces of drugging
                isDragging = true;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
