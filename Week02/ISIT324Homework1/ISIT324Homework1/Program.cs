using System;

namespace ISIT324Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { 2, 3, 5 };
            int y = 2;

            Console.WriteLine("test: x = [2, 3, 5]; y = 2; Expected = 0");
            Console.WriteLine($"Results: {FindLast.findLast(x, y).ToString()}");

            y = 3;
            Console.WriteLine("test: x = [2, 3, 5]; y = 3; Expected = 1");
            Console.WriteLine($"Results: {FindLast.findLast(x, y).ToString()}");

            y = 5;
            Console.WriteLine("test: x = [2, 3, 5]; y = 5; Expected = 2");
            Console.WriteLine($"Results: {FindLast.findLast(x, y).ToString()}");

            y = 999;
            Console.WriteLine("test: x = [2, 3, 5]; y = 999; Expected = -1");
            Console.WriteLine($"Results: {FindLast.findLast(x, y).ToString()}");

            Console.ReadLine();
        }
    }
}
