using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BarWithCaption : Bar
    {
        public BarWithCaption(ChartArea owner, IScale scale, Bar previousBar, BarSectionData[] model) : base(owner, scale, previousBar, model)
        {
            Caption = new Caption();
        }

        public Caption Caption { get; }

        public override int Height => base.Height + Caption.Height;

        public override int Right => base.Right + Caption.Width;


        public override void Draw(Graphics gr)
        {
            base.Draw(gr);
            Caption.Left = base.Right;
            Caption.Bottom = Bottom - base.Height;
            Caption.Draw(gr);
        }
    }
}
