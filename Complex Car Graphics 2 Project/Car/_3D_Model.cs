using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Car
{
    public class _3D_Model
    {
        public List<_3D_Point> L_3D_Pts = new List<_3D_Point>();
        public List<Edge> L_Edges = new List<Edge>();
        public Camera cam;

        public void AddPoint(_3D_Point pnn)
        {
            L_3D_Pts.Add(pnn);
        }

        public void AddEdge(int i , int j , Color cl)
        {
            Edge pnn = new Edge(i, j);
            pnn.cl = cl;
            L_Edges.Add(pnn);
        }

        public void RotX(float th)
        {
            Transformation.RotatX(L_3D_Pts, th);
        }

        public void TransX(float tx)
        {
            Transformation.TranslateX(L_3D_Pts , tx);
        }

        public void TransY(float ty)
        {
            Transformation.TranslateY(L_3D_Pts, ty);
        }

        public void TransZ(float tz)
        {
            Transformation.TranslateZ(L_3D_Pts, tz);
        }

        public void RotY(float th)
        {
            Transformation.RotatY(L_3D_Pts, th);
        }

        public void RotZ(float th)
        {
            Transformation.RotatZ(L_3D_Pts, th);
        }

        public void RotateAroundEdge(int iWhichEdge, float th)
        {
            _3D_Point p1 = new _3D_Point  (L_3D_Pts[L_Edges[iWhichEdge].i] );
            _3D_Point p2 = new _3D_Point  (L_3D_Pts[L_Edges[iWhichEdge].j] );
            Transformation.RotateArbitrary(L_3D_Pts, p1, p2, th);
        }

        public void DrawYourSelf(Graphics g)
        {
            Font FF = new Font("System", 10);
            for (int k = 0; k < L_Edges.Count; k++)
            {
                int i = L_Edges[k].i;
                int j = L_Edges[k].j;

                _3D_Point pi = L_3D_Pts[i];
                _3D_Point pj = L_3D_Pts[j];

                PointF pi_2D = cam.TransformToOrigin_And_Rotate_And_Project(pi);
                PointF pj_2D = cam.TransformToOrigin_And_Rotate_And_Project(pj);

                

                Pen Pn = new Pen(L_Edges[k].cl, 2);

                g.DrawLine(Pn, pi_2D.X, pi_2D.Y, pj_2D.X, pj_2D.Y);
            }
        }
    }
}
