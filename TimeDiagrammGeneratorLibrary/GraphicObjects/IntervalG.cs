using System.Drawing;
using System.Drawing.Drawing2D;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class IntervalG : VisibleChartObject
    {
        public IntervalG(GanttChartArea owner, Color color, int startX, int stopX, int graphNum)
        {
            Owner = owner;
            _startTime = startX;
            _stopTime = stopX;
            _graphNum = graphNum;
            _color = color;
        }

        private Pen pen => new Pen(_color);

        public int Y => Owner.Bottom - Owner.Height / (Owner.GraphCount + 1) * (_graphNum + 1);

        private int StartX => Owner.Left + (int)(((GanttChartArea)Owner).PixelPerSecond * _startTime);

        private int EndX => Owner.Left + (int)(((GanttChartArea)Owner).PixelPerSecond * _stopTime);

        public int BrickHeight {get;set;}= 10;
        public int Level { get; set; }

        private int _graphNum;
        private int _startTime;
        private int _stopTime;
        private Color _color;

        Brush[] _brushes => new Brush[]
                                {
                                    new SolidBrush(_color),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, _color)
                                };

        public int Level { get; set; }

        public override void Draw(Graphics gr)
        {
            //gr.DrawLine(pen, StartX, Y, EndX, Y );
            //gr.FillRectangle(new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, _color), StartX, Y, EndX - StartX, 5);
            gr.FillRectangle(_brushes[Level], StartX, Y, EndX - StartX, 10);
            gr.DrawRectangle(new Pen(Color.Black), StartX, Y, EndX-StartX, 10);            
        }


    }


}
