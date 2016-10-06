using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Extentions {
    static class ArrayExtention {
        public static T[] Merge<T>(this T[] array, T[] array2) {
            T[] merged = new T[array.Length + array2.Length];
            array.CopyTo(merged, 0);
            array2.CopyTo(merged, array.Length);

            return merged;
        }
    }
}
