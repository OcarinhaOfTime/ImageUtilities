using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Extentions {
    static class IntExtention {
        public static int NearestPowerOf4(this int i) {
            int j = i;
            while (j % 4 != 0)
                j--;

            return j;
        }
    }
}
