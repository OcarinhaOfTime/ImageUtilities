using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities
{
    class ArrayUtilities
    {
        public static T[] MergeArrays<T>(T[] array1, T[] array2)
        {
            T[] merged = new T[array1.Length + array2.Length];

            for (int i = 0; i < array1.Length; i++)
                merged[i] = array1[i];

            for (int i = 0; i < array2.Length; i++)
                merged[i + array1.Length] = array2[i];

            return merged;
        }
    }
}
