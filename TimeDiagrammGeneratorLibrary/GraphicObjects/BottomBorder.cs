using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BottomBorder : VisibleChartObject
    {

        public BottomBorder(ChartArea owner)
        {
            this.Owner = owner;
        }

        public Pen Pen { get; set; } = new Pen(Color.Black, 2);

        public override void Draw(Graphics gr)
        {
            gr.DrawLine(this.Pen, Owner.Left, Owner.Bottom, Owner.Left + Owner.Width, Owner.Bottom);
        }

    }
}
