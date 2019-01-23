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
using TimeDiagrammGeneratorLibrary.GraphicObjects;

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
            var values = new int[grapfsCount][] { new int[sectionsCount] { 20,5,2 }, new int[sectionsCount] { 10,3,8 } };

            BarChart barChart = new BarChart(new Scale(100,1000)) { Width = 1000,Height=1000, Margin=20 };
            barChart.SetData(graphNames, sectionNames, values);
            foreach (var bar in barChart.Bars.ToArray())
            {
                bar.Caption.Text = bar.Sections.ToArray()[0].Value + "/"+ bar.Sections.ToArray().Sum(s=>s.Value).ToString();
            }            
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