using System;
using System.Diagnostics;

namespace GcdCalculationAlgorithms
{
    public class CalculationGcd
    {
        public static int GcdByEuclidean(int first, int second)
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

        public static int GcdByEuclidean(int first, int second, int third)
        {
            return GCD(GcdByEuclidean, first, second, third);
        }

        public static int GcdByEuclidean(params int[] numbers)
        {
            return GCD(GcdByEuclidean, numbers);
        }

        public static int GcdByEuclidean(out TimeSpan workingTime, int first, int second)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = GcdByEuclidean(first, second);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GcdByEuclidean(out TimeSpan workingTime, int first, int second, int third)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = GCD(GcdByEuclidean, first, second, third);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GcdByEuclidean(out TimeSpan workingTime, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = GCD(GcdByEuclidean, numbers);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GcdByStein(int first, int second)
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

        public static int GcdByStein(int first, int second, int third)
        {
            return GCD(GcdByStein, first, second, third);
        }

        public static int GcdByStein(params int[] numbers)
        {
            return GCD(GcdByStein, numbers);
        }

        public static int GcdByStein(out TimeSpan workingTime, int first, int second)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = GcdByStein(first, second);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GcdByStein(out TimeSpan workingTime, int first, int second, int third)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = GCD(GcdByStein, first, second, third);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        public static int GcdByStein(out TimeSpan workingTime, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = GCD(GcdByStein, numbers);
            stopWatch.Stop();
            workingTime = stopWatch.Elapsed;
            return result;
        }

        private static int GCD(Func<int, int, int> algorithm, int first, int second, int third)
        {
            return algorithm(algorithm(first, second), third);
        }

        private static int GCD(Func<int, int, int> algorithm, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Length < 2)
                throw new ArgumentException("The number of values < 2.");
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                result = algorithm(result, numbers[i]);
            return result;
        }
    }
}
