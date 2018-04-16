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
        private const int stringCount = 12;
        private const int stringHeight = (height - 2* margin)/ stringCount;
        private const int stringWeight = width - 2 * margin;
        private const int inHourIntervalCount = 12;
        private const int fontSize = 10;
        
        private static DateTime startTime;
        static int diagramCount;
        static Color backGroundColor = Color.FromArgb(245, 245, 245);

        private static Color[] diagramColors = new Color[]
        {
            Color.Green,
            Color.Orange,            
            Color.Violet,
            Color.Red,
            Color.Yellow
        };

        public static Bitmap GenerateDiagramm(List<Interval[]> diagrams)
        {
            startTime = new DateTime(2018,3,5,20,0,0); 

            Bitmap canva = new Bitmap(width, height);
            var gr = Graphics.FromImage(canva);
            gr.FillRectangle(new SolidBrush(backGroundColor), new Rectangle(0, 0, width, width));
            DrawAxis(gr);
            diagramCount = diagrams.Count;
            var diagramNum = 0;
            foreach (var intervals in diagrams)
            {
                diagramNum++;
                foreach (var interval in intervals)
                {
                    if (interval.StartTime.Hour != (interval.StartTime + interval.Duration).Hour)
                    {
                        Tuple<Interval, Interval> pair = SplitInterval(interval);
                        DrawInterval(gr, pair.Item1, diagramNum);
                        DrawInterval(gr, pair.Item2, diagramNum);
                    }
                    else
                        DrawInterval(gr, interval, diagramNum);
                }
            }
            return canva;

        }

        private static Tuple<Interval, Interval> SplitInterval(Interval sourceInterval)
        {
            DateTime nxtH = new DateTime(sourceInterval.StartTime.Year, sourceInterval.StartTime.Month, sourceInterval.StartTime.Day, sourceInterval.StartTime.Hour, 0, 0).Add(new TimeSpan(1, 0, 0));
            Interval firstInterval = new Interval()
            {
                StartTime = sourceInterval.StartTime,
                Duration = nxtH.Add(TimeSpan.FromMilliseconds(-1)) - sourceInterval.StartTime,
                Level = sourceInterval.Level
            };
            Interval secondInterval = new Interval()
            {
                StartTime = nxtH,
                Duration = sourceInterval.Duration - firstInterval.Duration,
                Level = sourceInterval.Level
            };

            return new Tuple<Interval, Interval>(firstInterval, secondInterval);
        }

        private static void DrawInterval(Graphics gr, Interval interval,int diagramNum)
        {
            if (interval.StartTime < startTime) return;
            if (interval.StartTime >= startTime.AddHours(stringCount)) return;
            var stringNum = (int)(interval.StartTime-startTime).TotalHours;
            var stringY = height - margin - (stringNum * stringHeight);
            var lineY = stringY - diagramNum * stringHeight / (diagramCount + 1);
            const double pixelsPerSecond = stringWeight / 3600.0;
            var lineStart = pixelsPerSecond * GetTotalSecondsAfterHour(interval.StartTime) + margin;
            var lineStop = pixelsPerSecond * (GetTotalSecondsAfterHour(interval.StartTime) + interval.Duration.TotalSeconds) + margin;
            var pen = new Pen(diagramColors[diagramNum - 1], 5);
            if(interval.Level==0) pen = new Pen(Color.Red, 5);
            gr.DrawLine(pen, Convert.ToInt32(lineStart), lineY, Convert.ToInt32(lineStop), lineY);
        }

        private static int GetTotalSecondsAfterHour(DateTime startTime)
        {
            return startTime.Minute * 60 + startTime.Second;
        }

        private static void DrawAxis(Graphics gr)
        { 
            var pen = new Pen(Color.Blue, 2);
            var pen2 = new Pen(Color.Blue, 1);
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

            for (int i = 0; i < stringCount; i++)
            {
                var y = height - margin - (i * stringHeight);
                gr.DrawLine(pen, margin, y, width - margin, y);

                var captionY = (GetHour(i)).ToString() + " час.";
                var stringSize = gr.MeasureString(captionY, font);
                gr.DrawString(captionY, font, Brushes.Black, margin - stringSize.Width, y - font.Height/2);
            }
        }

        private static int GetHour(int numByOrder)
        {
            return (numByOrder + startTime.Hour)%24;
        }
    }
}
