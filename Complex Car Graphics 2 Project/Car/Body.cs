using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Body : _3D_Model
    {
        public _3D_Point V1 = new _3D_Point(0, 0, 0);
        public _3D_Point Vx = new _3D_Point(1, 0, 0);
        public _3D_Point Vz = new _3D_Point(0, 0, 1);

        public void Design(Color Color)
        {
            float[] vert = 
                            { 
                                -500  ,  -200 ,  300, //0
                                 300  ,  -200 ,  300, //1
                                 300  ,  -200 , -300, //2
                                -500  ,  -200 , -300, //3

                                -500  ,  200 ,  300, //4
                                 500  ,  200 ,  300, //5
                                 500  ,  200 , -300, //6
                                -500  ,  200 , -300, //7

                                 500  ,  -100 ,  300, //8
                                 500  ,  -100 , -300, //9

                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                pnn = new _3D_Point(vert[j], vert[j + 1], vert[j + 2]);
                j += 3;
                AddPoint(pnn);
            }


            int[] Edges = {
                              0,1 ,
                              1,2 ,
                              2,3 ,
                              3,0 , 

                              4,5,
                              5,6,
                              6,7,
                              7,4,

                              0,4,
                              8,5,
                              9,6,
                              3,7,

                              1,8,
                              8,9,
                              9,2,
                          };
            j = 0;
            for (int i = 0; i < 15; i++)
            {
                AddEdge(Edges[j], Edges[j + 1], Color);

                j += 2;
            }
        }
    }
}
