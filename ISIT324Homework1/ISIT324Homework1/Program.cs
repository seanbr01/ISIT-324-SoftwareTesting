using System;

namespace ISIT324Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { 2, 3, 5 };
            int y = 2;

            var results = FindLast.findLast(x, y);

            Console.WriteLine(results.ToString());

            Console.WriteLine("Hello World!");
        }
    }
}
