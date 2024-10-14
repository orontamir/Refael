using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class Ellipse : IShape
    {
        private float _Width;
        private float _Height;

        public Ellipse(float width, float height)
        {

            _Width = width;
            _Height = height;
        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            gr.DrawEllipse(pen, pt.X, pt.Y, _Width, _Height);
            gr.FillEllipse(brush, pt.X, pt.Y, _Width, _Height);

        }
    }
}
