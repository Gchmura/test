using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektZTP.gw1
{
    public class ErrorMessageToUser : ErrorMessage
    {
        public override void GetError(string message)
        {
            MessageBox.Show("error");
        }
    }
}
