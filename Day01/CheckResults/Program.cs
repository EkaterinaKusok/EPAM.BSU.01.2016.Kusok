using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_th_root;

namespace CheckResults
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 3126;
            int n = 5;
            Console.Write(MathClass.FindNthRoot(x,n,0.0001));
            Console.WriteLine();
            Console.Write(Math.Pow(3126, (double)1/n));

            Console.ReadKey();
        }
    }
}
