using System;
using System.Collections.Generic;
using System.Text;

namespace ISIT324Homework1
{
    public class FindLast
    {
        /**
         *Find last index of element
         *
         *@param x array to search
         *@param y value to look for
         *@return last index of y in x; -1 if absent
         *@throw NullPointerException if x is null
         */

        public static int findLast(int[] x, int y)
        {
            for (int i = x.Length - 1; i > -1; i--)
            {
                if (x[i] == y)
                {
                    return i;
                }
            }
            return -1;
        }
        // test: x = [2, 3, 5]; y = 2; Expected = 0
    }
}
