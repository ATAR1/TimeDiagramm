using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BarStack
    {
        Dictionary<string, BarWithCaption> _dict = new Dictionary<string, BarWithCaption>();
        private Bar _last;

        public BarWithCaption this[string name] =>_dict[name];

        public BarWithCaption[] ToArray()
        {
            return _dict.Values.ToArray();
        }        

        public void AddBar(string name, ChartArea owner,IScale scale,IEnumerable<string> categories)
        {
            var newBar = new BarWithCaption(owner, scale, _last) { ColorNum = _dict.Count };            
            foreach (string sectionName in categories)
            {
                newBar.AddSection(sectionName);
            }
            _dict.Add(name,newBar);
            _last = newBar;
        }
        
    }
}
