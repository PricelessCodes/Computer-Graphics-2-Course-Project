using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Plat : _3D_Model
    {
        public float Rad = 100, SmallRad = 80;
        public _3D_Point V0 = new _3D_Point(0, 0, 0);
        public _3D_Point Vy = new _3D_Point(0, 1, 0);

        public void Design(Color Color)
        {
            float inc = 5;
            int i = 0;
            for (float th = 180; th <= 360; th += inc)
            {
                float xx = (float)(Rad * Math.Cos(th * Math.PI / 180));
                float yy = (float)(Rad * Math.Sin(th * Math.PI / 180));
                int j = 0;
                for (float th2 = 0; th2 <= 360; th2 += inc)
                {
                    float x2 = (float)(xx * Math.Cos(th2 * Math.PI / 180));
                    float z2 = (float)(xx * Math.Sin(th2 * Math.PI / 180));

                    AddPoint(new _3D_Point(x2, yy, z2));

                    if (i > 0 && j > 0)
                    {
                        AddEdge(i, i - 1, Color);
                    }
                    i++;
                    j++;
                }
            }
        }
    }
}
