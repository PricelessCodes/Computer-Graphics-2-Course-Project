using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Tornado : _3D_Model
    {
        //6 Cylinders
        //5 Shperes

        //4 Cylinders
        //3 Shperes

        public List<Cylinder> Cylinders = new List<Cylinder>();
        public List<Sphere> Spheres = new List<Sphere>();
        public List<_3D_Model> Planes = new List<_3D_Model>();
        public _3D_Point V1 = new _3D_Point(0, 0, 0);
        public _3D_Point Vy = new _3D_Point(0, 1, 0);

        public void CreateBar(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 600;
            C.Rad = 20;
            C.Design(Color.Red);
            C.TransY(200 + 300);
            Cylinders.Add(C);
            
            Sphere S = new Sphere();
            S.cam = Cam;
            S.Rad = 50;
            S.Design(Color.DarkGray);
            S.TransY(200 + 600 + 50);
            Spheres.Add(S);

            V1.Y += 200 + 600 + 50;
            Vy.Y += 200 + 600 + 50;

            //Planes
            _3D_Model Pl = new _3D_Model();
            for (int i = 0 ; i < 4 ; i++)
            {
                Pl = new _3D_Model();
                Pl.cam = Cam;
                Design(Color.Black, Pl);
                Planes.Add(Pl);
            }
            Planes[0].TransY(200 + 600 + 50);
            Planes[0].TransX(-310);

            Planes[1].RotY(90);
            Planes[1].TransY(200 + 600 + 50);
            Planes[1].TransZ(310);

            Planes[2].TransY(200 + 600 + 50);
            Planes[2].TransX(310);

            Planes[3].RotY(90);
            Planes[3].TransY(200 + 600 + 50);
            Planes[3].TransZ(-310);

        }

        public void Design(Color Color, _3D_Model Pl)
        {
            float[] vert = 
                            { 
                                -300  ,  -5 ,  10, //0
                                 300  ,  -5 ,  10, //1
                                 300  ,  -5 , -10, //2
                                -300  ,  -5 , -10, //3
                                 
                                -300  ,   5 ,  10, //4
                                 300  ,   5 ,  10, //5
                                 300  ,   5 , -10, //6
                                -300  ,   5 , -10, //7
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j], vert[j + 1], vert[j + 2]);
                j += 3;
                Pl.AddPoint(pnn);
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
                              1,5,
                              2,6,
                              3,7,
                          };
            j = 0;
            for (int i = 0; i < 12; i++)
            {
                Pl.AddEdge(Edges[j], Edges[j + 1], Color);

                j += 2;
            }
        }
    }
}
