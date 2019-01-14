using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public abstract class ChartArea : ChartObject
    {        
        public ChartArea(ChartArea owner)
        {
            Owner = owner;
        }
        public virtual int Bottom
        {
            get { return Owner.Bottom; }
            set { Owner.Bottom = value; }
        }
        public virtual int Top
        {
            get { return Owner.Top; }
            set { Owner.Top = value; }
        }
        public virtual int Left
        {
            get { return Owner.Left; }
            set { Owner.Left = value; }
        }
        public virtual int Right
        {
            get { return Owner.Right; }
            set { Owner.Right = value; }
        }
        public virtual int Height
        {
            get { return Owner.Height; }
            set { Owner.Height = value; }
        }
        public virtual int Width
        {
            get { return Owner.Width; }
            set { Owner.Width = value; }
        }
        public int GraphCount { get; set; }

        protected static ChartArea Empty => new EmptyChartArea();

        class EmptyChartArea : ChartArea
        {
            public EmptyChartArea() : base(null)
            {
            }
            public override int Bottom
            {
                get;
                set;
            }
            public override int Top
            {
                get ;
                set;
            }
            public override int Left
            {
                get ;
                set;
            }
            public override int Right
            {
                get ;
                set;
            }
            public override int Height
            {
                get ;
                set;
            }
            public override int Width
            {
                get;
                set;
            }
        }
    }

    

}
