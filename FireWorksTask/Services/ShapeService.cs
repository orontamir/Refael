using FireWorks.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FireWorks.Services
{
    public class ShapeService
    {
        public ShapeService() { }

        public async Task<bool> InvokeSetting(string functionName, params object[] parameters)
        {
            MethodInfo method = typeof(ShapeService).GetMethod(functionName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (method == null)
            {
                throw new ArgumentException($"Function '{functionName}' not found in {nameof(ShapeService)}");
            }

            try
            {
                return await (Task<bool>)method.Invoke(this, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to invoke function '{functionName}': {ex.Message}");
            }
        }

        public async Task<bool> Arc(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                float width = random.Next(50, 200);
                float height = random.Next(50, 200);
                float startAngle = random.Next(50, 200);
                float seepAngle = random.Next(50, 200);
                Arc arc = new Arc(width, height, startAngle, seepAngle);
                arc.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Exception when drow Arc, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Bezier(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                var point1 = new PointF(random.Next(10, 100), random.Next(10, 100));
                var point2 = new PointF(random.Next(10, 100), random.Next(10, 100));
                var point3 = new PointF(random.Next(10, 100), random.Next(10, 100));
                Bezier bezier = new Bezier(point1, point2, point3);
                bezier.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Bezier, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Circle(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                var radius = random.Next(10, 250);

                Circle circle = new Circle(radius);
                circle.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Circle, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ClosedCurves(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                var point1 = new PointF(random.Next(10, 150), random.Next(50, 200));
                var point2 = new PointF(random.Next(10, 150), random.Next(50, 200));
                var point3 = new PointF(random.Next(10, 150), random.Next(50, 200));
                var pointArray = new List<PointF> { point1, point2, point3 }.ToArray();
                ClosedCurves closedCurves = new ClosedCurves(pointArray);
                closedCurves.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Closed Curves, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Ellipse(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                float width = random.Next(50, 300);
                float height = random.Next(50, 300);
                Ellipse ellipse = new Ellipse(width, height);
                ellipse.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Ellipse, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Pie(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                float width = random.Next(10, 200);
                float height = random.Next(10, 200);
                float startAngle = random.Next(10, 200);
                float seepAngle = random.Next(10, 200);
                Pie pie = new Pie(width, height, startAngle, seepAngle);
                pie.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Ellipse, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Polygon(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                var point1 = new PointF(random.Next(10, 200), random.Next(10, 200));
                var point2 = new PointF(random.Next(10, 200), random.Next(10, 200));
                var point3 = new PointF(random.Next(10, 200), random.Next(10, 200));
                var pointArray = new List<PointF> { point1, point2, point3 }.ToArray();
                Polygon polygon = new Polygon(pointArray);
                polygon.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Polygon, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Polyline(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                var point1 = new PointF(random.Next(50, 200), random.Next(50, 200));
                var point2 = new PointF(random.Next(50, 200), random.Next(50, 200));
                var point3 = new PointF(random.Next(50, 200), random.Next(50, 200));
                var pointArray = new List<PointF> { point1, point2, point3 }.ToArray();
                Polyline polyline = new Polyline(pointArray);
                polyline.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Polygon, Error message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Rectangle(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            try
            {
                var random = new Random();
                float width = random.Next(50, 200);
                float height = random.Next(50, 200);
                Shapes.Rectangle rectangle = new Shapes.Rectangle(width, height);
                rectangle.DrawPoint(gr, pt, brush, pen);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when drow Polygon, Error message: {ex.Message}");
                return false;
            }
        }



    }
}
