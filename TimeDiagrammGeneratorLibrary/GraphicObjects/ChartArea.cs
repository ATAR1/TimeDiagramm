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
        public virtual int Bottom => Owner.Bottom;
        public virtual int Top => Owner.Top;
        public virtual int Left => Owner.Left;

        public virtual int Height => Owner.Height;

        public virtual int Width => Owner.Width;

        public int GraphCount { get; set; }
        
    }

    
}
