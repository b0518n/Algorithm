using System.Linq;
using System.Collections.Generic;

namespace Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int Fibonacci(int n)
            {
                if (n == 0)
                {
                    return 0;
                }

                if (n == 1)
                {
                    return 1;
                }

                return Fibonacci(n - 2) + Fibonacci(n - 1);
            }

            Console.WriteLine(Fibonacci(n));
        }
    }
}