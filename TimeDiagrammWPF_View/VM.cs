using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TimeDiagrammGeneratorLibrary;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammWPF_View
{
    internal class VM
    {
        public VM()
        {
            var ctx = new IntervalsDBTypesLibrary.IntervalsDBModelContainer();
            var list = ctx.Intervals.Where(i=>i.Object=="МДТ 6").ToList();
            var list2 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.АУЗККТ").ToList();
            var list3 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.МДТ 6").ToList();
            var diagrams = new SplittedGanttChartModel(new DateTime(2018, 3, 6, 20, 0, 0), new DateTime(2018, 3, 7, 8, 0, 0));
            diagrams.AddGraph("МДТ 6", list.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
            diagrams.AddGraph("УНСК.ТО1.АУЗККТ", list2.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
            diagrams.AddGraph("УНСК.ТО1.МДТ 6", list3.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());

            //var diagramm = new TimeDiagramGenerator(new SplittedGanttChartModel(diagrams)).GenerateDiagramm();
            var diagramm = new GanttChartGenerator(diagrams).Draw();            
            MemoryStream ms = new MemoryStream();
            diagramm.Save(ms, ImageFormat.Bmp);
            Diagramm = ms;

            MemoryStream ms1 = new MemoryStream();
            diagramm = new BarChartGenerator(diagrams).Draw();
            diagramm.Save(ms1, ImageFormat.Bmp);
            Diagramm2 = ms1;

            MemoryStream ms2 = new MemoryStream();
            diagramm = new HistogramGenerator(diagrams).Draw();
            diagramm.Save(ms2, ImageFormat.Bmp);
            Diagramm3 = ms2;
        }
        public Stream Diagramm { get; set; }

        public Stream Diagramm2 { get; set; }

        public Stream Diagramm3 { get; set; }
    }
}