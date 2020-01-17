using System;

namespace HW02
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new int[] { -4, 2, 0, 2 };
            runTest(x, "2");

            x = new int[] {  };
            runTest(x, "0");

            x = null;
            runTest(x, "reference not set");

            Console.ReadLine();
        }

        private static void runTest(int[] array, string expected)
        {
            try
            {
                var result = countPositive(array);
                var display = string.Join(", ", result);
                Console.WriteLine($"Test: x = [{string.Join(", ", array)}]; Expected = [{expected}]");
                Console.WriteLine("Results: [{0}]", display);
                Console.WriteLine((string.Join(", ", result) == expected) ? "Test Passed\n" : "Test Failed\n");
            }
            catch (Exception ex)
            {
                string a = (array == null) ? "null" : string.Join(", ", array);
                Console.WriteLine($"Test: x = [{a}]; Expected = {expected}");
                Console.WriteLine($"Results: {ex.Message}");
                Console.WriteLine(ex.Message.Contains(expected) ? "Test Passed\n" : "Test Failed\n");
            }

        }

        public static int countPositive(int[] x)
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                //if (x[i] >= 0)
                if (x[i] > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
