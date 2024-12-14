using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class SquaresForm : Form
    {
        public SquaresForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(400, 400);
            this.Paint += new PaintEventHandler(this.OnPaint);
        }

        private const int SquareCount = 50;                     // number of nested squares
        private const float P = 0.08f;                          // k for the next square
        private float size = 200;                               // size of the first square
        private PointF topLeftCorner = new PointF(100, 100);    // start coordinales of the top left point


        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            // Start coordinates or the square's points
            PointF topLeft = topLeftCorner;
            PointF topRight = new PointF(topLeft.X + size, topLeft.Y);
            PointF bottomLeft = new PointF(topLeft.X, topLeft.Y + size);
            PointF bottomRight = new PointF(topLeft.X + size, topLeft.Y + size);

            for (int i = 0; i < SquareCount; i++)
            {
                // Draw the square with current values
                g.DrawPolygon(pen, new PointF[] { topLeft, topRight, bottomRight, bottomLeft });

                // Calculate new coordinates for nested square
                PointF newTopLeft = new PointF(
                    topLeft.X + (topRight.X - topLeft.X) * P,
                    topLeft.Y + (bottomLeft.Y - topLeft.Y) * P
                );
                PointF newTopRight = new PointF(
                    topRight.X - (topRight.X - topLeft.X) * P,
                    topRight.Y + (bottomRight.Y - topRight.Y) * P
                );
                PointF newBottomLeft = new PointF(
                    bottomLeft.X + (bottomRight.X - bottomLeft.X) * P,
                    bottomLeft.Y - (bottomLeft.Y - topLeft.Y) * P
                );
                PointF newBottomRight = new PointF(
                    bottomRight.X - (bottomRight.X - bottomLeft.X) * P,
                    bottomRight.Y - (bottomRight.Y - topRight.Y) * P
                );

                // update points for new square
                topLeft = newTopLeft;
                topRight = newTopRight;
                bottomLeft = newBottomLeft;
                bottomRight = newBottomRight;
            }

            pen.Dispose();
        }



        private void SquaresForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrianglesForm secondForm = new TrianglesForm();
            secondForm.Show();
        }
    }
}
