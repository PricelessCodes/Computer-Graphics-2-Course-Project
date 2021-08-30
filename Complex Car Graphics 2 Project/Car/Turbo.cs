using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class Turbo
    {
        //BackFlys
        public List<BackFly> BackFlys = new List<BackFly>();
        public List<Cylinder> Cylinders = new List<Cylinder>();
        //public Cylinder EE = new Cylinder();
        public _3D_Point V0 = new _3D_Point(0, 0, 0);
        public _3D_Point Vx = new _3D_Point(1, 0, 0);

        public void CreateTurbo(Camera Cam)
        {
            CreateBackFlys(Cam);
            CreateCylinders(Cam);
        }

        void CreateBackFlys(Camera Cam)
        {
            BackFly BF = new BackFly();
            BF.cam = Cam;
            BF.Rad = 200;
            BF.Design(Color.Black);
            BackFlys.Add(BF);

            BF = new BackFly();
            BF.cam = Cam;
            BF.Rad = 180;
            BF.Design(Color.Yellow);
            BackFlys.Add(BF);

            BF = new BackFly();
            BF.cam = Cam;
            BF.Rad = 160;
            BF.Design(Color.Green);
            BackFlys.Add(BF);

            BF = new BackFly();
            BF.cam = Cam;
            BF.Rad = 140;
            BF.Design(Color.Red);
            BackFlys.Add(BF);

            BF = new BackFly();
            BF.cam = Cam;
            BF.Rad = 120;
            BF.Design(Color.Blue);
            BackFlys.Add(BF);
        }
        void CreateCylinders(Camera Cam)
        {
            Cylinder C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Black);
            C.RotZ(90);
            C.TransX(300 + 40);
            Cylinders.Add(C);

            C = new Cylinder();
            C.cam = Cam;
            C.Height = 40;
            C.Rad = 20;
            C.Design(Color.Brown);
            C.RotX(90);
            C.TransX((300 / 2) + 300 + 40);
            Cylinders.Add(C);
            
            C = new Cylinder();
            C.cam = Cam;
            C.Height = 300;
            C.Rad = 20;
            C.Design(Color.Black);
            C.TransX((300 / 2) + 300 + 40);
            C.TransY(-(300 / 2) - 20);
            Cylinders.Add(C);

        }
    }
}
