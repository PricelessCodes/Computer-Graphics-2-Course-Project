using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Shooter
    {
        //6 Cylinders
        //5 Shperes

        //4 Cylinders
        //3 Shperes

        public List<Cylinder> Cylinders = new List<Cylinder>();
        public Sphere S = new Sphere();
        public List<Sphere> Spheres = new List<Sphere>();
        public _3D_Point V0 = new _3D_Point(0, 0, 0);
        public _3D_Point Vx = new _3D_Point(1, 0, 0);
        public _3D_Point Vy = new _3D_Point(0, 1, 0);
        public _3D_Point Vz = new _3D_Point(0, 0, 1);

        public void CreateShooter(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 200;
            C.Rad = 30;
            C.Design(Color.DarkGreen);
            C.TransX(400);
            C.TransY(200 + 100);
            Cylinders.Add(C);

            S = new Sphere();
            S.cam = Cam;
            S.Rad = 30;
            S.Design(Color.Black);
            S.TransX(400);
            S.TransY(200 + 100 + 60 + 60);

            C = new Cylinder();
            C.cam = Cam;
            C.Height = 200;
            C.Rad = 30;
            C.Design(Color.DarkGreen);
            C.RotZ(90);
            C.TransX(400 + 100);
            C.TransY(200 + 100 + 60 + 60);
            Cylinders.Add(C);

            V0.X += 400;
            V0.Y += 200 + 100 + 60 + 60;

            Vx.X += 400;
            Vx.Y += 200 + 100 + 60 + 60;

            Vy.X += 400;
            Vy.Y += 200 + 100 + 60 + 60;

            Vz.X += 400;
            Vz.Y += 200 + 100 + 60 + 60;
        }

    }
}
