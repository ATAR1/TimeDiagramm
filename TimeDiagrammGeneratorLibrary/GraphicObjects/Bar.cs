using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Bar : VisibleChartObject
    {
        BarSection[] _sections;

        public Bar(ChartArea owner, IScale scale, Bar previousBar, BarSectionData[] model)
        {
            Owner = owner;
            Scale = scale;
            _previousBar = previousBar;
            GenerateSections(model);
        }

        private void GenerateSections(BarSectionData[] model)
        {
            _sections = new BarSection[model.Count()];
            BarSection previous = null;
            int i = 0;
            foreach (var item in model)
            {
                var section = new BarSection(this, item, previous);
                previous = section;
                _sections[i++] = section;
            }
        }

        public IScale Scale { get; set; }

        public int Bottom => _previousBar == null ? Owner.Bottom : _previousBar.Top;

        Bar _previousBar;

        public virtual int Top => Bottom - Height;

        public int BarHeight { get; set; } = 10;

        public int Left => Owner.Left;

        public virtual int Right => Left + Length;

        public virtual int Length => _sections.Sum(s => s.Length) + Margin;

        public int Margin { get; set; } = 5;
        /// <summary>
        /// Номер диаграммы
        /// </summary>
        public int GraphNum => _previousBar == null ? 0 : _previousBar.GraphNum+1;

        public virtual int Height => BarHeight + Margin * 2 ;               

        public override void Draw(Graphics gr)
        {
            foreach (var section in _sections)
            {
                section.Draw(gr);
            }            
        }
        
    }
     
}
