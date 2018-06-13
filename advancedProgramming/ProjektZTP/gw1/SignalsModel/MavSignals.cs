using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1.SignalsModel
{
    class MavSignals : ISignals
    {
        public string[] dates { get; set; }
        public bool[] signals { get; set; }
        public List<(string dt, bool sg)> xx(List<(string dt, double pr)> D)
        {

            Random R = new Random();
            List<(string dt, bool sg)> Signals = new List<(string, bool)>();

            for (int i = 0; i < 12; i++)
            {
                Signals.Add((D[R.Next(0, D.Count)].dt, false));
                Signals.Add((D[R.Next(0, D.Count)].dt, true));
            }
            return Signals;
        }

    }
}
