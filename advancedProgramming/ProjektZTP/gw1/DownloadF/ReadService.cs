using System;
using System.IO;
using ProjektZTP.AbstractFactory;
using ProjektZTP.gw1;

namespace ProjektZTP
{
    public class Operations : ErrorMessageToFile
    {
        private readonly PointerForex _pointer;
        private string _readedFile;
        private object _result;

        public Operations()
        {
            
        }

        public void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {

                    String line = sr.ReadToEnd();

                    _readedFile = line;
                }
            }
            catch (Exception e)
            {
                GetError(e.ToString());
                _readedFile = null;
            }
        }

        internal void Calculate()
        {
            //factor

            PointerForex pointer = Factory.CreatePointer(_readedFile);
            _result = pointer.Calculate(_readedFile);
        }

        internal void Write()
        {
            Console.WriteLine(_result);
        }



        //public Operations(Download d)
        //{
        //    this._download = d;
        //}
    }

   
}