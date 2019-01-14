using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Bar : VisibleChartObject
    {


        public Bar(ChartArea owner, IScale scale, Bar previousBar)
        {
            Owner = owner;
            Scale = scale;
            _previousBar = previousBar;
        }

        public IScale Scale { get; set; }

        public int Bottom => _previousBar == null ? Owner.Bottom : _previousBar.Top;

        Bar _previousBar;

        public virtual int Top => Bottom - Height;

        public int BarHeight { get; set; } = 10;

        public int Left => Owner.Left;

        public virtual int Right => Left + (int)Sections.Sum(s => s.Value) * Scale.DotsPerDivision;

        public int Margin { get; set; } = 5;
        /// <summary>
        /// Номер диаграммы
        /// </summary>
        public int GraphNum { get; set; }

        private Color Color => _colors[GraphNum];

        Brush[] Brushes => new Brush[]
                                {
                                    new SolidBrush(Color),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, Color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, Color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, Color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, Color),
                                };

        public virtual int Height => BarHeight + Margin * 2 ;

        public BarSectionData[] Sections { get; set; }
        

        Color[] _colors = new[]
        {
            Color.Green,
            Color.Blue,
            Color.LightGreen,
            Color.LightBlue
        };
        

        public override void Draw(Graphics gr)
        {
            float sectionLeft = Left;
            float barTop = Bottom - BarHeight - Margin;
            for (int i = 0; i < Sections.Length; i++)
            {
                var sectionLength = Sections[i].Value * Scale.DotsPerDivision;                
                gr.FillRectangle(Brushes[i], sectionLeft, barTop, sectionLength, BarHeight);
                gr.DrawRectangle(new Pen(Color.Black), sectionLeft, barTop, sectionLength, BarHeight);
                sectionLeft += sectionLength;
            }
        }
    }
     
}
