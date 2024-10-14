using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Interfaces
{
    public interface IShape
    {
        void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen);
    }
}
