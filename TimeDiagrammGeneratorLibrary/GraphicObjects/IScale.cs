namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public interface IScale
    {
        int Size { get; }
        int DotsPerDivision { get; }
        int MaxValue { get; }
        int MinValue { get; }
    }
}