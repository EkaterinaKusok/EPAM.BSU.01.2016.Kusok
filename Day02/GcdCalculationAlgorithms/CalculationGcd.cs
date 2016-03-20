using System;
using System.Diagnostics;

namespace GcdCalculationAlgorithms
{
    public class CalculationGcd
    {
        public enum Algorithms { Euclidean, Stein };

        public static int GCD(Algorithms algorithm, int first, int second)
        {
            if (algorithm == Algorithms.Euclidean)
                return EuclideanAlgorithm(first, second);
            else
                return SteinAlgorithm(first, second);
        }

        public static int GCD(Algorithms algorithm, int first, int second, int third)
        {
            return GCD(algorithm, GCD(algorithm, first, second), third);
        }

        public static int GCD(Algorithms algorithm = Algorithms.Euclidean, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Length < 2)
                throw new ArgumentException("The number of values < 2.");
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                result = GCD(algorithm, result, numbers[i]);
            return result;
        }

        public static int GCD(out TimeSpan workingTime, Algorithms algorithm, int first, int second)
        {
            int result = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (algorithm == Algorithms.Euclidean)
                result = EuclideanAlgorithm(first, second);
            else
                result = SteinAlgorithm(first, second);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GCD(out TimeSpan workingTime, Algorithms algorithm, int first, int second, int third)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = 0;
            result =GCD(algorithm, GCD(algorithm, first, second), third);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GCD(out TimeSpan workingTime, Algorithms algorithm, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Length < 2)
                throw new ArgumentException("The number of values < 2.");
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                result = GCD(algorithm, result, numbers[i]);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        private static int EuclideanAlgorithm(int first, int second)
        {
            if (first < 0 || second < 0)
                throw new ArgumentOutOfRangeException(" At least one of the parameters < 0.");
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == 1 || second == 1) return 1;
            while (second != 0)
                second = first%(first = second);
            return first;
        }

        private static int SteinAlgorithm(int first, int second)
        {
            if (first < 0 || second < 0)
                throw new ArgumentOutOfRangeException("At least one of the parameters < 0 !");

            if (first == 0) return second;
            if (second == 0) return first;
            if (first == second) return first;
            if (first == 1 || second == 1) return 1;

            int shift;
            for (shift = 0; ((first | second) & 1) == 0; ++shift)
            {
                first >>= 1;
                second >>= 1;
            }
            while ((first & 1) == 0)
                first >>= 1;
            do
            {
                while ((second & 1) == 0)
                    second >>= 1;
                if (first > second)
                {
                    int t = second;
                    second = first;
                    first = t;
                }
                second = second - first;
            } while (second != 0);
            return first << shift;
        }
        /*
        private static int EuclideanAlgorithm(out TimeSpan workingTime, int first, int second)
        {
            if (first < 0 || second < 0)
                throw new ArgumentOutOfRangeException(" At least one of the parameters < 0.");
            int result = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0 
            if (first == 0) result = second;
            else if (second == 0) result = first;
            else if (first == 1 || second == 1) result = 1;
            else
            {
                while (second != 0)
                    second = first % (first = second);
                result = first;
            }
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        private static int SteinAlgorithm(out TimeSpan workingTime, int first, int second)
        {
            if (first < 0 || second < 0)
                throw new ArgumentOutOfRangeException("At least one of the parameters < 0 !");
            int result = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (first == 0) result = second;
            else if (second == 0) result = first;
            else if (first == second) result = first;
            else if (first == 1 || second == 1) result = 1;
            else
            {
                int shift;
                // Let shift := lg K, where K is the greatest power of 2 dividing both first and second. 
                for (shift = 0; ((first | second) & 1) == 0; ++shift)
                {
                    first >>= 1;
                    second >>= 1;
                }
                while ((first & 1) == 0)
                    first >>= 1;
                // From here on, first number is always odd.
                do
                {
                    // remove all factors of 2 in second number -- they are not common 
                    //   note: second number is not zero, so while will terminate 
                    while ((second & 1) == 0)  
                        second >>= 1;
                    // Now first and second numbers are both odd. Swap if necessary so 
                    // first <= second, then set second = second - first (which is even). 
                    if (first > second)
                    {
                        int t = second;
                        second = first;
                        first = t;
                    } // Swap u and v.
                    second = second - first; // Here first >= second.
                } while (second != 0);
                // restore common factors of 2 
                result = first << shift;
            }
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }
        */
    }
}
