using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor3D
{
    public partial class Form1 : Form
    {
        Bitmap canva;
        Graphics g;
        PictureBox pictureBox;
        int w = 800, h = 800, d = 2;
        Figure cube, rcube;
        int a =0;
        Boolean ex = true, ye = true, ze = true , pr = true;

        private void button4_Click(object sender, EventArgs e)
        {
            ze = !ze;
            if (ze)
            {
                button4.Text = "STOP Z";
            } else button4.Text = "RUN Z";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ye = !ye;
            if (ye)
            {
                button3.Text = "STOP Y";
            }
            else button3.Text = "RUN Y";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ex = !ex;
            if (ex)
            {
                button2.Text = "STOP X";
            }
            else button2.Text = "RUN X";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pr = !pr;
            if (pr)
            {
                button1.Text = "ORTOGONAL";
            }
            else button1.Text = "PERSPECTIVE";
        }

        public Form1()
        {
            InitializeComponent();
            canva = new Bitmap(w, h);
            g = Graphics.FromImage(canva);
            Projection op = new Projection(w, h);  
            pictureBox = new PictureBox {
                Image = canva,
                Size= new Size(w,h),
                Location = new Point(0,0),
                BackColor = Color.Gray
            };
            DrawAxis();
            cube = new Figure();
            cube.Add(new Vertex(-1, -1, 1));
            cube.Add(new Vertex(1, -1, 1));
            cube.Add(new Vertex(1,1, 1));
            cube.Add(new Vertex(-1,1, 1));
            cube.Add(new Vertex(-1, -1, -1));
            cube.Add(new Vertex(1, -1, -1));
            cube.Add(new Vertex(1, 1, -1));
            cube.Add(new Vertex(-1, 1, -1));
            this.Controls.Add(pictureBox);
        }
        public void DrawAxis()
        {
            Point wi = new Point(w / 2, h - h);
            Point wf = new Point(w / 2, h);
            Point hi = new Point(w - w, h / 2);
            Point hf = new Point(w, h / 2);
            g.DrawLine(Pens.Yellow, wi, wf);
            g.DrawLine(Pens.Yellow, hi, hf);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            if (a == 360) a = 0;
            label1.Text = "Angle :::" + a.ToString();
            if (ex) rcube = cube.RotateX(a);
            if (ye)
            {
                if (ex) rcube = rcube.RotateY(a);
                else rcube = cube.RotateY(a);
            }
            if (ze)
            {
                if (ex && ye) rcube = rcube.RotateZ(a);
                else
                {
                    if (ye) rcube = rcube.RotateZ(a);
                    else rcube = cube.RotateZ(a);
                }
            }
            g.Clear(Color.Gray);
            DrawAxis();
            if (pr)
            {
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionP(rcube.Points[0], 100), Projection.ProjectionP(rcube.Points[1], 100));
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionP(rcube.Points[1], 100), Projection.ProjectionP(rcube.Points[2], 100));
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionP(rcube.Points[2], 100), Projection.ProjectionP(rcube.Points[3], 100));
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionP(rcube.Points[3], 100), Projection.ProjectionP(rcube.Points[0], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionP(rcube.Points[4], 100), Projection.ProjectionP(rcube.Points[5], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionP(rcube.Points[5], 100), Projection.ProjectionP(rcube.Points[6], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionP(rcube.Points[6], 100), Projection.ProjectionP(rcube.Points[7], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionP(rcube.Points[7], 100), Projection.ProjectionP(rcube.Points[4], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionP(rcube.Points[0], 100), Projection.ProjectionP(rcube.Points[4], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionP(rcube.Points[1], 100), Projection.ProjectionP(rcube.Points[5], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionP(rcube.Points[2], 100), Projection.ProjectionP(rcube.Points[6], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionP(rcube.Points[3], 100), Projection.ProjectionP(rcube.Points[7], 100));
            } else
            {
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionO(rcube.Points[0], 100), Projection.ProjectionO(rcube.Points[1], 100));
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionO(rcube.Points[1], 100), Projection.ProjectionO(rcube.Points[2], 100));
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionO(rcube.Points[2], 100), Projection.ProjectionO(rcube.Points[3], 100));
                g.DrawLine(Pens.Aquamarine, Projection.ProjectionO(rcube.Points[3], 100), Projection.ProjectionO(rcube.Points[0], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionO(rcube.Points[4], 100), Projection.ProjectionO(rcube.Points[5], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionO(rcube.Points[5], 100), Projection.ProjectionO(rcube.Points[6], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionO(rcube.Points[6], 100), Projection.ProjectionO(rcube.Points[7], 100));
                g.DrawLine(Pens.Violet, Projection.ProjectionO(rcube.Points[7], 100), Projection.ProjectionO(rcube.Points[4], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionO(rcube.Points[0], 100), Projection.ProjectionO(rcube.Points[4], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionO(rcube.Points[1], 100), Projection.ProjectionO(rcube.Points[5], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionO(rcube.Points[2], 100), Projection.ProjectionO(rcube.Points[6], 100));
                g.DrawLine(Pens.Orange, Projection.ProjectionO(rcube.Points[3], 100), Projection.ProjectionO(rcube.Points[7], 100));
            }
            pictureBox.Refresh();
        }


    }
}
