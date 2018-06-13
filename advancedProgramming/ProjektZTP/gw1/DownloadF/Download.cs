using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.gw1
{
    public abstract class Download
    {
        protected ErrorMessage erm;

        protected WebClient client = new WebClient();



        public Download(ErrorMessage erm)

        {

            this.erm = erm;

        }





        public void DownloadFile()

        {

            try

            {

                DoDownload();

            }

            catch (Exception exc)

            {

                erm.GetError(exc.Message);

            }



        }



        protected virtual void DoDownload()

        {



        }
    }
}
