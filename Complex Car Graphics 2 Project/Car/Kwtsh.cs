using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Kwtsh : _3D_Model
    {
        public float Rad = 150;
        public float RadSmall = 100;
        public _3D_Point V0 = new _3D_Point(0, 0, 0);
        public _3D_Point Vz = new _3D_Point(0, 0, 1);

        public void Design()
        {
            float xx, yy, ZZ = 200 ;
            int i=0;
            float inc = 20;
            int steps = (int)(360 / inc);
            int iStart;
            for (int k = 0; k < 4; k++)
            {
                iStart = i;
                for (float th = 0; th < 360; th += inc)
                {
                    xx = (float)(Math.Cos(th * Math.PI / 180) * Rad);
                    yy = (float)(Math.Sin(th * Math.PI / 180) * Rad);

                    L_3D_Pts.Add(new _3D_Point(xx, yy, ZZ));

                    //if (i > 0)
                    if (th >0)
                    {
                        AddEdge(i, i - 1, Color.Black);
                    }

                    AddEdge(i, i + steps, Color.Black);

                    if ( k < 3 && k != 1)
                        AddEdge(i, i + 2 * steps, Color.Black);
                    i++;
                }
                AddEdge(i - 1, iStart, Color.Black);
                int j = 0;
                for (float th = 0; th < 360; th += inc)
                {
                    xx = (float)(Math.Cos(th * Math.PI / 180) * RadSmall);
                    yy = (float)(Math.Sin(th * Math.PI / 180) * RadSmall);

                    L_3D_Pts.Add(new _3D_Point(xx, yy, ZZ));

                    if (j > 0)
                    {
                        AddEdge(i, i - 1, Color.Black);
                    }
                    if (k == 1)
                    {
                        AddEdge(i, i + 2 * steps, Color.Black);
                    }
                    i++;
                    j++;
                }
                AddEdge(i - 1, i - j, Color.Black);

                ZZ -= 100;
            }
            



        }
    }
}
