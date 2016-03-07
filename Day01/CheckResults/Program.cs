using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArray;
using N_th_root;

namespace CheckResults
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 1025;
            int n = 4;
            Console.Write(MathClass.FindNthRoot(x,n,0.0001));
            Console.WriteLine();
            Console.Write(Math.Pow(x, (double)1/n));
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            int[][] arr = new int[][] {null, new int[] {1, 4, 6}, new int[] { -1, 0, 100 }, new int[] { 5, 5, 5 } , new int[] { } };
            SortClass.SortJaggedArray(arr,Orders.Descending, Keys.Sum);
            foreach (var VARIABLE in arr)
            {
                if(VARIABLE == null)
                    Console.Write("null");
                else
                    Console.Write('['+string.Join(", ", VARIABLE)+']');
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
