using System;
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
            Sections = new SectionsStack();
        }

        public BarSection AddSection(string name)
        {
            return Sections.Add(name,this);            
        }

        public SectionsStack Sections { get; }


        

        public IScale Scale { get; set; }

        public int Bottom => _previousBar == null ? Owner.Bottom : _previousBar.Top;

        Bar _previousBar;

        public virtual int Top => Bottom - Height;

        public int BarHeight { get; set; } = 10;

        public int Left => Owner.Left;

        public virtual int Right => Left + Length;

        public virtual int Length => Sections.ToArray().Sum(s => s.Length) + Margin;

        public int Margin { get; set; } = 5;
        

        /// <summary>
        /// Номер диаграммы
        /// </summary>
        public int GraphNum => _previousBar == null ? 0 : _previousBar.GraphNum+1;

        public virtual int Height => BarHeight + Margin * 2 ;

        public int ColorNum { get; set; }

        public override void Draw(Graphics gr)
        {
            foreach (var section in Sections.ToArray())
            {
                section.Draw(gr);
            }            
        }
        
    }
     
}
