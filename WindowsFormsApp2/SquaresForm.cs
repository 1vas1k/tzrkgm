using System;
using System.Drawing;
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

                // update points for new square
                topLeft = GetPointOnEdge(topLeft, topRight, P);
                topRight = GetPointOnEdge(topRight, bottomRight, P);
                bottomRight = GetPointOnEdge(bottomRight, bottomLeft, P);
                bottomLeft = GetPointOnEdge(bottomLeft, topLeft, P);
            }

            pen.Dispose();
        }

        // calculate new points at square sides
        private PointF GetPointOnEdge(PointF p1, PointF p2, float ratio)
        {
            return new PointF(
                p1.X + (p2.X - p1.X) * ratio,
                p1.Y + (p2.Y - p1.Y) * ratio
            );
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
