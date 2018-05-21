using System.Drawing;
using System.Linq;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class GanttChartGenerator
    {
        private Chart _chart;

        public GanttChartGenerator(SplittedGanttChartModel model)
        {
            _chart = new Chart(1000,1000,50);
            _chart.AddElement(new LeftBorder(_chart.InnerArea));
            var axisX = new AxisX(_chart,60);
            var chartAreaSplitted = new ChartAreaSplitted(_chart.InnerArea);
            var axisX_Marks = axisX.SplitAxis(12);
            var axisX_MarkCaptions = axisX_Marks.Select(m => new AxisXMarkCaption(m) { Text = m.X + " мин." });
            _chart.AddElements(axisX_Marks);
            _chart.AddElements(axisX_MarkCaptions);
            _chart.AddElements(axisX_Marks.Where((e,c)=>c%2==0).Select(m => new AuxiliaryLine(_chart.InnerArea,axisX, m.X)));      
            foreach (var chartString in model.ChartStrings)
            {
                var chartString1 =chartAreaSplitted.CreateString();                
                var gantChartArea = new TimeChartArea(chartString1);
                var captionY = new CaptionY(gantChartArea) { Caption = chartString.StartChartTime.Hour+" час."};
                _chart.AddElement(new BottomBorder(chartString1));
                _chart.AddElement(captionY);
                gantChartArea.GraphCount = model.Graphs.Count;
                gantChartArea.StartHour = chartString.StartChartTime.Hour;
                foreach (var graph in chartString.Graphs)
                {
                    foreach (var interval in graph.Intervals)
                    {
                        Color color = Color.Empty;
                        switch (graph.Name)
                        {
                            case "МДТ 6":
                                color = Color.Green;
                                break;
                            case "Сканер":
                                color = Color.Blue;
                                break;
                            case "УНСК.ТО1.МДТ 6":
                                color = Color.Pink;
                                break;
                            default:
                                break;
                        }
                        _chart.AddElement(new IntervalG(gantChartArea, color, chartString.GetStartCoord(interval), chartString.GetEndCoord(interval), graph.Num) { Level = interval.Level });
                    }
                }
            }
                       
        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(1000, 1000);
            Graphics gr = Graphics.FromImage(bitmap);
            _chart.Draw(gr);
            return bitmap;
        }


    }

    

    
    

    

    

    
    
}
