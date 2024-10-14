using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class Polygon: IShape
    {
        public PointF[] Points { get; set; }

        public Polygon(PointF[] points)
        {
            Points = points;
        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            List<PointF> points = new List<PointF>{ pt };
            foreach (var p in Points) 
            {
                points.Add(p);
            }
            gr.FillPolygon(brush, points.ToArray());
            gr.DrawPolygon(pen, points.ToArray());
        }
    }
}
