namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class TimeChartArea : ChartArea
    {
        public TimeChartArea(ChartArea owner):base(owner)
        {
        }
        public double PixelPerSecond => Width * 1.0 / 3600;

        public int StartHour { get; set; } 
    }

    


}
