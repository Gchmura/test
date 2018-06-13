using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1.Indicators
{
    public interface ICalculateService
    {
        Task<Dictionary<string, string>> Calculate(DirectoryInfo di);
        void CalculateNormal(DirectoryInfo di);
      
    }
}
