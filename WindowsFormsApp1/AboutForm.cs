using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Get the Graphics for drawing
            Graphics g = e.Graphics;

            // Create Pen and Brush
            Pen pen = new Pen(Color.Black, 2);
            SolidBrush brush = new SolidBrush(Color.DarkBlue);

            Font font = new Font("Bold", 20, FontStyle.Bold);
            g.DrawString("Льоскін Іван Вадимович", font, brush, new PointF(130, 170));

            // Очищення ресурсів
            pen.Dispose();
            brush.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
