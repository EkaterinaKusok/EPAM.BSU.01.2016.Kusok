using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_th_root
{
    public class MathClass
    {
        public static double FindNthRoot(double a, int n, double eps = 0.0001)
        {
            //корень определяется для натуральных n>=2
            if (n < 2)
                throw new FormatException($"Wrong input data: {n}<2!");
            double x0, x1 = 1;
            do
            {
                x0 = x1;
                x1 = ((n - 1)*x0 + a/QuickInvolute(x0, n-1))/n;
            } while (Math.Abs(x1 - x0) > eps);
            return x1;
        }
        public static double QuickInvolute(double x, int n)
        {
            if (n < 0)
                throw new FormatException($"Wrong input data: {n}<0!");
            if (n == 0)
                return 1;
            double z = x;
            double res = 1;
            while (n>0)
            {
                if (n%2 == 1)
                    res *= z;
                z *= z;
                n /= 2;
            }
            return res;
        }
    }
}
