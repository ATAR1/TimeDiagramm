using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Brick 
    {
        public Brick(Pen borderPen, Brush brush, float x, float y, float length, float height)
        {
            BorderPen = borderPen;
            Brush = brush;
            X = x;
            Y = y;
            Length = length;
            Height = height; 
        }
        public Pen BorderPen { get; private set; }
        public Brush Brush { get; private set; }
        public float Height { get; private set; }
        public float Length { get; private set; }
        public float X { get; private set; }
        public float Y { get; private set; }

        public void Draw(Graphics gr)
        {
            gr.FillRectangle(Brush, X, Y, Length, Height);
            gr.DrawRectangle(BorderPen, X, Y, Length, Height);
        }
    }
}
