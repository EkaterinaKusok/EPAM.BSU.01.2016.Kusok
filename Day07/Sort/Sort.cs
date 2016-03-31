using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class Sort
    {
        public static void BubbleSort<T>(ref T[] array, Comparer<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (comparer.Compare(array[j],array[j + 1])>0)
                        Swap(ref array[j], ref array[j + 1]);
        }

        private static void Swap<T>(ref T array1, ref T array2)
        {
            T current = array1;
            array1 = array2;
            array2 = current;
        }
        //Array.Sort(a, (x, y) => -x.CompareTo(y))
    }
}
