using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjektZTP.Projekt.Factory;
using ProjektZTP.Projekt.Indicators;
using ProjektZTP.Projekt.Services;
using ProjektZTP.Projekt.Singleton;
using Unity;

namespace ProjektZTP
{
	/// <summary>
	///     Logika interakcji dla klasy App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			IUnityContainer container = new UnityContainer();
			container.RegisterType<ICalculateService, CalculateService>();
			container.RegisterType<IIndicatorsService, IndicatorsService>();
            container.RegisterSingleton<IDownloadService, DownloadService>();
            container.RegisterType<ISingleton, Singleton>();


            //container.Resolve()

            var mainWindow = container.Resolve<MainWindow>();
			mainWindow.Show();

		}
	}
}
