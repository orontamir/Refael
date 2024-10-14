using FireWorks.Models;
using FireWorks.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RafaelInterview
{
	public partial class MainForm : Form
	{
        readonly ShapeService _ShapeService;
        public MainForm()
		{
			InitializeComponent();
			this.CreateGraphics().Clear(Color.White);
			this.CreateGraphics().SmoothingMode = SmoothingMode.AntiAlias;
			//TODO Oron - Read all shapes that you want to drow from appsettings
            _ShapeService = new ShapeService();
            Task.Factory.StartNew(() => Simulation());

        }

		private async Task Simulation()
		{
			while (true)
			{
				try
				{
					var random = new Random();
					float x = random.Next(50, 500);
					float y = random.Next(50, 300);
					PointF point = new PointF(x, y);
					await Task.Factory.StartNew(() => NewTarget(point));
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception when running simulation, Error message {ex.Message}");
				}
				finally 
				{
					await Task.Delay(2000);
				}
			}
		}

		private async void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			PointF newP = new PointF(e.X, e.Y);
			await Task.Factory.StartNew(() => NewTarget(newP));
		}

		private async Task NewTarget(PointF newP)
		{
			try
			{

                var random = new Random();
                //Random Shape
                ShapeEnum randomShape = GetRandomEnumValue<ShapeEnum>();
                
				//Random Brush
                Brush brush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
				//Random Pen
                Pen pen = new Pen(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)), 2);
				var graphics = CreateGraphics();
				//Invoke the random enm shape
			    var response = await _ShapeService.InvokeSetting(randomShape.ToString(), graphics, newP, brush, pen);
				if (!response)
				{
					Console.WriteLine($"Failed in new target");
				}

            }
			catch(Exception ex) 
			{ 
				Console.WriteLine($"Exception when try to drow new shape , Error message: {ex.Message}");
			}
		}

        public static T GetRandomEnumValue<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            return (T)values.GetValue(random.Next(values.Length));
        }

        private void Clear_Click(object sender, EventArgs e)
		{
			//Clear all shapes from win form
            this.CreateGraphics().Clear(Color.White);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
