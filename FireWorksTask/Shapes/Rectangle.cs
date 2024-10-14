using FireWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Shapes
{
    public class Rectangle: IShape
    {
        private float _Width;
        private float _Height;

        public Rectangle(float width, float height)
        {
            
            _Width = width;
            _Height = height;
        }

        public void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            RectangleF rect = new RectangleF(pt.X, pt.Y, _Width, _Height);
            gr.FillRectangle(brush, rect);
            gr.DrawRectangle(pen, pt.X, pt.Y, _Width, _Height);
        }
    }
}
