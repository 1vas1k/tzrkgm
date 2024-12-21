using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SnowFlakeForm : Form
    {
        public SnowFlakeForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(700, 700);
            this.Paint += new PaintEventHandler(this.OnPaint);

        }

        private int Depth = 4; // depth of recursion
        private const float P = 1 / 3f; // k for determination of intermediate points on the side of the triangle



        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // base triangle which have equal sides length
            PointF p1 = new PointF(300, 50);   // top point
            PointF p2 = new PointF(50, 500);   // bottom left point
            PointF p3 = new PointF(550, 500);  // bottom right point

            // draw Koch's snowflake
            DrawKochSnowflake(g, p1, p2, Depth);
            DrawKochSnowflake(g, p2, p3, Depth);
            DrawKochSnowflake(g, p3, p1, Depth);
        }


        // function for drawing Loch's snowflake at one side
        private void DrawKochSnowflake(Graphics g, PointF p1, PointF p2, int depth)
        {
            if (depth == 0)
            {
                g.DrawLine(Pens.Black, p1, p2);
            }
            else
            {
                // calculate three intermadiate points
                PointF a = new PointF(p1.X + (p2.X - p1.X) * P, p1.Y + (p2.Y - p1.Y) * P);
                PointF b = new PointF(p1.X + (p2.X - p1.X) * 2 * P, p1.Y + (p2.Y - p1.Y) * 2 * P);

                // calculate coordinates of new triangle
                float angle = (float)(Math.PI / 3); // 60 degrees
                PointF c = new PointF(
                    (float)(a.X + (b.X - a.X) * Math.Cos(angle) - (b.Y - a.Y) * Math.Sin(angle)),
                    (float)(a.Y + (b.X - a.X) * Math.Sin(angle) + (b.Y - a.Y) * Math.Cos(angle))
                );

                // recursively draw a Koch's snowflake for each part
                DrawKochSnowflake(g, p1, a, depth - 1);
                DrawKochSnowflake(g, a, c, depth - 1);
                DrawKochSnowflake(g, c, b, depth - 1);
                DrawKochSnowflake(g, b, p2, depth - 1);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int newDepth) && newDepth >= 0)
            {
                Depth = newDepth; // update the depth
                this.Invalidate(); // render form
            }
        }
    }
}
