using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektZTP.gw1.SignalsModel;

namespace ProjektZTP.gw1.Indicators
{
    public interface ICalculateService
    {
        Task<List<SignalDictionary>> Calculate(DirectoryInfo di);
	    List<SignalDictionary> CalculateNormal(DirectoryInfo di);

      
    }
}
