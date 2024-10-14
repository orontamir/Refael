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
                float width = random.Next(10, 100);
                float height = random.Next(10, 100);
                float startAngle = random.Next(10, 100);
                float seepAngle = random.Next(10, 100);
                for (int i = 10; i< width; i++)
                {
                    Arc arc = new Arc(i, height + i, startAngle, seepAngle);
                    arc.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
               
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
                var point1 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point2 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point3 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                for (float i = pt.X; i < Math.Abs(pt.X + point3.X); i++)
                {
                    PointF point4 = new PointF(i, point3.Y);
                    Bezier bezier = new Bezier(point1, point2, point4);
                    bezier.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
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
                var radius = random.Next(10, 100);
                for (int i=10; i< radius; i++)
                {
                    Circle circle = new Circle(i);
                    circle.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
               
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
                var point1 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point2 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point3 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                for (float i = pt.X; i < Math.Abs(pt.X + point3.X); i++)
                {
                    PointF point4 = new PointF(i, point3.Y);
                    var pointArray = new List<PointF> { point1, point2, point4 }.ToArray();
                    ClosedCurves closedCurves = new ClosedCurves(pointArray);
                    closedCurves.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
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
                float width = random.Next(10, 100);
                float height = random.Next(10, 100);
                for (int i= 10; i< height; i++)
                {
                    Ellipse ellipse = new Ellipse(width + i, i);
                    ellipse.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
                
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
                float width = random.Next(10, 100);
                float height = random.Next(10, 100);
                float startAngle = random.Next(10, 100);
                float seepAngle = random.Next(10, 100);
                for (int i = 10; i < width; i++)
                {
                    Pie pie = new Pie(i, height + i, startAngle, seepAngle);
                    pie.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
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
                var point1 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point2 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point3 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                for (float i = pt.X; i < Math.Abs(pt.X + point3.X); i++)
                {
                    PointF point4 = new PointF(i, point3.Y);
                    var pointArray = new List<PointF> { point1, point2, point4 }.ToArray();
                    Polygon polygon = new Polygon(pointArray);
                    polygon.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
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
                var point1 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point2 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                var point3 = new PointF(random.Next(10, (int)pt.X + 50), random.Next(10, (int)pt.Y + 50));
                for (float i = pt.X; i < Math.Abs(pt.X + point3.X); i++)
                {
                    PointF point4 = new PointF(i, point3.Y);
                    var pointArray = new List<PointF> { point1, point2, point4 }.ToArray();
                    Polyline polyline = new Polyline(pointArray);
                    polyline.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
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
                float width = random.Next(10, 100);
                float height = random.Next(10, 100);
                for (int i = 10; i < width; i++)
                {
                    Shapes.Rectangle rectangle = new Shapes.Rectangle(i, height+ i);
                    rectangle.DrawPoint(gr, pt, brush, pen);
                    await Task.Delay(200);
                }
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
