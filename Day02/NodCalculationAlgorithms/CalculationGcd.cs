﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcdCalculationAlgorithms
{
    public class CalculationGcd
    {
        public static int EuclideanAlgorithm(int first, int second, out double workingTime)
        {
            workingTime = 0;
            if (first < 0 || second < 0)
            {
                throw new FormatException("At least one of the parameters < 0 !");
            }
            //* GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0 */
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == 1 || second == 1) return 1;
            
            while (second != 0)
                second = first % (first = second);
            return first;
        }

        public static int SteinAlgorithm(int first, int second, out double workingTime)
        {
            workingTime = 0;
            if (first < 1 || second < 1)
            {
                throw new FormatException("At least one of the parameters < 1 !");
            }
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == second) return first;
            if (first == 1 || second == 1) return 1;

            int shift;
            /* Let shift := lg K, where K is the greatest power of 2
                  dividing both u and v. */
            for (shift = 0; ((first | second) & 1) == 0; ++shift)
            {
                first >>= 1;
                second >>= 1;
            }
            while ((first & 1) == 0)
                first >>= 1;
            /* From here on, first number is always odd. */
            do
            {
                /* remove all factors of 2 in second number -- they are not common */
                /*   note: second number is not zero, so while will terminate */
                while ((second & 1) == 0)  /* Loop X */
                    second >>= 1;
                /* Now first and second numbers are both odd. Swap if necessary so 
                    first <= second, then set second = second - first (which is even). */
                if (first > second)
                {
                    int t = second; second = first; first = t;
                }  // Swap u and v.
                second = second - first;          // Here first >= second.
            } while (second != 0);
            /* restore common factors of 2 */
            return first << shift;

        }
    }
}
