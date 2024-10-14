using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class Bezier: IShape
    {
        private PointF _Point1;
        private PointF _Point2;
        private PointF _Point3;
       

        public Bezier(PointF point1, PointF point2, PointF point3)
        {
            _Point1 = point1;
            _Point2 = point2;
            _Point3 = point3;

        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            gr.DrawBezier(pen, pt, _Point1, _Point2, _Point3);
        }
    }
}
