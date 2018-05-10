using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class SeparatorX : VisibleChartObject
    {
        public SeparatorX(ChartArea owner)
        {
            Owner = owner;
        }
        
        public Pen Pen { get; set; } = new Pen(Color.Black, 2);

        public override void Draw(Graphics gr)
        {
            gr.DrawLine(this.Pen, Owner.Left, Owner.Top, Owner.Left, Owner.Bottom);
        }

    }
}
