using System.Drawing;
using System.Drawing.Drawing2D;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class IntervalG : VisibleChartObject
    {
        public IntervalG(TimeChartArea owner, Color color, int startX, int stopX, int graphNum, int level)
        {
            Owner = owner;
            _startTime = startX;
            _stopTime = stopX;
            _graphNum = graphNum;
            _color = color;
            Level = level;
        }

        public int Y => Owner.Bottom - Owner.Height / (Owner.GraphCount + 1) * (_graphNum + 1);

        private int StartX => Owner.Left + (int)(((TimeChartArea)Owner).PixelPerSecond * _startTime);

        private int EndX => Owner.Left + (int)(((TimeChartArea)Owner).PixelPerSecond * _stopTime);

        public int BrickHeight {get;set;}= 10;

        public int Level { get; private set; }

        public Pen BorderPen { get; set; } = new Pen(Color.Black);

        private int _graphNum;
        private int _startTime;
        private int _stopTime;
        private Color _color;

        Brush[] _brushes => new Brush[]
                                {
                                    new SolidBrush(_color),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, _color),
                                };


        public override void Draw(Graphics gr)
        {
            var brickLength = EndX - StartX;
            gr.FillRectangle(_brushes[Level], StartX, Y, brickLength, BrickHeight);            
            gr.DrawRectangle(BorderPen, StartX, Y, brickLength, BrickHeight);            
        }


    }


}
