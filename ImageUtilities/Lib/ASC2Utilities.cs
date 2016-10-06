
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities
{
    class ASC2Utilities
    {
        public static bool IsNumber(char c)
        {
            int i = (int)c;
            return (i>=48) && (i<=57);
        }
    }
}
