using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Arm
    {
        //6 Cylinders
        //5 Shperes

        //4 Cylinders
        //3 Shperes

        public List<Cylinder> Cylinders = new List<Cylinder>();
        public List<Sphere> Spheres = new List<Sphere>();
        public Kwtsh Tire = new Kwtsh();

        public void RightForward(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotZ(90);
            C.TransX(150 + 100);
            C.TransZ(-350);
            Cylinders.Add(C);

            Sphere S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.RotX(90);
            S.TransX((300 / 2) + 200 + 20);
            S.TransZ(-350);
            Spheres.Add(S);
            
            C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.TransX((300 / 2) + 200 + 20);
            C.TransY(-(300 / 2));
            C.TransZ(-350);
            Cylinders.Add(C);

            S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.TransX((300 / 2) + 200 + 20);
            S.TransY(-(300 / 2) - 150 + 10);
            S.TransZ(-350);
            Spheres.Add(S);
            
            C = new Cylinder();
            C.cam = Cam;
            C.Height = 250;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotX(90);
            C.TransX((300 / 2) + 200 + 20);
            C.TransY(-(300 / 2) - 150 + 10);
            C.TransZ(-350 - 125);
            Cylinders.Add(C);

            Tire = new Kwtsh();
            Tire.cam = Cam;
            Tire.Design();
            Tire.TransX((300 / 2) + 200 + 20);
            Tire.TransY(-(300 / 2) - 150 + 10);
            Tire.TransZ(-350 - 125 - 150);
            Tire.V0.X += (300 / 2) + 200 + 20;
            Tire.V0.Y += -(300 / 2) - 150 + 10;
            Tire.V0.Z += -350 - 125 - 150;
            Tire.Vz.X += (300 / 2) + 200 + 20;
            Tire.Vz.Y += -(300 / 2) - 150 + 10;
            Tire.Vz.Z += -350 - 125 - 150;
        }

        public void LeftForward(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotZ(90);
            C.TransX(150 + 100);
            C.TransZ(350);
            Cylinders.Add(C);

            Sphere S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.RotX(90);
            S.TransX((300 / 2) + 200 + 20);
            S.TransZ(350);
            Spheres.Add(S);

            C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.TransX((300 / 2) + 200 + 20);
            C.TransY(-(300 / 2));
            C.TransZ(350);
            Cylinders.Add(C);

            S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.TransX((300 / 2) + 200 + 20);
            S.TransY(-(300 / 2) - 150 + 10);
            S.TransZ(350);
            Spheres.Add(S);

            C = new Cylinder();
            C.cam = Cam;
            C.Height = 250;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotX(90);
            C.TransX((300 / 2) + 200 + 20);
            C.TransY(-(300 / 2) - 150 + 10);
            C.TransZ(350 + 125);
            Cylinders.Add(C);

            Tire = new Kwtsh();
            Tire.cam = Cam;
            Tire.Design();
            Tire.TransX((300 / 2) + 200 + 20);
            Tire.TransY(-(300 / 2) - 150 + 10);
            Tire.TransZ(350 + 125 + 75);
            Tire.V0.X += (300 / 2) + 200 + 20;
            Tire.V0.Y += -(300 / 2) - 150 + 10;
            Tire.V0.Z += (350 + 125 + 75);
            Tire.Vz.X += (300 / 2) + 200 + 20;
            Tire.Vz.Y += -(300 / 2) - 150 + 10;
            Tire.Vz.Z += (350 + 125 + 75);
        }

        public void RightBackward(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotZ(90);
            C.TransX(-150 - 100);
            C.TransZ(-350);
            Cylinders.Add(C);
           
            Sphere S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.RotX(90);
            S.TransX(-300 - 100 - 20);
            S.TransZ(-350);
            Spheres.Add(S);
            
            C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.TransX(-300 - 100 - 20);
            C.TransY(-(300 / 2));
            C.TransZ(-350);
            Cylinders.Add(C);
            
            S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.TransX(-300 - 100 - 20);
            S.TransY(-(300 / 2) - 150 + 10);
            S.TransZ(-350);
            Spheres.Add(S);
            
            C = new Cylinder();
            C.cam = Cam;
            C.Height = 250;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotX(90);
            C.TransX(-300 - 100 - 20);
            C.TransY(-(300 / 2) - 150 + 10);
            C.TransZ(-350 - 125);
            Cylinders.Add(C);
            
            Tire = new Kwtsh();
            Tire.cam = Cam;
            Tire.Design();
            Tire.TransX(-300 - 100 - 20);
            Tire.TransY(-(300 / 2) - 150 + 10);
            Tire.TransZ(-350 - 125 - 150);
            Tire.V0.X += -300 - 100 - 20;
            Tire.V0.Y += -(300 / 2) - 150 + 10;
            Tire.V0.Z += -350 - 125 - 150;
            Tire.Vz.X += -300 - 100 - 20;
            Tire.Vz.Y += -(300 / 2) - 150 + 10;
            Tire.Vz.Z += -350 - 125 - 150;
        }

        public void LeftBackward(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotZ(90);
            C.TransX(-150 - 100);
            C.TransZ(350);
            Cylinders.Add(C);

            Sphere S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.RotX(90);
            S.TransX(-300 - 100 - 20);
            S.TransZ(350);
            Spheres.Add(S);

            C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Red);
            C.TransX(-300 - 100 - 20);
            C.TransY(-(300 / 2));
            C.TransZ(350);
            Cylinders.Add(C);

            S = new Sphere();
            S.cam = Cam;
            S.Rad = 20;
            S.Design(Color.DarkGray);
            S.TransX(-300 - 100 - 20);
            S.TransY(-(300 / 2) - 150 + 10);
            S.TransZ(350);
            Spheres.Add(S);

            C = new Cylinder();
            C.cam = Cam;
            C.Height = 250;
            C.Rad = 20;
            C.Design(Color.Red);
            C.RotX(90);
            C.TransX(-300 - 100 - 20);
            C.TransY(-(300 / 2) - 150 + 10);
            C.TransZ(350 + 125);
            Cylinders.Add(C);

            Tire = new Kwtsh();
            Tire.cam = Cam;
            Tire.Design();
            Tire.TransX(-300 - 100 - 20);
            Tire.TransY(-(300 / 2) - 150 + 10);
            Tire.TransZ(350 + 125 + 75);
            Tire.V0.X += -300 - 100 - 20;
            Tire.V0.Y += -(300 / 2) - 150 + 10;
            Tire.V0.Z += (350 + 125 + 75);
            Tire.Vz.X += -300 - 100 - 20;
            Tire.Vz.Y += -(300 / 2) - 150 + 10;
            Tire.Vz.Z += (350 + 125 + 75);
        }
    }
}
