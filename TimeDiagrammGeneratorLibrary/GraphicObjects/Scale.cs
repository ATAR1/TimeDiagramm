using System;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Scale : IScale
    {
        private int _width;

        public Scale(int size, int width)
        {
            if (size <= 0) throw new ArgumentException("Размер должен быть больше ноля", nameof(size));
            Size = size;
            _width = width;
        }
        public int Size { get; private set; }

        public int DotsPerDivision => _width / Size;
    }
}