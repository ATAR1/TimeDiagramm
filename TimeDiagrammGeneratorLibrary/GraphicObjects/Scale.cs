using System;
using System.Collections.Generic;

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
            MaxValue = size;
            MinValue = 0;
        }
        public int Size { get; private set; }

        public int DotsPerDivision => _width / Size;

        public int MaxValue{ get; private set; }

        public int MinValue { get; private set; }

        public int[] DivideToEqualSegments(uint count)
        {
            var result = new int[count + 1];
            for (int i = 0; i <= count; i++)
            {
                result[i] = MinValue + i * Size / (int)count;
            }
            return result;
        }

        public int[] DivideIntoSegmentsLengthOf(uint length)
        {
            var segments = new List<int>();
            for (int i = MinValue; i <= MaxValue; i+=(int)length)
            {
                segments.Add(i);
            }
            return segments.ToArray();
        }

        public int[] DivideIntoSegmentsLengthOf(uint length,int startFrom)
        {
            var segments = new List<int>();
            for (int i = startFrom; i <= MaxValue; i += (int)length)
            {
                segments.Add(i);
            }
            return segments.ToArray();
        }



    }
}