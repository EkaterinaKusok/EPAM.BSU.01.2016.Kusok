using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRoot
{
    public class MathClass
    {
        public static double FindNthRoot(double number, int root, double eps = 0.0001)
        {
            if (root < 1)
                throw new FormatException($"Wrong input data: {root}<1!");
            if (root%2==0 && number<0)
                throw new FormatException($"Wrong input data:  Root doesn't exist.");

            double prev, next = 1;
            do
            {
                prev = next;
                //next = ((root - 1)*prev + number/QuickInvolute(prev, root-1))/root;
                next = ((root - 1) * prev + number / Math.Pow(prev, root - 1)) / root;
            } while (Math.Abs(next - prev) > eps);
            return next;
        }
    }
}
