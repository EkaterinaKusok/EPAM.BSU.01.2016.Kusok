using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public static class SortClass1
    {
        public static int[][] SortJaggedArray(int[][] arr, IComparer<Int32[]> sortType)
        {
            return SortJaggedArray(arr, sortType.Compare);
        }

        public static int[][] SortJaggedArray(int[][] arr, Func<Int32[], Int32[], Int32> compare)
        {
            if (arr == null || arr.Length == 0)
                return arr;
            bool exit = false;
            int[] temp = null;
            while (!exit)
            {
                exit = true;
                for (int i = 0; i < arr.Length - 1; i++)
                    if (compare(arr[i], arr[i + 1]) > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        exit = false;
                    }
            }
            return arr;
        }
    }
}
