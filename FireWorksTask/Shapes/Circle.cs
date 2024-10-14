using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class Circle : IShape
    {
       
        private float _Radius { get; set; }

        public Circle(float radius)
        {
            _Radius = radius;
        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            float diameter = 2 * _Radius;
            gr.FillEllipse(brush, pt.X - _Radius, pt.Y - _Radius, diameter, diameter);
            gr.DrawEllipse(pen, pt.X - _Radius, pt.Y - _Radius, diameter, diameter);
        }
    }
}
