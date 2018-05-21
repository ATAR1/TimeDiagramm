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
        //public TimeSpan TimeBegin { get { return DateBegin.TimeOfDay; } set { DateBegin += value; } } 
        public DateTime DateEnd { get; set; } = DateTime.Today;
        //public TimeSpan TimeEnd { get { return DateEnd.TimeOfDay; } set { DateEnd += value; } }

        public void Execute(object parameter)
        {
            var ctx = new IntervalsDBTypesLibrary.IntervalsDBModelContainer();
            var list = ctx.Intervals.Where(i => i.Object == "МДТ 6").ToList();
            var list2 = ctx.Intervals.Where(i => i.Object == "Сканер").ToList();
            var list3 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.МДТ 6").ToList();
            var dateTimeBegin = DateBegin ;
            var dateTimeEnd = DateEnd;
            var diagrams = new SplittedGanttChartModel(dateTimeBegin, dateTimeEnd);
            diagrams.AddGraph("МДТ 6", list.Select(i => new IntervalDefectoscope() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime, Speed = 211, EstimatedSpeed = 60 }).ToArray());
            diagrams.AddGraph("Сканер", list2.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());
            diagrams.AddGraph("УНСК.ТО1.МДТ 6", list3.Select(i => new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime }).ToArray());

            //var diagramm = new TimeDiagramGenerator(new SplittedGanttChartModel(diagrams)).GenerateDiagramm();
            var diagramm = new GanttChartGenerator(diagrams).Draw();
            MemoryStream ms = new MemoryStream();
            diagramm.Save(ms, ImageFormat.Bmp);
            vM.Diagramm = ms;

            MemoryStream ms1 = new MemoryStream();
            diagramm = new BarChartGenerator(diagrams).Draw();
            diagramm.Save(ms1, ImageFormat.Bmp);
            vM.Diagramm2 = ms1;

            MemoryStream ms2 = new MemoryStream();
            diagramm = new HistogramGenerator(diagrams).Draw();
            diagramm.Save(ms2, ImageFormat.Bmp);
            vM.Diagramm3 = ms2;
        }
    }
}