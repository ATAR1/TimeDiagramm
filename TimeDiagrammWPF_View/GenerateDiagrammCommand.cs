using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Input;
using TimeDiagrammGeneratorLibrary;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammWPF_View
{
    internal class GenerateDiagrammCommand : ICommand
    {
        private VM vM;

        public GenerateDiagrammCommand(VM vM)
        {
            this.vM = vM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public DateTime DateBegin { get; set; } = DateTime.Today;
        public DateTime DateEnd { get; set; } = DateTime.Today;

        public bool TO1Diagramm { get; set; } = true;

        public void Execute(object parameter)
        {
            var ctx = new IntervalsDBTypesLibrary.IntervalsDBModelContainer();
            var list = ctx.Intervals.Where(i => i.Object == "МДТ 6"||i.Object == "МДТ 6.1").ToList();
            var list2 = ctx.Intervals.Where(i => i.Object == "Сканер ТО1").ToList();
            var list3 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.МДТ 6"|| i.Object == "УНСК.ТО1.МДТ 6.1").ToList();
            var list4 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.Сканер").ToList();
            var list5 = ctx.Intervals.Where(i => i.Object == "МДТ 6.2").ToList();
            var list6 = ctx.Intervals.Where(i => i.Object == "Сканер ТО2").ToList();
            var list7 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО2.МДТ 6.2").ToList();
            var list8 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО2.Сканер").ToList();
            var dateTimeBegin = DateBegin ;
            var dateTimeEnd = DateEnd;
            var diagrams = new SplittedGanttChartModel(dateTimeBegin, dateTimeEnd);
            if (TO1Diagramm)
            {
                diagrams.AddGraph("МДТ 6", list.Select(i => new IntervalDefectoscope() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime, Speed = 211, EstimatedSpeed = 60 }).ToArray());
                diagrams.AddGraph("Сканер ТО1", list2.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
                diagrams.AddGraph("УНСК.ТО1.МДТ 6", list3.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
                diagrams.AddGraph("УНСК.ТО1.Сканер", list4.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
            }
            else
            {
                diagrams.AddGraph("МДТ 6.2", list5.Select(i => new IntervalDefectoscope() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime, Speed = 211, EstimatedSpeed = 60 }).ToArray());
                diagrams.AddGraph("Сканер ТО2", list6.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
                diagrams.AddGraph("УНСК.ТО2.МДТ 6.2", list7.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
                diagrams.AddGraph("УНСК.ТО2.Сканер", list8.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
            }
            var diagramm = new GanttChartGenerator(diagrams).Draw();
            MemoryStream ms = new MemoryStream();
            diagramm.Save(ms, ImageFormat.Bmp);
            vM.Diagramm = ms;
            vM.Bitmap1 = diagramm;

            MemoryStream ms1 = new MemoryStream();
            diagramm = new BarChartGenerator(diagrams).Draw();
            diagramm.Save(ms1, ImageFormat.Bmp);
            vM.Diagramm2 = ms1;
            vM.Bitmap2 = diagramm;

            MemoryStream ms2 = new MemoryStream();
            diagramm = new HistogramGenerator(diagrams).Draw();
            diagramm.Save(ms2, ImageFormat.Bmp);
            vM.Diagramm3 = ms2;
            vM.Bitmap3 = diagramm;
        }
    }
}