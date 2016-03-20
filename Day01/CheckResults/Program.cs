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
            double x = -8;
            int n = 3;
            Console.Write(MathClass.FindNthRoot(x,n,0.0001));
            Console.WriteLine();
            Console.Write(Math.Pow(x, (double)1/n));
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            int[][] arr = new int[][] {null, new int[] {1, 4, 6}, new int[] { -1, 0, -1100 }, new int[] { 5, 5, 5 } , new int[] { } };
            SortClass cl = new SortClass(new ElementsSum());
            Console.WriteLine("По сумме элементов:");
            // Выполняем операцию, которая использует первый тип сортировки
            cl.SortJaggedArray(arr, Orders.Ascending);
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
            cl.SetSortType(new MaxAbcElement());
            cl.SortJaggedArray(arr,Orders.Descending);
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
    }
}
