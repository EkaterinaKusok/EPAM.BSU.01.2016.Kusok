using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaggedArray;
using FindRoot;

namespace CheckResults
{
    class Program 
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][] {null, new int[] {1, 4, 6}, new int[] { -1, 0, -1100 }, new int[] { 5, 5, 5 } , new int[] { } };
            
            Console.WriteLine("По сумме элементов:");
            // Выполняем операцию, которая использует первый тип сортировки
            SortClassViaInterface.SortJaggedArray(arr, new CompareSumAsc());
            SortClassViaInterface.SortJaggedArray(arr, CompareByMaxAbcAsc);
            foreach (var cur in arr)
            {
                if (cur == null)
                    Console.Write("null");
                else
                    Console.Write('[' + string.Join(", ", cur) + ']');
                Console.WriteLine();
            }
            Console.WriteLine("По максимальному модулю:");
            // Заменяем в тип сортировки на другой
            SortClassViaDelegate.SortJaggedArray(arr, CompareByMaxAbcAsc);
            SortClassViaDelegate.SortJaggedArray(arr, new CompareSumAsc());
            foreach (var cur in arr)
            {
                if(cur == null)
                    Console.Write("null");
                else
                    Console.Write('['+string.Join(", ", cur)+']');
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        
        public static int CompareByMaxAbcAsc(int[] obj1, int[] obj2)
        {
            if (obj1 == null && obj2 == null) return 0;
            if (obj1 == null) return -1;
            if (obj2 == null) return 1;
            if (obj1.Length == 0 && obj2.Length == 0) return 0;
            if (obj1.Length == 0) return -1;
            if (obj2.Length == 0) return 1;
            // сейчас в обоих массивах есть хотя бы по одному элементу
            long key1 = obj1[0], key2 = obj2[0];
            for (int i = 1; i < obj1.Length; i++)
                if (Math.Abs(obj1[i]) > key1)
                    key1 = Math.Abs(obj1[i]);
            for (int i = 1; i < obj2.Length; i++)
                if (Math.Abs(obj2[i]) > key2)
                    key2 = Math.Abs(obj2[i]);
            if (key1 - key2 > 0) return 1;
            if (key1 == key2) return 0;
            return -1;
        }
   }
}
