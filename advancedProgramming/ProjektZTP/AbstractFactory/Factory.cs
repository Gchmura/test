using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZTP.AbstractFactory
{
    public static class Factory
    {
        internal static PointerForex CreatePointer()
        {
            throw new NotImplementedException();
        }

        internal static PointerForex CreatePointer(string readedFile)
        {
            return new PointerForex();
        }
    }
}
