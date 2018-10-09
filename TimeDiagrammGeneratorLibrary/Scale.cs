namespace TimeDiagrammGeneratorLibrary
{
    public class Scale : IScale
    {
        private float _width;

        public Scale(int size, float width)
        {
            Size = size;
            _width = width;
        }
        public int Size { get; set; }

        public float DotsPerDivision => _width / Size;
    }
}