namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class GraphParameters
    {
        public GraphParameters(int graphNum)
        {
            GraphNum = graphNum;
        }

        public int BarHeight { get; set; } = 10;
        public int BarMargin { get; internal set; } = 5;
        public int GraphNum { get; private set; }
    }
}