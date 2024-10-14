using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class ClosedCurves: IShape
    {
        public PointF[] Points { get; set; }

        public ClosedCurves(PointF[] points)
        {
            Points = points;
        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            List<PointF> points = new List<PointF> { pt };
            foreach (var p in Points)
            {
                points.Add(p);
            }
            gr.DrawClosedCurve(pen, points.ToArray());
            gr.FillClosedCurve(brush, points.ToArray());
        }
    }
}
