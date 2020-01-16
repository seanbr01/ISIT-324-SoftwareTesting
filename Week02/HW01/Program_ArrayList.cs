using System;
using System.Linq;

namespace ArrayListUnion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 2, 3, 4 };

            foreach (int num in MergeIntArray(array1, array2))
            {
                Console.WriteLine(num.ToString());
            }

            Console.ReadLine();
        }

        public static int[] MergeIntArray(int[] array1, int[] array2)
        {
            return array1.Union(array2).Cast<int>().ToArray();
        }
    }
}
