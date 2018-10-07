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
            barChart.AddBar(new[] { 10, 20, 5 });
            barChart.AddBar(new[] { 10, 3, 8 });
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
