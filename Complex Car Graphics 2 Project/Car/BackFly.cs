using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class BackFly : _3D_Model
    {
        public float Rad = 200;

        public void Design(Color Color)
        {
            float inc = 20;
            int i = 0;
            
            for (float th = 0; th <= 100; th += inc/4)
            {
                float zz = (float)(Rad * Math.Cos(th * Math.PI / 180));
                float yy = (float)(Rad * Math.Sin(th * Math.PI / 180));
                int j = 0;
                for (float th2 = 0; th2 <= 360; th2 += inc)
                {
                    float z2 = (float)(yy * Math.Cos(th2 * Math.PI / 180));
                    float y2 = (float)(yy * Math.Sin(th2 * Math.PI / 180));

                    AddPoint(new _3D_Point(zz, y2, z2));

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
