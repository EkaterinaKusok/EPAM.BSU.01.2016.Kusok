using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public static class SortClassViaDelegate
    {
        public static int[][] SortJaggedArray(int[][] arr, IComparer<int[]> sortType)
        {
            return SortJaggedArray(arr, sortType.Compare);
        }

        public static int[][] SortJaggedArray(int[][] arr, Comparison<int[]> compare)
        {
            if (arr == null || arr.Length == 0)
                return arr;
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (compare(arr[j],arr[j + 1])>0)
                        Swap(ref arr[j],ref arr[j+1]);
            return arr;
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] current = array1;
            array1 = array2;
            array2 = current;
        }
    }
}
