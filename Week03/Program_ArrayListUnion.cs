using System;
using System.Linq;

namespace ArrayListUnion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 1, 2, 3 };
            int[] y = { 2, 3, 4 };
            runTest(x, y, "1, 2, 3, 4");

            y = new int [] { 1, 2, 3 };
            runTest(x, y, "1, 2, 3");

            x = new int[] { 1 };
            y = new int[] { 1 };
            runTest(x, y, "1");

            x = null;
            runTest(x, y, "Value cannot be null");

            x = new int [] { 1, 2, 3 };
            y = null;
            runTest(x, y, "Value cannot be null");

            x = null;
            runTest(x, y, "Value cannot be null");

            Console.ReadLine();
        }

        private static void runTest(int[] array1, int[] array2, string expected)
        {
            try
            {
                var result = MergeIntArray(array1, array2);
                var display = string.Join(", ", result);
                Console.WriteLine($"Test: x = [{string.Join(", ", array1)}]; y = [{string.Join(", ", array2)}]; Expected = [{expected}]");
                Console.WriteLine("Results: [{0}]", display);
                Console.WriteLine((string.Join(", ", result) == expected) ? "Test Passed\n" : "Test Failed\n");
            }
            catch (Exception ex)
            {
                string a = (array1 == null) ? "null" : string.Join(", ", array1);
                string b = (array2 == null) ? "null" : string.Join(", ", array2);
                Console.WriteLine($"Test: x = [{a}]; y = [{b}]; Expected = {expected}");
                Console.WriteLine($"Results: {ex.Message}");
                Console.WriteLine(ex.Message.Contains(expected) ? "Test Passed\n" : "Test Failed\n");
            }
            
        }

        public static int[] MergeIntArray(int[] array1, int[] array2)
        {
            return array1.Union(array2).Cast<int>().ToArray();
        }
    }
}
