using System;
using System.Collections.Generic;
using System.IO;
using ProjektZTP.gw1;

namespace ProjektZTP
{

    public class PointerForex : ErrorMessageToFile
    {



        public PointerForex()
        {
           
        }

        public object Calculate()
        {
            //liczenie
            return "wyliczono";

          
        }

        internal object Calculate(string readedFile)
        {
            var pointers = new List<char>();
            foreach (var item in readedFile)
            {
                pointers.Add(item);
            }
            return pointers;
        }
    }
}