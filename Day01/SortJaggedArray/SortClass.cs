using System;
using System.Collections;
using System.Collections.Generic;

namespace JaggedArray
{
    //public enum Orders { Ascending, Descending };
  
    public static class SortClass
    {

        // не работает!
        public static int[][] SortJaggedArray(int[][] arr, Func<Int32[], Int32[], Int32> compare)
        {
            IComparer<Int32[]> sortType = (IComparer<Int32[]>)compare.GetType();
            return SortJaggedArray(arr, sortType);
        }

        public static int[][] SortJaggedArray(int[][] arr, IComparer<Int32[]> sortType)
        {
            if (arr == null || arr.Length==0)
                return arr;
            bool exit = false;
            int[] temp = null;
            while (!exit) // пока массив не отсортирован
            {
                exit = true;
                for (int i = 0; i < arr.Length-1; i++)
                    if (sortType.Compare(arr[i], arr[i + 1])>0) // сравниваем два соседних элемента
                    {
                        // выполняем перестановку элементов массива
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        exit = false; // на очередной итерации была произведена перестановка элементов
                    }
            }
            return arr;
        }
        
    }
}
