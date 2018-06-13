using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjektZTP.gw1.Indicators;
using Unity;

namespace ProjektZTP
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICalculateService, CalculateService>();
            container.RegisterType<IIndicatorsService, IndicatorsService>();
        }

    }
}
