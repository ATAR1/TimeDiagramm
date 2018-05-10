using System.Collections.Generic;
using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Chart : ChartArea
    {
        private int _height;
        private int _width;
        private ChartArea _innerArea;

        public Chart(int height, int width, int margin):base(null) 
        {
            _height = height;
            _width = width;
            Margin = margin;
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
            AddChild(element);
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

        protected void AddChild(VisibleChartObject child)
        {
            _children.Add(child);
        }

        public int Margin { get; private set; }
        public override int Left => 0;
        public override int Bottom => _height;

        public override int Top => 0;
        public override int Height => _height;

        public override int Width => _width;

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
