using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1
{
    public class DownloadService
    {
        public void DownloadFile(int source, int err)

        {



            WebClient client = new WebClient();

            try

            {

                if (source == 1)

                {

                    client.DownloadFile("https://www.bankier.pl/inwestowanie/profile/quote.html?symbol=PKNORLEN", @"E:\ZTP\bossa\bankier.html");

                }

                else if (source == 2)

                {

                    client.DownloadFile("http://bossa.pl/pub/metastock/mstock/mstall.zip", @"E:\ZTP\bossa\mstall.zip");

                    using (ZipFile zip = ZipFile.Read(@"E:\ZTP\bossa\mstall.zip"))

                    {

                        zip.ExtractAll(@"E:\ZTP\bossa");

                    }

                }

            }

            catch (Exception exc)

            {

                if (err == 1)

                {

                    System.IO.File.AppendAllText(@"E:\ZTP\bossa\log.txt", exc.Message);

                }

                else if (err == 2)
                {

                    Console.WriteLine(exc.Message);

                }

            }

        }
    }
}
