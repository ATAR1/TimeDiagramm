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
            const int grapfsCount = 2;
            const int sectionsCount = 3;
            var sectionNames = new string[sectionsCount] { "Прошло труб" , "Повторы", "Образцы"};
            var graphNames = new string[grapfsCount] { "МДТ6", "Сканер" };
            var values = new int[grapfsCount][] { new int[sectionsCount] { 10,20,5 }, new int[sectionsCount] { 10,3,8 } };

            var bars = new BarData[grapfsCount];
            for (int i = 0; i < grapfsCount; i++)
            {
                bars[i] = new BarData() { Name = graphNames[i], CaptionText = $"{values[i][0]}/{values[i].Sum()}" };
                var sectionsList = new BarSectionData[sectionsCount]; 
                for (int j = 0; j < sectionsCount; j++)
                {
                    sectionsList[j] =  new BarSectionData() { Name = sectionNames[j],  Value = values[i][j] };
                }
                bars[i].Sections = sectionsList;
                
            }

            var barChartData = new BarChartData(){ Bars =bars };

            BarChart barChart = new BarChart(500, 500, 5);
            barChart.SetData(barChartData);
            barChart.SetActualHeight();
            barChart.SetActualWidth();
            image1.Source = Helper.SaveBitmapAsImage(barChart.Draw());
            
        }
    }

    public static class Helper
    {
        public static BitmapImage SaveBitmapAsImage(System.Drawing.Bitmap bitmapSource)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmapSource.Save(ms, ImageFormat.Bmp);
                var bitmapImage = new BitmapImage();
                ms.Seek(0, SeekOrigin.Begin);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}