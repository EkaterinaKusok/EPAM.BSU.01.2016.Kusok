using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearch
    {
        public static int Find<T>(T[] array, T searchFor, Comparer<T> comparer = null) //Comparer<T>.Default 
        {
            if (array == null || array.Length == 0) return -1; //  throw new NullReferenceException();
            int left = 0, right = array.Length, mid;
            if (comparer == null)
            {
                if (searchFor is IComparer<T>) // не работает проверка
                    comparer = Comparer<T>.Default;
                else
                    return SimpleSearch(array, searchFor);
            }

            while (left < right)
            {
                mid = left + (right - left)/2;
                if (searchFor.Equals(array[mid]))
                    return mid;

                if (comparer.Compare(searchFor, array[mid]) < 0)
                    right = mid;
                else
                    left = mid + 1;
            }
            return ~left; //-(1 + left); 
        }

        private static int SimpleSearch<T>(T[] array, T searchFor)
        {
            for (int i=0;i<array.Length;i++)
                if (array[i].Equals(searchFor))
                    return i;
            return -100;
        }
    }
}
