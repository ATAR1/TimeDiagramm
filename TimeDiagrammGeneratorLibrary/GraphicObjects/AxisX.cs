using System.Collections;
using System.Collections.Generic;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class AxisX
    {
        private Chart _chart;

        public AxisX(Chart _chart, int maxValue)
        {
            this._chart = _chart;
            MaxValue = maxValue;
        }

        public int Left => _chart.Margin;
        public int MaxValue { get; private set; }
        public int Right => _chart.Width - _chart.Margin;
        public int Bottom => _chart.Height - _chart.Margin;
        public int PixelsPerDegree => (Right - Left) / MaxValue;

        public IEnumerable<AxisXMark> SplitAxis(int count)
        {
            return MarksOfAxis.SplitAxis(this, count);
        }

        class MarksOfAxis : IEnumerable<AxisXMark>
        {
            AxisXMark[] _items;

            private MarksOfAxis() { }

            public static MarksOfAxis SplitAxis(AxisX axis, int count)
            {
                MarksOfAxis result = new MarksOfAxis();
                result._items = new AxisXMark[count];
                for (int i = 0; i < count; i++)
                {
                    result._items[i] = new AxisXMark(axis, i * (axis.MaxValue / count));
                }
                return result;
            }

            public IEnumerator<AxisXMark> GetEnumerator()
            {
                return ((IEnumerable<AxisXMark>)_items).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

    }
}