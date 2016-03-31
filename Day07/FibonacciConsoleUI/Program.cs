using System;
using System.Collections.Generic;
using static Fibonacci.Fibonacci;

namespace FibonacciConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string fibString = "";
            int value;
            Console.WriteLine("Enter number of elements in Fibonacci sequence:");
            fibString = Console.ReadLine();
            while (fibString != "-1")
            {
                if (Int32.TryParse(fibString, out value) && value > -1)
                {
                    Console.WriteLine("Fibonacci sequence ({0} elements):", value);
                    foreach (var variable in GenerateFibonacci(value))
                    {
                        Console.Write("{0} ", variable.ToString());
                    }
                }
                else
                    Console.WriteLine("You set incorrect value of elements number.");
                Console.WriteLine();
                Console.WriteLine("Enter number of elements (-1 for end of programm):");
                fibString = Console.ReadLine();
            }
        }
    }
}
