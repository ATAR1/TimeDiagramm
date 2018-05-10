using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary
{
    public class TimeDiagramGenerator
    {
        const int width = 1000;
        const int height = 1000;
        private const int margin = 50;
        
        private static int stringHeight;
        private const int stringWeight = width - 2 * margin;
        private const double pixelsPerSecond = stringWeight / 3600.0;
        private const int inHourIntervalCount = 12;
        private const int fontSize = 10;
        
        static Color backGroundColor = Color.FromArgb(245, 245, 245);

        private static Color[] diagramColors = new Color[]
        {
            Color.Green,
            Color.Orange,            
            Color.Violet,
            Color.Red,
            Color.Yellow
        };
        private SplittedGanttChartModel _model;

        public TimeDiagramGenerator(SplittedGanttChartModel model)
        {
            _model = model;
            stringHeight = (height - 2 * margin) / model.ChartStrings.Count();
        }

        public Bitmap GenerateDiagramm()
        {
            var bitmap = new Bitmap(width, height);
            var canva = Graphics.FromImage(bitmap);

            canva.FillRectangle(new SolidBrush(backGroundColor), new Rectangle(0, 0, width, width));
            DrawAxis(canva);
            foreach (var chartString in _model.ChartStrings)
            {
                foreach (var graph in chartString.Graphs)
                {
                    foreach (var interval in graph.Intervals)
                        DrawInterval(canva, interval, graph.Num, chartString);
                }
            }
            return bitmap;
        }


        

        private static void DrawInterval(Graphics gr, Interval interval,int graphNum, ChartString chartString)
        {
            var stringY = height - margin - (chartString.Num * stringHeight);
            var lineY = stringY - (graphNum+1) * stringHeight / (chartString.Graphs.Count + 1);            
            var lineStart = pixelsPerSecond * chartString.GetStartCoord(interval) + margin;
            var lineStop = pixelsPerSecond * chartString.GetEndCoord(interval) + margin;
            var pen = new Pen(diagramColors[graphNum], 5);
            if(interval.Level==0) pen = new Pen(Color.Red, 5);
            gr.DrawLine(pen, Convert.ToInt32(lineStart), lineY, Convert.ToInt32(lineStop), lineY);
        }
        

        private void DrawAxis(Graphics gr)
        { 
            var pen = new Pen(Color.Black, 2);
            var pen2 = new Pen(Color.Black, 1);
            pen2.DashPattern= new float[]{ 5, 10};

            gr.DrawLine(pen, margin, margin, margin, height - margin);
            var font = new Font(FontFamily.GenericSansSerif, fontSize);
            for (int i = 0; i <= inHourIntervalCount; i++)
            {
                var x = margin + (i * stringWeight / inHourIntervalCount);
                const int y = height - margin;
                gr.DrawLine(pen, x, y, x, y + 5);
                gr.DrawLine(pen2, x, y, x, margin);
                gr.DrawString((i * 60/inHourIntervalCount).ToString() + " мин.", font, Brushes.Black, x, y + font.Height);
            }

            foreach (var chartString in _model.ChartStrings)
            {
                var y = height - margin - (chartString.Num * stringHeight);
                gr.DrawLine(pen, margin, y, width - margin, y);
                var captionY = chartString.StartTime.Hour.ToString() + " час.";
                var stringSize = gr.MeasureString(captionY, font);
                gr.DrawString(captionY, font, Brushes.Black, margin - stringSize.Width, y - font.Height/2);
            }
        }
        
    }
}
