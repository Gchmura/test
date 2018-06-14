using ProjektZTP.Projekt;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using ProjektZTP.Projekt.Indicators;
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
using ProjektZTP.Projekt.Singleton;
using Ionic.Zip;

namespace ProjektZTP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
	    private readonly ICalculateService _calculateService;
        private readonly ISingleton singleton;

        public MainWindow(ICalculateService calculateService,
            ISingleton singleton)
        {
	        _calculateService = calculateService;
            this.singleton = singleton;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //unoptimized 

            //operations.Read();
            //operations.Calculate();
            //operations.Write();
           

            Assembly ass = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(ass.Location);


            DirectoryInfo di = new DirectoryInfo(path + "\\files");
            Dictionary<string, string> l = new Dictionary<string, string>();
			//var list = _calculateService.Calculate(di);

	        var result = _calculateService.CalculateNormal(di);


            listaWynikow.ItemsSource = result;
			MessageBox.Show("pomyślnie");

		}

		private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
	        Assembly ass = Assembly.GetExecutingAssembly();

			string path = System.IO.Path.GetDirectoryName(ass.Location);

			DirectoryInfo di = new DirectoryInfo(path + "\\files");
	        Dictionary<string, string> l = new Dictionary<string, string>();	      
            

            var result = await _calculateService.Calculate(di);

            listaWynikow.ItemsSource = result;
            MessageBox.Show("pomyślnie");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//WebClient client = new WebClient();
            //client.DownloadFile(
            //    "https://www.bankier.pl/inwestowanie/profile/quote.html?symbol=WIG",
            //    "file.html");

            //client.DownloadFile(
            //"http://bossa.pl/pub/metastock/mstock/mstall.zip",
            //"file2.zip");


            var downloadService = singleton.GetDownloadServiceSingleInstance();

            downloadService.DownloadFiles();



            //Download d = new DownloadFromBossa(new ErrorMessageToFile());

            //d.DownloadFile();

            //download
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //var results = _calculateService.GetResults();
            //for (int i = 0; i < 100; i++)
            //{
            //    wyniki.Text += results[i].Key + " " + results[i].Value;
            //}
            //gridq.DataContext = results;

        }
    }
}
