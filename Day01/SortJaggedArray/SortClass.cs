using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public enum Orders { Ascending, Descending };
    public enum Keys { MinValue, MaxValue, Sum };
    public class SortClass
    {

        public static int[][] SortJaggedArray(int[][] arr, Orders ord, Keys key)
        {
            if (arr == null || arr.Length==0)
                return arr;
            ArrayWrapper[] innerArray = new ArrayWrapper[arr.Length];
            for(int i=0;i<arr.Length;i++)
                innerArray[i]=new ArrayWrapper(arr[i],key);

            ArrayWrapper temp;
            bool exit = false;
            while (!exit) // пока массив не отсортирован
            {
                exit = true;
                for (int i = 0; i < arr.Length-1; i++)
                    if (innerArray[i].Compare(innerArray[i + 1])>0) // сравниваем два соседних элемента
                    {
                        // выполняем перестановку элементов массива
                        temp = innerArray[i];
                        innerArray[i] = innerArray[i + 1];
                        innerArray[i + 1] = temp;
                        exit = false; // на очередной итерации была произведена перестановка элементов
                    }
            }
            for (int i = 0; i < innerArray.Length; i++)
                arr[(ord==Orders.Ascending)?i:(innerArray.Length)-i-1] = innerArray[i].value;
            return arr;
        }
    }

    class ArrayWrapper
    {
        private long? key { get; set; }
        public int[] value { get; set; }
        public ArrayWrapper(int[] arr, Keys k)
        {
            if (arr == null || arr.Length == 0)
                key = null;
            else
            {
                switch (k)
                {
                    case Keys.MinValue:
                        key = arr[0];
                        for (int i = 1; i < arr.Length; i++)
                            if (arr[i] < key)
                                key = arr[i];
                        break;
                    case Keys.MaxValue:
                        key = arr[0];
                        for (int i = 1; i < arr.Length; i++)
                            if (arr[i] > key)
                                key = arr[i];
                        break;
                    case Keys.Sum:
                        key = 0;
                        for (int i = 0; i < arr.Length; i++)
                            key += arr[i];
                        break;
                }
            }
            value = arr;
        }

        public long Compare(ArrayWrapper second)
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
    }
}
