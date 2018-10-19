using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeDiagrammGeneratorLibrary;

namespace Diagrams.WpfView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BarChart barChart = new BarChart(500, 500, 5);
            var barChartData = new BarChartData()
            {
                Bars = new[] {
                    new BarData()
                    {
                        BarNum = 0,
                        Name = "МДТ6",
                        Sections = new[]
                        {
                            new BarSectionData() { Name = "Прошло труб", SectionNum = 0, Value = 10 },
                            new BarSectionData() { Name = "Повторы", SectionNum = 1, Value = 20 },
                            new BarSectionData() { Name = "Образцы", SectionNum = 2, Value = 5 },
                        },
                        CaptionText = "10/35"
                    },
                    new BarData()
                    {
                        BarNum = 1,
                        Name = "Сканер",
                        Sections = new[]
                        {
                            new BarSectionData() { Name = "Прошло труб", SectionNum = 0, Value = 10 },
                            new BarSectionData() { Name = "Повторы", SectionNum = 1, Value = 3 },
                            new BarSectionData() { Name = "Образцы", SectionNum = 2, Value = 8 },
                        },
                        CaptionText = "10/22"
                    },
                }
            };

            barChart.SetData(barChartData);
            using (MemoryStream ms = new MemoryStream())
            {
                barChart.Draw().Save(ms,ImageFormat.Bmp);
                var bitmapImage = new BitmapImage();
                ms.Seek(0, SeekOrigin.Begin);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                image1.Source = bitmapImage;
            }
            
        }
    }
}