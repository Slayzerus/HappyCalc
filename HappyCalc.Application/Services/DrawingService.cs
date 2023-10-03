using HappyCalc.Domain.Math;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Drawing.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCalc.Application.Services
{
    public class DrawingService
    {
        public void Test()
        {
            if (File.Exists(@"C:\Temp\test.png"))
            {
                File.Delete(@"C:\Temp\test.png");
            }            

            using (Image image = new Image<Rgba32>(1000, 500))
            {
                image.Mutate(x => x.DrawLine(new Rgba32(255, 0, 0), 1, new PointF[] { new PointF(10, 10), new PointF(100, 100) }));
                image.Save(@"C:\Temp\test.png");
            }
        }

        public void DrawExpression(Expression expression)
        {
            if (File.Exists(@"C:\Temp\test.png"))
            {
                File.Delete(@"C:\Temp\test.png");
            }

            FontCollection fonts = new FontCollection();
            FontFamily family = fonts.Add(@"c:\Temp\RedditSans-Regular.ttf");
            Font font = family.CreateFont(50, FontStyle.Regular);

            RichTextOptions richTextOptions = new RichTextOptions(font)
            {
                Origin = new PointF(100, 100), // Set the rendering origin.
                TabWidth = 8, // A tab renders as 8 spaces wide
                //WrappingLength = 100, // Greater than zero so we will word wrap at 100 pixels wide
                //HorizontalAlignment = HorizontalAlignment.Left // Right align
            };

            SolidBrush brush = Brushes.Solid(Color.Blue);
            //PatternBrush brush = Brushes.Horizontal(Color.Red, Color.Blue);
            SolidPen pen = Pens.Solid(Color.Black, 3); //DashDot(Color.Green, 5);

            using (Image image = new Image<Rgba32>(1000, 500))
            {
                image.Mutate(x => x.DrawText(richTextOptions, expression.Text, brush, pen));
                image.Save(@"C:\Temp\test.png");
            }
        }
    }
}
