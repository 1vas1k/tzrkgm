using System;
using System.Drawing;
using SharpGL;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private float rquad = 0;
        private float speed = 2f;
        private float savedSpeed = 2f;
        private float xTranslation = 0;
        private float yTranslation = 0;
        private float zTranslation = -7f;
        private float xScale = 1;
        private float yScale = 1;
        private float zScale = 1;
        private Timer renderTimer;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;

            renderTimer = new Timer();
            renderTimer.Interval = 16;
            renderTimer.Tick += (s, e) => { openGLControl1_Load(null, null); };
            renderTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    speed -= 0.1f;
                    if (speed < 0f) speed = 0f;
                    break;
                case Keys.E:
                    speed += 0.1f;
                    break;
                case Keys.F:
                    if (speed > 0)
                    {
                        savedSpeed = speed;
                        speed = 0f;
                    }
                    else
                    {
                        speed = savedSpeed;
                    }
                    break;
                case Keys.W:
                    yTranslation += 0.5f;
                    break;
                case Keys.S:
                    yTranslation -= 0.5f;
                    break;
                case Keys.A:
                    xTranslation -= 0.5f;
                    break;
                case Keys.D:
                    xTranslation += 0.5f;
                    break;
                case Keys.Z:
                    zTranslation -= 0.5f;
                    break;
                case Keys.X:
                    zTranslation += 0.5f;
                    break;
                case Keys.C:
                    xScale += 0.1f;
                    yScale += 0.1f;
                    zScale += 0.1f;
                    break;
                case Keys.V:
                    if (xScale > 0.5f)
                    {
                        xScale -= 0.1f;
                        yScale -= 0.1f;
                        zScale -= 0.1f;
                        break;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void openGLControl1_Load(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gL = this.openGLControl1.OpenGL;

            gL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gL.LoadIdentity();

            gL.Translate(xTranslation, yTranslation, zTranslation);

            gL.Scale(xScale, yScale, zScale);

            gL.Rotate(rquad, 1.0f, -1.0f, 1.0f);

            gL.Begin(OpenGL.GL_QUADS);

            // front face of the cube
            gL.Color(1.0f, 0.0f, 0.0f);
            gL.Vertex(-1.0f, -1.0f, 1.0f);
            gL.Vertex(1.0f, -1.0f, 1.0f);
            gL.Vertex(1.0f, 1.0f, 1.0f);
            gL.Vertex(-1.0f, 1.0f, 1.0f);

            // back face of the cube
            gL.Color(1.0f, 1.0f, 0.0f);
            gL.Vertex(-1.0f, -1.0f, -1.0f);
            gL.Vertex(-1.0f, 1.0f, -1.0f);
            gL.Vertex(1.0f, 1.0f, -1.0f);
            gL.Vertex(1.0f, -1.0f, -1.0f);

            // left face of the cube
            gL.Color(1.0f, 1.0f, 1.0f);
            gL.Vertex(-1.0f, -1.0f, -1.0f);
            gL.Vertex(-1.0f, -1.0f, 1.0f);
            gL.Vertex(-1.0f, 1.0f, 1.0f);
            gL.Vertex(-1.0f, 1.0f, -1.0f);

            //  right face of the cube
            gL.Color(0.0f, 1.0f, 1.0f);
            gL.Vertex(1.0f, -1.0f, -1.0f);
            gL.Vertex(1.0f, -1.0f, 1.0f);
            gL.Vertex(1.0f, 1.0f, 1.0f);
            gL.Vertex(1.0f, 1.0f, -1.0f);

            // top face of the cube
            gL.Color(0.0f, 0.0f, 1.0f);
            gL.Vertex(-1.0f, 1.0f, -1.0f);
            gL.Vertex(-1.0f, 1.0f, 1.0f);
            gL.Vertex(1.0f, 1.0f, 1.0f);
            gL.Vertex(1.0f, 1.0f, -1.0f);

            // bottom face of the cube
            gL.Color(0.0f, 1.0f, 0.0f);
            gL.Vertex(-1.0f, -1.0f, -1.0f);
            gL.Vertex(1.0f, -1.0f, -1.0f);
            gL.Vertex(1.0f, -1.0f, 1.0f);
            gL.Vertex(-1.0f, -1.0f, 1.0f);

            gL.End();
            gL.Flush();

            rquad += speed;
            DrawText($"Rotation Angle: {speed:F2} \nCube coordinates: {xTranslation:F2} {yTranslation:F2} {zTranslation:F2}");
        }

        private void DrawText(string text)
        {
            using (Graphics g = openGLControl1.CreateGraphics())
            {
                Font font = new Font("Arial", 12);
                Brush brush = Brushes.White;
                g.DrawString(text, font, brush, new PointF(10, 10));
            }
        }
    }
}
