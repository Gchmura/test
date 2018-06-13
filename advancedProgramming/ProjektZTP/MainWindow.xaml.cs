using ProjektZTP.gw1;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using ProjektZTP.gw1.Indicators;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektZTP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private readonly ICalculateService _calculateService;

        

        public MainWindow()
        {
            //IN ARGS ERROR !!!
            //ICalculateService calculateService, IIndicatorsService inducatorService
            InitializeComponent();
          // _calculateService = calculateService;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //unoptimized 
            //WebClient client = new WebClient();
            //client.DownloadFile(
            //    "https://www.bankier.pl/inwestowanie/profile/quote.html?symbol=WIG",
            //    "file.html");

            //client.DownloadFile(
            //"http://bossa.pl/pub/metastock/mstock/mstall.zip",
            //"file2.zip");

            Assembly ass = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(ass.Location);

            // do service
            //using (ZipFile zip = ZipFile.Read(path + "\\mstall.zip"))
            //{
            //    zip.ExtractAll(path + "\\files");

            //}
            //MessageBox.Show("ok");

            DownloadService d = new DownloadService();


            //Download d = new DownloadFromBossa(new ErrorMessageToFile());

            //d.DownloadFile();





            
            //operations.Read();
            //operations.Calculate();
            //operations.Write();




            DirectoryInfo di = new DirectoryInfo(path + "\\files");
            Dictionary<string, string> l = new Dictionary<string, string>();
            //var list = _calculateService.Calculate(di);
            
            _calculateService.CalculateNormal(di);

            Console.WriteLine("DONE");
            Console.Read();

            TextBox t = new TextBox();
            t.Text = l.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //optimized
            //z wątkami
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //download
        }
    }
}
