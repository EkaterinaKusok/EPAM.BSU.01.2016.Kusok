using System;
using System.Collections.Generic;


namespace Fibonacci
{
    public static class Fibonacci
    {
        public static IEnumerable<long> GenerateFibonacci(long n)
        {
            if (n < 1) yield break;
            yield return 1;
            long prev = 0;
            long next = 1;

            for (long i = 1; i < n; i++)
            {
                long sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}
