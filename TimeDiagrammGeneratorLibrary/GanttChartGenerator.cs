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
            var scale = new Scale(60, _chart.InnerArea.Width);
            var axisX = new AxisX(scale,_chart.InnerArea);
            axisX.Marks = scale.DivideToEqualSegments(12).Select(mv => new AxisXMark(axisX, mv)).ToList();            
            foreach (var mark in axisX.Marks)
            {
                mark.Caption.Text = mark.X + " мин.";
            }
            _chart.AddElements(axisX.Marks);
            var chartAreaSplitted = new ChartAreaSplitted(_chart.InnerArea);
            _chart.AddElements(axisX.Marks.Where((e,c)=>c%2==0).Select(m => new AuxiliaryLine(_chart.InnerArea,scale, m.X)));      
            foreach (var chartString in model.ChartStrings)
            {
                var chartString1 =chartAreaSplitted.CreateString(chartAreaSplitted.Height / model.ChartStrings.Count);                
                var gantChartArea = new TimeChartArea(chartString1);
                var captionY = new CaptionY(gantChartArea) { Caption = chartString.StartChartTime.Hour+" час."};
                _chart.AddElement(new BottomBorder(chartString1));
                _chart.AddElement(captionY);
                gantChartArea.GraphCount = model.Graphs.Count;
                gantChartArea.StartHour = chartString.StartChartTime.Hour;
                //todo тут нужно переделать
                foreach (var graph in chartString.Graphs)
                {
                    foreach (var interval in graph.Intervals)
                    {
                        Color color = Color.Empty;
                        switch (graph.Name)
                        {
                            case "МДТ 6":
                            case "МДТ 6.1":
                            case "МДТ 6.2":
                                color = Color.Green;
                                break;
                            case "Сканер ТО1":
                            case "Сканер ТО2":
                                color = Color.Blue;
                                break;
                            case "УНСК.ТО1.МДТ 6":
                            case "УНСК.ТО1.МДТ 6.1":
                            case "УНСК.ТО2.МДТ 6.2":
                                color = Color.LightGreen;
                                break;
                            case "УНСК.ТО1.Сканер":
                            case "УНСК.ТО1.Сканер ТО1":
                            case "УНСК.ТО2.Сканер":
                                color = Color.LightBlue;
                                break;
                            default:
                                break;
                        }
                        _chart.AddElement(new IntervalG(gantChartArea, color, chartString.GetStartCoord(interval), chartString.GetEndCoord(interval), graph.Num, interval.Level));
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
