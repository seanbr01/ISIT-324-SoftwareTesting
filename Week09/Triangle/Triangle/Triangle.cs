using System;
using System.Linq;
using Triangle;

namespace ISIT_324_04
{
    public class Triangle
    {
        //This version of the analyze method supports the Red phase.
        //public static string Analyze(int SideA, int SideB, int SideC)
        //{
        //    throw new NotImplementedException();
        //}

        public static string Analyze(int SideA, int SideB, int SideC)
        {
            string equilateral = "Equilateral";
            string isosceles = "Isosceles";
            string scalene = "Scalene";

            int[] values = new int[3] { SideA, SideB, SideC };

            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                throw new SideLessThanOneException("All paremeters must be greater than 0.");
            }

            if (SideA + SideB <= SideC || SideA + SideC <= SideB || SideB + SideC <= SideA)
            {
                throw new TwoSidesCannotBeLessThanThirdSideException("Two sides added together cannot be less than the third side.");
            }

            switch (values.Distinct().Count())
            {
                case 1:
                    return equilateral;
                case 2:
                    return isosceles;
                case 3:
                    return scalene;
                default:
                    throw new SideLessThanOneException("Not a Triangle");
            }
        }
    }
}
