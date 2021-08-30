using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class ArmsHolder : _3D_Model
    {
        public float Rad = 150;
        public float RadSmall = 110;
        public float W = 80;
        public _3D_Point V0 = new _3D_Point(0, 0, 0);
        public _3D_Point Vx = new _3D_Point(1, 0, 0);
        public _3D_Point Vy = new _3D_Point(0, 1, 0);
        public _3D_Point Vz = new _3D_Point(0, 0, 1);

        public void Design(Color Color)
        {
            float xx, yy, ZZ = W;
            int i = 0;
            float inc = 5;
            int steps = (int)(360 / inc);
            int iStart;
            for (int k = 0; k < 4; k++)
            {
                iStart = i;
                for (float th = 0; th < 360; th += inc)
                {
                    xx = (float)(Math.Cos(th * Math.PI / 180) * Rad);
                    yy = (float)(Math.Sin(th * Math.PI / 180) * Rad);

                    L_3D_Pts.Add(new _3D_Point(xx + V0.X, yy + V0.Y, ZZ + V0.Z));

                    //if (i > 0)
                    if (th > 0)
                    {
                        AddEdge(i, i - 1, Color);
                    }

                    AddEdge(i, i + steps, Color);

                    if (k < 3)
                        AddEdge(i, i + 2 * steps, Color);
                    i++;
                }
                AddEdge(i - 1, iStart, Color);
                int j = 0;
                for (float th = 0; th < 360; th += inc)
                {
                    xx = (float)(Math.Cos(th * Math.PI / 180) * RadSmall);
                    yy = (float)(Math.Sin(th * Math.PI / 180) * RadSmall);

                    L_3D_Pts.Add(new _3D_Point(xx + V0.X, yy + V0.Y, ZZ + V0.Z));

                    if (j > 0)
                    {
                        AddEdge(i, i - 1, Color);
                    }
                    i++;
                    j++;
                }
                AddEdge(i - 1, i - j, Color);

                ZZ -= 20;
                if (k == 1)
                {
                    ZZ = -W + 20;
                    Rad = 100;
                    RadSmall = 60;
                }
            }




        }
    }
}
