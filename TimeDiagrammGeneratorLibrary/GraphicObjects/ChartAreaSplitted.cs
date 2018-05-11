namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class ChartAreaSplitted : ChartArea
    {
        public ChartAreaSplitted(ChartArea chartArea) : base(chartArea)
        {
        }

        public int StringCount { get; private set; } = 0;

        public ChartArea CreateString()
        {
            var stringArea = new StringArea(this, StringCount++);
            return stringArea;
        }

        class StringArea : ChartArea
        {
            public StringArea(ChartAreaSplitted owner, int num):base(owner) 
            {
                Num = num;
            }
            public int Num { get; private set; }

            public override int Height => Owner.Height / ((ChartAreaSplitted)Owner).StringCount;

            public override int Top => Bottom - Height;

            public override int Bottom => Owner.Bottom-Height * Num;  
        }
        
    }
    

}
