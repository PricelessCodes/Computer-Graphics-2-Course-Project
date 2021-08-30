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
    public class Tank
    {
        public float Speed = 5, Angle = 5;
        public Body TankBody = new Body();
        //2 Arm Holders
        public List<ArmsHolder> ArmsHolders = new List<ArmsHolder>();

        public Turbo Turbo0 = new Turbo();

        //4Legs
        public List<Arm> Arms = new List<Arm>();

        public Tornado Tornado0 = new Tornado();

        public List<Cuba> Cubas = new List<Cuba>();

        public Antina PlatAntina = new Antina();

        public Shooter Shoot = new Shooter();

        public void Design(Tank TankObject, Camera Cam)
        {
            //Tank Body
            TankObject.TankBody.cam = Cam;
            TankObject.TankBody.Design(Color.Black);

            //Tank Arms Holder
            //Right Holder
            ArmsHolder AH = new ArmsHolder();
            AH.cam = Cam;
            AH.W = 100;
            AH.V0.X = 0;
            AH.V0.Y = 0;
            AH.V0.Z += -300 - (AH.W / 2);
            AH.Vx.Z += -300 - (AH.W / 2);
            AH.Vy.Z += -300 - (AH.W / 2);
            AH.Vz.Z += -300 - (AH.W / 2);
            AH.Design(Color.Black);
            TankObject.ArmsHolders.Add(AH);
            //Leftt Holder
            AH = new ArmsHolder();
            AH.cam = Cam;
            AH.W = 100;
            AH.V0.X = 0;
            AH.V0.Y = 0;
            AH.V0.Z = 0;
            AH.Design(Color.Black);
            AH.RotX(180);
            AH.TransZ(300 + (AH.W / 2));
            AH.V0.Z += 300 + (AH.W / 2);
            AH.Vx.Z += 300 + (AH.W / 2);
            AH.Vy.Z += 300 + (AH.W / 2);
            AH.Vz.Z += 300 + (AH.W / 2);
            TankObject.ArmsHolders.Add(AH);

            //Turbo
            Turbo0.CreateTurbo(Cam);
            for (int i = 0; i < Turbo0.BackFlys.Count; i++)
            {
                Turbo0.BackFlys[i].TransX(-500 - Turbo0.BackFlys[i].Rad - 250);
                Turbo0.BackFlys[i].TransY(200 + 300);
            }
            for (int i = 0; i < Turbo0.Cylinders.Count; i++)
            {
                Turbo0.Cylinders[i].TransX(-500 - 200 - 250);
                Turbo0.Cylinders[i].TransY(200 + 300);
            }
            Turbo0.V0.X += (-500 - 200 - 250);
            Turbo0.V0.Y += (200 + 300);
            Turbo0.Vx.X += (-500 - 200 - 250);
            Turbo0.Vx.Y += (200 + 300);

            //Legs
            Arm A = new Arm();
            A.RightForward(Cam);
            Arms.Add(A);
            
            A = new Arm();
            A.LeftForward(Cam);
            Arms.Add(A);
            
            A = new Arm();
            A.RightBackward(Cam);
            Arms.Add(A);

            A = new Arm();
            A.LeftBackward(Cam);
            Arms.Add(A);

            //Tornado
            Tornado0.cam = Cam;
            Tornado0.CreateBar(Cam);

            //Cuba
            Cuba cb = new Cuba();
            cb.cam = Cam;
            cb.Design(Color.DarkGray);
            cb.TransX(-400);
            cb.TransZ(-200);
            cb.TransY(240);
            Cubas.Add(cb);
            cb = new Cuba();
            cb.cam = Cam;
            cb.Design(Color.DarkGray);
            cb.TransX(-300);
            cb.TransZ(-200);
            cb.TransY(240);
            Cubas.Add(cb);
            cb = new Cuba();
            cb.cam = Cam;
            cb.Design(Color.DarkGray);
            cb.TransX(-200);
            cb.TransZ(-200);
            cb.TransY(240);
            Cubas.Add(cb);

            //Antinaa
            PlatAntina = new Antina();
            PlatAntina.Design(Cam);

            //Shooter
            Shoot.CreateShooter(Cam);

        }

        public void MoveForwardAndBackward(bool Flag)
        {
            MoveBody(Flag);
            MoveArmsHolders(Flag);
            MoveTurbo(Flag);
            MoveArms(Flag);
            MoveTornado(Flag);
            MoveCubas(Flag);
            MoveAntina(Flag);
            MoveShooter(Flag);
        }

        public void RotateRightAndLeft(int Dir)
        {
            RotateBody(Dir);
            RotateArmsHolders(Dir);
            RotateTurbo(Dir);
            RotateArms(Dir);
            RotateCubas(Dir);
            RotateAntina(Dir);
            RotateShooter(Dir);
        }

        void MoveBody(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            TankBody.TransX(diffX * Speed);
            TankBody.TransY(diffY * Speed);
            TankBody.TransZ(diffZ * Speed);
            TankBody.V1.X += diffX * Speed;
            TankBody.V1.Y += diffY * Speed;
            TankBody.V1.Z += diffZ * Speed;
            TankBody.Vx.X += diffX * Speed;
            TankBody.Vx.Y += diffY * Speed;
            TankBody.Vx.Z += diffZ * Speed;
        }

        void MoveArmsHolders(bool Flag)
        {
            for (int i = 0; i < ArmsHolders.Count; i++)
            {
                float diffX = 0;
                float diffY = 0;
                float diffZ = 0;
                if (Flag == true)
                {
                    diffX = TankBody.Vx.X - TankBody.V1.X;
                    diffY = TankBody.Vx.Y - TankBody.V1.Y;
                    diffZ = TankBody.Vx.Z - TankBody.V1.Z;
                }
                else
                {
                    diffX = TankBody.V1.X - TankBody.Vx.X;
                    diffY = TankBody.V1.Y - TankBody.Vx.Y;
                    diffZ = TankBody.V1.Z - TankBody.Vx.Z;
                }
                ArmsHolders[i].TransX(diffX * Speed);
                ArmsHolders[i].TransY(diffY * Speed);
                ArmsHolders[i].TransZ(diffZ * Speed);
                ArmsHolders[i].V0.X += diffX * Speed;
                ArmsHolders[i].V0.Y += diffY * Speed;
                ArmsHolders[i].V0.Z += diffZ * Speed;
                ArmsHolders[i].Vz.X += diffX * Speed;
                ArmsHolders[i].Vz.Y += diffY * Speed;
                ArmsHolders[i].Vz.Z += diffZ * Speed;
            }
        }
        void MoveArms(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            for (int i = 0; i < Arms.Count; i++ )
            {
                for (int j = 0; j < Arms[i].Cylinders.Count; j++)
                {
                    Arms[i].Cylinders[j].TransX(diffX * Speed);
                    Arms[i].Cylinders[j].TransY(diffY * Speed);
                    Arms[i].Cylinders[j].TransZ(diffZ * Speed);
                }
                for (int j = 0; j < Arms[i].Spheres.Count; j++)
                {
                    Arms[i].Spheres[j].TransX(diffX * Speed);
                    Arms[i].Spheres[j].TransY(diffY * Speed);
                    Arms[i].Spheres[j].TransZ(diffZ * Speed);
                }
                Arms[i].Tire.TransX(diffX * Speed);
                Arms[i].Tire.TransY(diffY * Speed);
                Arms[i].Tire.TransZ(diffZ * Speed);
                Arms[i].Tire.V0.X += diffX * Speed;
                Arms[i].Tire.V0.Y += diffY * Speed;
                Arms[i].Tire.V0.Z += diffZ * Speed;
                Arms[i].Tire.Vz.X += diffX * Speed;
                Arms[i].Tire.Vz.Y += diffY * Speed;
                Arms[i].Tire.Vz.Z += diffZ * Speed;
                if (Flag == true)
                    Transformation.RotateArbitrary(Arms[i].Tire.L_3D_Pts, Arms[i].Tire.V0, Arms[i].Tire.Vz, -Speed);
                else
                    Transformation.RotateArbitrary(Arms[i].Tire.L_3D_Pts, Arms[i].Tire.V0, Arms[i].Tire.Vz, Speed);
            }
        }
        void MoveTornado(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            for (int i = 0; i < Tornado0.Cylinders.Count; i++)
            {
                Tornado0.Cylinders[i].TransX(diffX * Speed);
                Tornado0.Cylinders[i].TransY(diffY * Speed);
                Tornado0.Cylinders[i].TransZ(diffZ * Speed);
            }
            for (int i = 0; i < Tornado0.Spheres.Count; i++)
            {
                Tornado0.Spheres[i].TransX(diffX * Speed);
                Tornado0.Spheres[i].TransY(diffY * Speed);
                Tornado0.Spheres[i].TransZ(diffZ * Speed);
            }
            for (int i = 0; i < Tornado0.Planes.Count; i++)
            {
                Tornado0.Planes[i].TransX(diffX * Speed);
                Tornado0.Planes[i].TransY(diffY * Speed);
                Tornado0.Planes[i].TransZ(diffZ * Speed);
            }
            Tornado0.V1.X += diffX * Speed;
            Tornado0.V1.Y += diffY * Speed;
            Tornado0.V1.Z += diffZ * Speed;
            Tornado0.Vy.X += diffX * Speed;
            Tornado0.Vy.Y += diffY * Speed;
            Tornado0.Vy.Z += diffZ * Speed;
        }
        void MoveTurbo(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            for (int i = 0; i < Turbo0.BackFlys.Count; i++)
            {
                Turbo0.BackFlys[i].TransX(diffX * Speed);
                Turbo0.BackFlys[i].TransY(diffY * Speed);
                Turbo0.BackFlys[i].TransZ(diffZ * Speed);
            }
            for (int i = 0; i < Turbo0.Cylinders.Count; i++)
            {
                Turbo0.Cylinders[i].TransX(diffX * Speed);
                Turbo0.Cylinders[i].TransY(diffY * Speed);
                Turbo0.Cylinders[i].TransZ(diffZ * Speed);
            }
            Turbo0.V0.X += (diffX * Speed);
            Turbo0.V0.Y += (diffY * Speed);
            Turbo0.V0.Z += (diffZ * Speed);
            Turbo0.Vx.X += (diffX * Speed);
            Turbo0.Vx.Y += (diffY * Speed);
            Turbo0.Vx.Z += (diffZ * Speed);
        }
        void MoveCubas(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            for (int i = 0; i < Cubas.Count; i++)
            {
                Cubas[i].TransX(diffX * Speed);
                Cubas[i].TransY(diffY * Speed);
                Cubas[i].TransZ(diffZ * Speed);
            }
        }
        void MoveAntina(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            PlatAntina.Bar.TransX(diffX * Speed);
            PlatAntina.Bar.TransY(diffY * Speed);
            PlatAntina.Bar.TransZ(diffZ * Speed);
            PlatAntina.Antinaa.TransX(diffX * Speed);
            PlatAntina.Antinaa.TransY(diffY * Speed);
            PlatAntina.Antinaa.TransZ(diffZ * Speed);
            PlatAntina.TopPlat.TransX(diffX * Speed);
            PlatAntina.TopPlat.TransY(diffY * Speed);
            PlatAntina.TopPlat.TransZ(diffZ * Speed);
            
            PlatAntina.TopPlat.V0.X += (diffX * Speed);
            PlatAntina.TopPlat.V0.Y += (diffY * Speed);
            PlatAntina.TopPlat.V0.Z += (diffZ * Speed);
            PlatAntina.TopPlat.Vy.X += (diffX * Speed);
            PlatAntina.TopPlat.Vy.Y += (diffY * Speed);
            PlatAntina.TopPlat.Vy.Z += (diffZ * Speed);
            
            PlatAntina.Ball.TransX(diffX * Speed);
            PlatAntina.Ball.TransY(diffY * Speed);
            PlatAntina.Ball.TransZ(diffZ * Speed);
            
        }
        void MoveShooter(bool Flag)
        {
            float diffX = 0;
            float diffY = 0;
            float diffZ = 0;
            if (Flag == true)
            {
                diffX = TankBody.Vx.X - TankBody.V1.X;
                diffY = TankBody.Vx.Y - TankBody.V1.Y;
                diffZ = TankBody.Vx.Z - TankBody.V1.Z;
            }
            else
            {
                diffX = TankBody.V1.X - TankBody.Vx.X;
                diffY = TankBody.V1.Y - TankBody.Vx.Y;
                diffZ = TankBody.V1.Z - TankBody.Vx.Z;
            }
            for (int i = 0; i < Shoot.Cylinders.Count; i++)
            {
                Shoot.Cylinders[i].TransX(diffX * Speed);
                Shoot.Cylinders[i].TransY(diffY * Speed);
                Shoot.Cylinders[i].TransZ(diffZ * Speed);
            }
            Shoot.S.TransX(diffX * Speed);
            Shoot.S.TransY(diffY * Speed);
            Shoot.S.TransZ(diffZ * Speed);

            Shoot.V0.X += diffX * Speed;
            Shoot.V0.Y += diffY * Speed;
            Shoot.V0.Z += diffZ * Speed;

            Shoot.Vx.X += diffX * Speed;
            Shoot.Vx.Y += diffY * Speed;
            Shoot.Vx.Z += diffZ * Speed;

            Shoot.Vy.X += diffX * Speed;
            Shoot.Vy.Y += diffY * Speed;
            Shoot.Vy.Z += diffZ * Speed;

            Shoot.Vz.X += diffX * Speed;
            Shoot.Vz.Y += diffY * Speed;
            Shoot.Vz.Z += diffZ * Speed;
        }
        
        void RotateBody(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);
            Transformation.RotateArbitrary(TankBody.L_3D_Pts, V, V2, Angle * Dir);
            List<_3D_Point> P = new List<_3D_Point>();
            P.Add(TankBody.V1);
            P.Add(TankBody.Vx);
            Transformation.RotateArbitrary(P, V, V2, Angle * Dir);
        }
        void RotateArmsHolders(int Dir)
        {
            for (int i = 0; i < ArmsHolders.Count; i++)
            {
                _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
                _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);
                Transformation.RotateArbitrary(ArmsHolders[i].L_3D_Pts, V, V2, Angle * Dir);
                List<_3D_Point> P = new List<_3D_Point>();
                P.Add(ArmsHolders[i].V0);
                P.Add(ArmsHolders[i].Vz);
                Transformation.RotateArbitrary(P, V, V2, Angle * Dir);
            }
        }
        void RotateTurbo(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);
            for (int i = 0; i < Turbo0.BackFlys.Count; i++)
            {
                Transformation.RotateArbitrary(Turbo0.BackFlys[i].L_3D_Pts, V, V2, Angle * Dir);
            }
            for (int i = 0; i < Turbo0.Cylinders.Count; i++)
            {
                Transformation.RotateArbitrary(Turbo0.Cylinders[i].L_3D_Pts, V, V2, Angle * Dir);
            }
            List<_3D_Point> P = new List<_3D_Point>();
            P.Add(Turbo0.V0);
            P.Add(Turbo0.Vx);
            Transformation.RotateArbitrary(P, V, V2, Angle * Dir);
        }
        void RotateArms(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);
            for (int i = 0; i < Arms.Count; i++)
            {
                for (int j = 0; j < Arms[i].Cylinders.Count; j++)
                {
                    Transformation.RotateArbitrary(Arms[i].Cylinders[j].L_3D_Pts, V, V2, Angle * Dir);
                }
                for (int j = 0; j < Arms[i].Spheres.Count; j++)
                {
                    Transformation.RotateArbitrary(Arms[i].Spheres[j].L_3D_Pts, V, V2, Angle * Dir);
                }
                Transformation.RotateArbitrary(Arms[i].Tire.L_3D_Pts, V, V2, Angle * Dir);
                List<_3D_Point> P = new List<_3D_Point>();
                P.Add(Arms[i].Tire.V0);
                P.Add(Arms[i].Tire.Vz);
                Transformation.RotateArbitrary(P, V, V2, Angle * Dir);
            }
        }
        void RotateTornado(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);
             
            for (int i = 0; i < Tornado0.Cylinders.Count; i++)
            {
                Transformation.RotateArbitrary(Tornado0.Cylinders[i].L_3D_Pts, V, V2, Angle * Dir);
            }
            for (int i = 0; i < Tornado0.Spheres.Count; i++)
            {
                Transformation.RotateArbitrary(Tornado0.Spheres[i].L_3D_Pts, V, V2, Angle * Dir);
            }
            for (int i = 0; i < Tornado0.Planes.Count; i++)
            {
                Transformation.RotateArbitrary(Tornado0.Planes[i].L_3D_Pts, V, V2, Angle * Dir);                
            }
            List<_3D_Point> P = new List<_3D_Point>();
            P.Add(Tornado0.V1);
            P.Add(Tornado0.Vy);
            Transformation.RotateArbitrary(P, V, V2, Angle * Dir);
        }
        void RotateCubas(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);

            for (int i = 0; i < Cubas.Count; i++)
            {
                Transformation.RotateArbitrary(Cubas[i].L_3D_Pts, V, V2, Angle * Dir);
            }
        }
        void RotateAntina(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);

            Transformation.RotateArbitrary(PlatAntina.Bar.L_3D_Pts, V, V2, Angle * Dir);
            Transformation.RotateArbitrary(PlatAntina.Antinaa.L_3D_Pts, V, V2, Angle * Dir);
            Transformation.RotateArbitrary(PlatAntina.TopPlat.L_3D_Pts, V, V2, Angle * Dir);

            List<_3D_Point> P = new List<_3D_Point>();
            P.Add(PlatAntina.TopPlat.V0);
            P.Add(PlatAntina.TopPlat.Vy);
            Transformation.RotateArbitrary(P, V, V2, Angle * Dir);

            Transformation.RotateArbitrary(PlatAntina.Ball.L_3D_Pts, V, V2, Angle * Dir);
        }
        void RotateShooter(int Dir)
        {
            _3D_Point V = new _3D_Point(TankBody.V1.X, TankBody.V1.Y, TankBody.V1.Z);
            _3D_Point V2 = new _3D_Point(TankBody.V1.X, TankBody.V1.Y + 1, TankBody.V1.Z);
            for (int i = 0; i < Shoot.Cylinders.Count; i++)
            {
                Transformation.RotateArbitrary(Shoot.Cylinders[i].L_3D_Pts, V, V2, Angle * Dir);
            }
            Transformation.RotateArbitrary(Shoot.S.L_3D_Pts, V, V2, Angle * Dir);
            
            List<_3D_Point> P = new List<_3D_Point>();
            P.Add(Shoot.V0);
            P.Add(Shoot.Vx);
            P.Add(Shoot.Vy);
            P.Add(Shoot.Vz);
            Transformation.RotateArbitrary(P, V, V2, Angle * Dir);
        }

        public void RotateShooter(char Key)
        {
            if (Key == 'A')
            {
                Transformation.RotateArbitrary(Shoot.Cylinders[1].L_3D_Pts, Shoot.V0, Shoot.Vy, Angle * -1);
            }
            else if (Key == 'D')
            {
                Transformation.RotateArbitrary(Shoot.Cylinders[1].L_3D_Pts, Shoot.V0, Shoot.Vy, Angle * 1);
            }
            else if (Key == 'W')
            {
                Transformation.RotateArbitrary(Shoot.Cylinders[1].L_3D_Pts, Shoot.V0, Shoot.Vz, Angle * 1);
            }
            else if (Key == 'S')
            {
                Transformation.RotateArbitrary(Shoot.Cylinders[1].L_3D_Pts, Shoot.V0, Shoot.Vz, Angle * -1);
            }
        }
        public void Fire(Camera Cam)
        {
            Sphere FiredBall = new Sphere();
            FiredBall.cam = Cam;
            FiredBall.Rad = 30;
            FiredBall.Design(Color.Gold);
            FiredBall.TransX(Shoot.V0.X);
            FiredBall.TransY(Shoot.V0.Y);
            FiredBall.TransZ(Shoot.V0.Z);
            FiredBall.V0 = new _3D_Point(Shoot.V0.X, Shoot.V0.Y, Shoot.V0.Z);
            FiredBall.Vx = new _3D_Point(Shoot.Vx.X, Shoot.Vx.Y, Shoot.Vx.Z);
            FiredBall.Vy = new _3D_Point(Shoot.Vy.X, Shoot.Vy.Y, Shoot.Vy.Z);
            FiredBall.Vz = new _3D_Point(Shoot.Vz.X, Shoot.Vz.Y, Shoot.Vz.Z);
            Shoot.Spheres.Add(FiredBall);
        }
    }
}
