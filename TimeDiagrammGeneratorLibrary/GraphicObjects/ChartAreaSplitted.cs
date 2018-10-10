namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class ChartAreaSplitted : ChartArea
    {
        public ChartAreaSplitted(ChartArea chartArea) : base(chartArea)
        {
        }

        public int StringCount { get; private set; } = 0;

        public ChartArea CreateString(int stringHeight)
        {
            var stringArea = new StringArea(this, StringCount++, stringHeight);
            return stringArea;
        }

        class StringArea : ChartArea
        {
            public StringArea(ChartAreaSplitted owner, int num, int height):base(owner) 
            {
                Num = num;
                Height = height;
            }
            public int Num { get; private set; }

            public override int Height { get; }

            public override int Top => Bottom - Height;

            public override int Bottom => Owner.Bottom-Height * Num;  
        }
        
    }
    

}
