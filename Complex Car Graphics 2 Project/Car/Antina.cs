using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Antina : _3D_Model
    {
        public Sphere Antinaa = new Sphere();
        public Cylinder Bar = new Cylinder();
        public Plat TopPlat = new Plat();
        public Sphere Ball = new Sphere();

        public void Design(Camera Cam)
        {
            Bar = new Cylinder();
            Bar.cam = Cam;
            Bar.Height = 200;
            Bar.Rad = 20;
            Bar.Design(Color.Red);
            Bar.TransX(-400);
            Bar.TransY(200 + 100);
            Bar.TransZ(200);

            Antinaa = new Sphere();
            Antinaa.cam = Cam;
            Antinaa.Rad = 30;
            Antinaa.Design(Color.DarkGray);
            Antinaa.TransX(-400);
            Antinaa.TransY(200 + 200 + 30);
            Antinaa.TransZ(200);

            TopPlat = new Plat();
            TopPlat.cam = Cam;
            TopPlat.Design(Color.Blue);
            TopPlat.RotZ(45);
            TopPlat.TransX(-400);
            TopPlat.TransY(200 + 200 + 140);
            TopPlat.TransZ(200);
            TopPlat.V0.X += -400;
            TopPlat.V0.Y += 200 + 200 + 140;
            TopPlat.V0.Z += 200;
            TopPlat.Vy.X += -400;
            TopPlat.Vy.Y += 200 + 200 + 140;
            TopPlat.Vy.Z += 200;

            Ball = new Sphere();
            Ball.cam = Cam;
            Ball.Rad = 30;
            Ball.Design(Color.Black);
            Ball.TransX(-400);
            Ball.TransY(200 + 200 + 140 + 5);
            Ball.TransZ(200);
        }
    }
}
