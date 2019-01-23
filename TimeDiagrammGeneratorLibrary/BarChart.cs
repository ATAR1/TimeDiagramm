using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChart : Chart
    {
        public BarChart(IScale scale) 
        {
            AddElement(new BottomBorder(InnerArea));
            AddElement(new LeftBorder(InnerArea));
            Scale = scale;
            _bars = new BarStack();
            _categories = new List<string>();
        }


        public BarStack Bars => _bars;

        private BarStack _bars;

        private List<string> _categories;

        public IScale Scale { get; set; }
        
        public Bitmap Draw()
        {
            var bitmap = new Bitmap(Width, Height);            
            Graphics gr = Graphics.FromImage(bitmap);
            AddElements(_bars.ToArray());
            Draw(gr);
            return bitmap;
        }

        public void AddBar(string chartName)
        {
            _bars.AddBar(chartName, InnerArea, Scale,_categories);
        }


        public IEnumerable<string> Categories => _categories;


        public void AddCategory(string name)
        {
            foreach (Bar bar in _bars.ToArray())
            {
                bar.AddSection(name);
            }
            _categories.Add(name);
        }

        

        public void SetActualHeight()
        {
            Height = _bars.ToArray().Sum(b=>b.Height)+Margin*2;
        }

        public void SetActualWidth()
        {
            Width = _bars.ToArray().Max(b => b.Right)+Margin;
        }

        public void SetData(string[] graphNames, string[] sectionNames,  int[][] values)
        {
            foreach (var graphName in graphNames)
            {
                AddBar(graphName);
            }
            foreach (var sectionName in sectionNames)
            {
                AddCategory(sectionName);
            }
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values[i].Length; j++)
                {
                    Bars.ToArray()[i].Sections.ToArray()[j].Value = values[i][j];
                }
            }
            
        }
    }
}
