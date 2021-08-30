using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Car
{
    public partial class Form1 : Form
    {
        _3D_Model Line = new _3D_Model();
        Bitmap off;

        Camera Cam = new Camera();
        

        Timer T = new Timer();
        int Counter = 0;
        int Flag = 0;
        int MoveSpeed = 5;

        Tank TankObject = new Tank();

        Cylinder C = new Cylinder();

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Load += new EventHandler(Form1_Load);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            T.Tick += new EventHandler(T_Tick);
            T.Interval = 1;
            T.Start();

        }

        void RotatY(float Angle)
        {
            float th = (float)(Angle * Math.PI / 180);

            float x_ = (float)(Cam.cop.Z * Math.Sin(th) + Cam.cop.X * Math.Cos(th));

            float y_ = Cam.cop.Y;

            float z_ = (float)(Cam.cop.Z * Math.Cos(th) - Cam.cop.X * Math.Sin(th));

            Cam.cop.X = x_;
            Cam.cop.Z = z_;
            Cam.BuildNewSystem();

        }

        void RotatZ(float Angle)
        {
            float th = (float)(Angle * Math.PI / 180);

            float x_ = (float)(Cam.cop.Y * Math.Sin(th) + Cam.cop.X * Math.Cos(th));

            float y_ = (float)(Cam.cop.Y * Math.Cos(th) - Cam.cop.X * Math.Sin(th));

            float z_ = Cam.cop.Z;

            Cam.cop.X = x_;
            Cam.cop.Y = y_;
            Cam.cop.Z = z_;
            Cam.BuildNewSystem();

        }

        void RotatX(float Angle)
        {
            float th = (float)(Angle * Math.PI / 180);

            float x_ = Cam.cop.X;
            float y_ = (float)(Cam.cop.Y * Math.Cos(th) - Cam.cop.Z * Math.Sin(th));
            float z_ = (float)(Cam.cop.Y * Math.Sin(th) + Cam.cop.Z * Math.Cos(th));

            Cam.cop.X = x_;
            Cam.cop.Y = y_;
            Cam.cop.Z = z_;
            Cam.BuildNewSystem();

        }

        void T_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < TankObject.Turbo0.BackFlys.Count; i++)
            {
                if (i/2 == 0)
                    Transformation.RotateArbitrary(TankObject.Turbo0.BackFlys[i].L_3D_Pts, TankObject.Turbo0.V0, TankObject.Turbo0.Vx, -5);
                else
                    Transformation.RotateArbitrary(TankObject.Turbo0.BackFlys[i].L_3D_Pts, TankObject.Turbo0.V0, TankObject.Turbo0.Vx, 5);
            }
            for (int i = 0; i < TankObject.Tornado0.Planes.Count; i++)
            {
                Transformation.RotateArbitrary(TankObject.Tornado0.Planes[i].L_3D_Pts, TankObject.Tornado0.V1, TankObject.Tornado0.Vy, 5);
            }
            Transformation.RotateArbitrary(TankObject.PlatAntina.TopPlat.L_3D_Pts, TankObject.PlatAntina.TopPlat.V0, TankObject.PlatAntina.TopPlat.Vy, 5);

            for (int i = 0; i < TankObject.Shoot.Spheres.Count; i++)
            {
                float diffX = TankObject.Shoot.Spheres[i].Vx.X - TankObject.Shoot.Spheres[i].V0.X;
                float diffY = TankObject.Shoot.Spheres[i].Vx.Y - TankObject.Shoot.Spheres[i].V0.Y;
                float diffZ = TankObject.Shoot.Spheres[i].Vx.Z - TankObject.Shoot.Spheres[i].V0.Z;

                TankObject.Shoot.Spheres[i].TransX(diffX * TankObject.Speed);
                TankObject.Shoot.Spheres[i].TransY(diffY * TankObject.Speed);
                TankObject.Shoot.Spheres[i].TransZ(diffZ * TankObject.Speed);
            }
            Cam.BuildNewSystem();
            DrawDubble(this.CreateGraphics());
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    TankObject.RotateShooter('A');
                    break;
                case Keys.D:
                    TankObject.RotateShooter('D');
                    break;
                case Keys.W:
                    TankObject.RotateShooter('W');
                    break;
                case Keys.S:
                    TankObject.RotateShooter('S');
                    break;
                case Keys.X:
                    RotatX(5);
                    break;
                case Keys.Y:
                    RotatY(5);
                    break;
                case Keys.Z:
                    RotatZ(5);
                    break;
                case Keys.Right:
                    TankObject.RotateRightAndLeft(1);
                    break;
                case Keys.Left:
                    TankObject.RotateRightAndLeft(-1);
                    break;

                case Keys.Up:
                    TankObject.MoveForwardAndBackward(true);
                    break;
                case Keys.Down:
                    TankObject.MoveForwardAndBackward(false);
                    break;

                case Keys.Space:
                    TankObject.Fire(Cam);
                    break;
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);


            int cx = 400;
            int cy = 400;
            Cam.ceneterX = (this.ClientSize.Width / 2);
            Cam.ceneterY = (this.ClientSize.Height / 2);
            Cam.cxScreen = cx;
            Cam.cyScreen = cy;
            Cam.BuildNewSystem();

            TankObject.Design(TankObject, Cam);

            RotatY(120);
            RotatZ(45);

        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubble(e.Graphics);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            
            TankObject.TankBody.DrawYourSelf(g);
            for (int i = 0; i < TankObject.ArmsHolders.Count; i++)
            {
                TankObject.ArmsHolders[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Turbo0.BackFlys.Count; i++)
            {
                TankObject.Turbo0.BackFlys[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Turbo0.Cylinders.Count; i++)
            {
                TankObject.Turbo0.Cylinders[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Arms.Count; i++)
            {
                for (int j = 0; j < TankObject.Arms[i].Cylinders.Count; j++)
                {
                    TankObject.Arms[i].Cylinders[j].DrawYourSelf(g);
                }
                for (int j = 0; j < TankObject.Arms[i].Spheres.Count; j++)
                {
                    TankObject.Arms[i].Spheres[j].DrawYourSelf(g);
                }
                TankObject.Arms[i].Tire.DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Tornado0.Cylinders.Count; i++)
            {
                TankObject.Tornado0.Cylinders[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Tornado0.Spheres.Count; i++)
            {
                TankObject.Tornado0.Spheres[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Tornado0.Planes.Count; i++)
            {
                TankObject.Tornado0.Planes[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Cubas.Count; i++)
            {
                TankObject.Cubas[i].DrawYourSelf(g);
            }
            TankObject.PlatAntina.Bar.DrawYourSelf(g);
            TankObject.PlatAntina.Antinaa.DrawYourSelf(g);
            TankObject.PlatAntina.TopPlat.DrawYourSelf(g);
            TankObject.PlatAntina.Ball.DrawYourSelf(g);
            
            for (int i = 0; i < TankObject.Shoot.Spheres.Count; i++)
            {
                TankObject.Shoot.Spheres[i].DrawYourSelf(g);
            }
            for (int i = 0; i < TankObject.Shoot.Cylinders.Count; i++)
            {
                TankObject.Shoot.Cylinders[i].DrawYourSelf(g);
            }
            TankObject.Shoot.S.DrawYourSelf(g);
        }

        void DrawDubble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
