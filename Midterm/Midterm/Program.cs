using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = new int[] { -111, 113, -114, -119 };

            var results = OddOrPosClass.OddOrPos(vs);

            Console.WriteLine(results);

            Console.ReadLine();
        }
    }
}
