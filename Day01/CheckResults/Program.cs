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
            double x = 1025;
            int n = 4;
            Console.Write(MathClass.FindNthRoot(x,n,0.0001));
            Console.WriteLine();
            Console.Write(Math.Pow(x, (double)1/n));

            Console.ReadKey();
        }
    }
}
