using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class SectionsStack
    {
        private BarSection _last;
        Dictionary<string, BarSection> _sections = new Dictionary<string, BarSection>();

        public BarSection this[string name] =>_sections[name];
        public BarSection Add(string name, Bar bar)
        {
            var newSection = new BarSection(bar, _last, _sections.Count, bar.ColorNum);
            _sections.Add(name,newSection);
            _last = newSection;
            return newSection;
        }

        public BarSection[] ToArray()
        {
            return _sections.Values.ToArray();
        }
    }
}