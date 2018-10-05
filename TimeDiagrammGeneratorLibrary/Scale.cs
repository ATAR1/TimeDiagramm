namespace TimeDiagrammGeneratorLibrary
{
    public class Scale : IScale
    {
        public Scale(int maxValue, int valueOfDvision)
        {
            MaxValue = maxValue;
            ValueOfDivision = valueOfDvision;
        }
        public int MaxValue { get;  }

        public int ValueOfDivision { get; }
    }
}