using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public enum Orders { Ascending, Descending };
  
    public class SortClass
    {
        private IComparer<Int32[]> _sortType;
        public SortClass(IComparer<Int32[]> sortType)
        {
            _sortType = sortType;
        }
        public void SetSortType(IComparer<Int32[]> sortType)
        {
            _sortType = sortType;
        }

        public int[][] SortJaggedArray(int[][] arr, Orders ord=Orders.Ascending)
        {
            if (arr == null || arr.Length==0)
                return arr;
            bool exit = false;
            int[] temp = null;
            while (!exit) // пока массив не отсортирован
            {
                exit = true;
                for (int i = 0; i < arr.Length-1; i++)
                    if (_sortType.Compare(arr[i], arr[i + 1])>0) // сравниваем два соседних элемента
                    {
                        // выполняем перестановку элементов массива
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        exit = false; // на очередной итерации была произведена перестановка элементов
                    }
            }
            if (ord == Orders.Descending)
                Array.Reverse(arr);
            return arr;
        }
    }

   /* class ArrayWrapperMax : IComparable<Int32[]>
    {
        private long? key { get; set; }
        public int[] value { get; set; }

        public ArrayWrapperMax(int[] arr, Keys k)
        {
            if (arr == null || arr.Length == 0)
                key = null;
            else
            {
                key = arr[0];
                for (int i = 1; i < arr.Length; i++)
                    if (arr[i] > key)
                        key = arr[i];
            }
            value = arr;
        }

        public int CompareTo(int[] second)
        {
            if (key == null)
            {
                if (value == null)
                {
                    if (second.key == null)
                    {
                        if (second.value == null)
                            return 0;
                        return -1;
                    }
                    return -1;
                }
                else
                {
                    if (second.key == null)
                    {
                        if (second.value == null)
                            return 1;
                        return 0;
                    }
                    else
                        return -1;
                }
            }
            else
            {
                if (second.key == null)
                    return 1;
                return (long)key - (long)second.key;
            }
        }
    }*/
}
