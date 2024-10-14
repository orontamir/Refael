using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class Arc : IShape
    {
        private float _Width;
        private float _Height;
        private float _StartAngle;
        private float _SweepAngle;

        public Arc(float width, float height, float startAngle, float sweepAngle)
        {

            _Width = width;
            _Height = height;
            _StartAngle = startAngle;
            _SweepAngle = sweepAngle;
        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            gr.DrawArc(pen, pt.X, pt.Y, _Width, _Height, _StartAngle, _SweepAngle);
        }
    }
}
