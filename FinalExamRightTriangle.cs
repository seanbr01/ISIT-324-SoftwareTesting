using System;

namespace FinalExamRightTriangle
{
    public class Triangle
    {
        const int Min = 1;
        const int Max = 100;
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }

        public string AnalyzeRightness()
        {
            string result;
            int a = SideA;
            int b = SideB;
            int c = SideC;

            if (a < Min || b < Min || c < Min || a > Max || b > Max || c > Max)
            {
                throw new ApplicationException();
            }
            else if (a > c || b > c)
            {
                result = "Side c not longest";
            }
            else if (c >= a + b)
            {
                result = "Not a triangle";
            }
            else
            {
                int aSquaredPlusbSquared = a * a + b * b;
                int cSquared = c * c;
                if (cSquared == aSquaredPlusbSquared)
                {
                    result = "Right triangle";
                }
                else if (cSquared < aSquaredPlusbSquared)
                {
                    result = "Acute triangle";
                }
                else
                {
                    result = "Obtuse triangle";
                }
            }
            return result;
        }
    }
}
