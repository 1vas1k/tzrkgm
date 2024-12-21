using System;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Size = new Size(600, 400);
            this.Paint += new PaintEventHandler(AboutForm_Paint);
        }

        private void AboutForm_Paint(object sender, PaintEventArgs e)
        {
            // Get the Graphics, Pen and Brush
            Graphics myGraphics = e.Graphics;
            Pen myPen = new Pen(Color.Black, 2);
            Brush brushBg = new SolidBrush(Color.Pink);
            Brush brushLetters = new SolidBrush(Color.Black);

            myGraphics.FillRectangle(brushBg, new Rectangle(100, 140, 400, 80));

            //ЛЬОСКІН Л
            myGraphics.DrawLine(myPen, 110, 200, 120, 150);
            myGraphics.DrawLine(myPen, 120, 150, 130, 200);
            //ЛЬОСКІН Ь
            myGraphics.DrawLine(myPen, 160, 150, 160, 200);
            Rectangle rectangle = new Rectangle(160, 175, 20, 20);
            myGraphics.DrawEllipse(myPen, rectangle);
            //ЛЬОСКІН О
            myGraphics.FillEllipse(brushLetters, new Rectangle(210, 150, 40, 50));
            //ЛЬОСКІН С
            myGraphics.DrawBezier(myPen, new Point(300, 150), new Point(260, 165), new Point(260, 185), new Point(300, 200));
            //ЛЬОСКІН К
            myGraphics.DrawLine(myPen, 330, 200, 330, 150);
            myGraphics.DrawBezier(myPen, new Point(360, 150), new Point(320, 175), new Point(320, 175), new Point(360, 200));
            //ЛЬОСКІН І
            myGraphics.DrawLine(myPen, 400, 200, 400, 170);
            myGraphics.FillEllipse(brushLetters, new Rectangle(392, 150, 15, 15));
            //ЛЬОСКІН Н
            myGraphics.DrawLine(myPen, 430, 200, 430, 150);
            myGraphics.DrawLine(myPen, 430, 175, 460, 175);
            myGraphics.DrawLine(myPen, 460, 200, 460, 150);

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
