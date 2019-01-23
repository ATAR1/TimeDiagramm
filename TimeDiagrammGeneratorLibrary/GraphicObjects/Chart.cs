using System.Collections.Generic;
using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Chart : ChartArea
    {
        
        private ChartArea _innerArea;

        public Chart():base(Empty) 
        {            
            _innerArea = new ChartInnerArea(this);
        }

        internal void AddElements(IEnumerable<VisibleChartObject> elements)
        {
            foreach (var element in elements)
            {
                AddElement(element);
            }
        }

        internal void AddElement(VisibleChartObject element)
        {
            _children.Add(element);
        }

        public void RemoveElement(VisibleChartObject element)
        {
            _children.Remove(element);
        }


        List<VisibleChartObject> _children = new List<VisibleChartObject>();


        public void Draw(Graphics gr)
        {
            Color backGroundColor = Color.FromArgb(245, 245, 245);
            gr.FillRectangle(new SolidBrush(backGroundColor), new Rectangle(0, 0, Width, Height));
            foreach (var item in _children)
            {
                item.Draw(gr);
            }
        }

        public int Margin { get; set; } = 0;
        public override int Left { get; set; } = 0;
        public override int Bottom => Height;

        public override int Top => 0;
        public override int Height { get; set; }

        public override int Width { get; set; }

        public ChartArea InnerArea => _innerArea;

        public ICollection<AuxiliaryLine> AuxiliaryLinesX { get; internal set; }
        
        private class ChartInnerArea : ChartArea
        {
            public ChartInnerArea(Chart owner) : base(owner)
            {
            }

            public override int Bottom => Owner.Bottom - ((Chart)Owner).Margin;

            public override int Top=> Owner.Top + ((Chart)Owner).Margin;

            public override int Left => Owner.Left + ((Chart)Owner).Margin;

            public override int Width => Owner.Width - ((Chart)Owner).Margin * 2;

            public override int Height => Owner.Height - ((Chart)Owner).Margin * 2;
            
        }
    }
}
