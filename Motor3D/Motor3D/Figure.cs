using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor3D
{
    public class Figure
    {
        public List<Vertex> Points;
        public Vertex Centroid, Last;

        public Figure()
        {
            Points = new List<Vertex>();
        }

        public void Add(Vertex point)
        {
            Centroid = new Vertex();
            Points.Add(point);

            for (int p = 0; p < Points.Count; p++)
            {
                Centroid.X += Points[p].X;
                Centroid.Y += Points[p].Y;
                Centroid.Z += Points[p].Z;
            }
            Last = point;

            Centroid.X /= Points.Count;
            Centroid.Y /= Points.Count;
            Centroid.Z /= Points.Count;
        }

        public void Scale(float value)
        {
            
        }

        public void TranslatePoints(Vertex a)
        {
            
        }

        public void TranslateToOrigin()
        {
            
        }

        public Figure RotateX(float angle)
        {
            Util.Angle = angle;
            Figure figure = new Figure();
            foreach (Vertex v in Points)
            {
                float[,] nv = new float[3, 1];
                float[,] ver = new float[3, 1]
                {
                {v.X},
                {v.Y},
                {v.Z},
                 };
                for (int i = 0; i < 3; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        sum += Util.RotX[i, j] * ver[j, 0];
                    }
                    nv[i, 0] = sum;
                }
                figure.Add(new Vertex(nv[0, 0], nv[1, 0], nv[2, 0]));
            }
            return figure;

        }

        public Figure RotateY(float angle)
        {
            Util.Angle = angle;
            Figure figure = new Figure();
            foreach (Vertex v in Points)
            {
                float[,] nv = new float[3, 1];
                float[,] ver = new float[3, 1]
                {
                {v.X},
                {v.Y},
                {v.Z},
                 };
                for (int i = 0; i < 3; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        sum += Util.RotY[i, j] * ver[j, 0];
                    }
                    nv[i, 0] = sum;
                }
                figure.Add(new Vertex(nv[0, 0], nv[1, 0], nv[2, 0]));
            }
            return figure;
        }

        public Figure RotateZ(float angle)
        {
            Util.Angle = angle;
            Figure figure= new Figure();
            foreach (Vertex v in Points)
            {
                float[,] nv = new float[3, 1];
                float[,] ver = new float[3, 1]
                {
                {v.X},
                {v.Y},
                {v.Z},
                 };
                for (int i = 0; i < 3; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        sum += Util.RotZ[i, j] * ver[j, 0];
                    }
                    nv[i, 0] = sum;
                }
                figure.Add(new Vertex(nv[0, 0], nv[1, 0], nv[2, 0]));
            }
            return figure;
        }

        public void UpdateAttributes()
        {
            Centroid = new Vertex();

            for (int p = 0; p < Points.Count; p++)
            {
                Centroid.X += Points[p].X;
                Centroid.Y += Points[p].Y;
                Centroid.Z += Points[p].Z;
            }
            Last = Points[Points.Count - 1];

            Centroid.X /= Points.Count;
            Centroid.Y /= Points.Count;
            Centroid.Z /= Points.Count;
        }

    }
}
