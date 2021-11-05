using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class Utilities
    {

        public static void Swap<T>(ref T a, ref T b)
        {
            T swapvar = a;
            a = b;
            b = swapvar;
        }

    }
}
