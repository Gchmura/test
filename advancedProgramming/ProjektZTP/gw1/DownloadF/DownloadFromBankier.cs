using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1
{
    public class DownloadFromBankier : Download
    {
        public DownloadFromBankier(ErrorMessage erm) : base(erm)

        {

        }

        protected override void DoDownload()

        {

            client.DownloadFile("https://www.bankier.pl/inwestowanie/profile/quote.html?symbol=PKNORLEN", @"E:\ZTP\bossa\bankier.html");

        }
    }
}
