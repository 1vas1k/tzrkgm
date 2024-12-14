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
    public partial class TrianglesForm : Form
    {
        public TrianglesForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(600, 600);
            this.Paint += new PaintEventHandler(this.OnPaint);
        }

        private const int Depth = 5;    // depth of recursion
        private const float P = 0.5f;   // k of shift (1/2 for Sierpinski triangle)

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // original triangle with three points
            PointF p1 = new PointF(300, 50);  // top point
            PointF p2 = new PointF(50, 500);  // bottom left point
            PointF p3 = new PointF(550, 500); // bottom right point

            // draw the Sierpinski triangle
            DrawSierpinski(g, p1, p2, p3, Depth);
        }

        // recursive function for drawing the Sierpinski triangle
        private void DrawSierpinski(Graphics g, PointF p1, PointF p2, PointF p3, int depth)
        {
            // if we have reached the recursion depth, we draw a triangle
            if (depth == 0)
            {
                DrawTriangle(g, p1, p2, p3);
            }
            else
            {
                // calculate the midpoints of each side of the triangle
                PointF mid1 = new PointF((p1.X + p2.X) * P, (p1.Y + p2.Y) * P);
                PointF mid2 = new PointF((p2.X + p3.X) * P, (p2.Y + p3.Y) * P);
                PointF mid3 = new PointF((p3.X + p1.X) * P, (p3.Y + p1.Y) * P);

                // recursively draw three smaller triangles
                DrawSierpinski(g, p1, mid1, mid3, depth - 1);
                DrawSierpinski(g, mid1, p2, mid2, depth - 1);
                DrawSierpinski(g, mid3, mid2, p3, depth - 1);
            }
        }

        // function to draw a triangle by three vertices
        private void DrawTriangle(Graphics g, PointF p1, PointF p2, PointF p3)
        {
            g.DrawPolygon(Pens.Black, new PointF[] { p1, p2, p3 });
        }


        private void TrianglesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
