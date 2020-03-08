using System;
using System.Linq;
using Triangle;

namespace ISIT_324_04
{
    public class Triangle
    {
        public static string Analyze(int SideA, int SideB, int SideC)
        {
            string equilateral = "Equilateral";
            string isosceles = "Isosceles";
            string scalene = "Scalene";
            string notATriangle = "Not a triangle";

            int maxLength = 200;

            int[] values = new int[3] { SideA, SideB, SideC };

            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                throw new SideLessThanOneException("All paremeters must be greater than 0.");
            }

            if (SideA + SideB <= SideC || SideA + SideC <= SideB || SideB + SideC <= SideA)
            {
                //throw new TwoSidesCannotBeLessThanThirdSideException("Two sides added together cannot be less than the third side.");
                return notATriangle;
            }

            if (SideA > maxLength || SideB > maxLength || SideC > maxLength)
            {
                throw new LengthGreaterThan199Exception("One or more sides exceeds the max length.");
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
                    return notATriangle;
            }
        }
    }
}
