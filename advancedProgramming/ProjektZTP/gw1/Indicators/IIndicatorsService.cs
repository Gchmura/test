using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1.Indicators
{
    public interface IIndicatorsService
    {
        Dictionary<string, string> Wskazniki(int period, string path);
    }
}
