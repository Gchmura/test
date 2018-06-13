using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1
{
    public class DownloadFromBossa : Download
    {
        public DownloadFromBossa(ErrorMessage erm) : base(erm)

        {

        }



        protected override void DoDownload()

        {

            client.DownloadFile("http://bossa.pl/pub/metastock/mstock/mstall.zip", @"E:\ZTP\bossa\mstall.zip");

            using (ZipFile zip = ZipFile.Read(@"E:\ZTP\bossa\mstall.zip"))

            {

                zip.ExtractAll(@"E:\ZTP\bossa");

            }

        }
    }
}
