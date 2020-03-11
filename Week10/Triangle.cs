using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_Triangle
{
    public class Triangle
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }

        public string AnalyzeType()
        {
            int a = SideA;
            int b = SideB;
            int c = SideC;

            if (a < 1 || b < 1 || c < 1 || a > 200 || b > 200 || c > 200)
            {
                throw new InvalidSideException();
            }

            if ((a>=b+c) ||(b>=a+c) || (c>=a+b))
            {
                return "Not a triangle";
            }

            if(a == b && b == c)
            {
                return "Equilateral";
            }
            else if (a == b || b ==c || a ==c)
            {
                return "Isosceles";
            }
            else
            {
                return "Scalene";
            }
        }

    }

    public class InvalidSideException : Exception
    {

    }
}
