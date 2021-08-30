using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Cylinder : _3D_Model
    {
        public int Rad;
        public int Height;
        public _3D_Point V0 = new _3D_Point(0, 0, 0);
        public _3D_Point Vx = new _3D_Point(1, 0, 0);
        public _3D_Point Vy = new _3D_Point(0, 1, 0);
        public _3D_Point Vz = new _3D_Point(0, 0, 1);

        public void Design(Color Color)
        {
            int i = 0;
            int N = 20;
            int Step = (int)(360 / N);
            int iStart;
            int NCircles = 10;
            float xx, yy = Height / 2, zz;
            for (int k = 0; k < NCircles; k++)
            {
                iStart = i;
                for (float th = 0; th < 360; th += Step)
                {
                    xx = (float)(Math.Cos(th * Math.PI / 180) * Rad);
                    zz = (float)(Math.Sin(th * Math.PI / 180) * Rad);

                    L_3D_Pts.Add(new _3D_Point(xx, yy, zz));

                    if (th > 0)
                        AddEdge(i, i - 1, Color);

                    if (k < NCircles - 1)
                        AddEdge(i, i + N, Color);

                    i++;
                }
                AddEdge(i - 1, iStart, Color);

                yy -= Height / NCircles;
            }
        }
    }
}
