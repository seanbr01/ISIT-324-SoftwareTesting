using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLast30
{
    public class SearchArray
    {
        //static void Main(string[] args)
        //{
        //    int[] incomingArray = null;
        //    int searchValue = 0;
        //    int expectedValue = 0;
        //    int returnValue = 0;

        //    //Test 1: Expect null pointer exception before fault is encountered
        //    Write("x is null, expect NullReferenceException.  Result: ");
        //    incomingArray = null;
        //    searchValue = 3;
        //    try
        //    {
        //        returnValue = FindLast(incomingArray, searchValue);
        //        WriteLine("Not a NullReferenceException. Fail.");

        //    }
        //    catch (NullReferenceException)
        //    {
        //        WriteLine("NullReferenceException. Pass");
        //    }

        //    //Test 2: If search value is found before i < 0, fault but no error
        //    incomingArray = new int[] { 2, 3, 5 };
        //    searchValue = 3;
        //    expectedValue = 1;
        //    Write($"incomingArray holds {string.Join(",", incomingArray)}, search value is {searchValue}.  Expected: {expectedValue}.  Result:  ");

        //    returnValue = FindLast(incomingArray, searchValue);

        //    if (returnValue == expectedValue) WriteLine($"{returnValue}. Pass");
        //    else WriteLine($"{returnValue}. Fail");


        //    //Test 3: If search value is not found, fault AND error
        //    incomingArray = new int[] { 2, 3, 5 };
        //    searchValue = 7;
        //    expectedValue = -1;
        //    Write($"incomingArray holds {string.Join(",", incomingArray)}, search value is {searchValue}.  Expected: {expectedValue}.  Result:  ");

        //    returnValue = FindLast(incomingArray, searchValue);

        //    if (returnValue == expectedValue) WriteLine($"{returnValue}. Pass");
        //    else WriteLine($"{returnValue}. Fail");

        //    //Test 4: If search value is in position 0, fault AND error AND failure
        //    incomingArray = new int[] { 2, 3, 5 };
        //    searchValue = 2;
        //    expectedValue = 0;
        //    Write($"incomingArray holds {string.Join(",", incomingArray)}, search value is {searchValue}.  Expected: {expectedValue}.  Result:  ");

        //    returnValue = FindLast(incomingArray, searchValue);

        //    if (returnValue == expectedValue) WriteLine($"{returnValue}. Pass");
        //    else WriteLine($"{returnValue}. Fail");

        //    ReadKey();
        //}

        public static int FindLast(int[] x, int y)
        {
            for (int i = x.Length - 1; i > 0; i--)  //Incorrect
                //for (int i = x.Length - 1; i >= 0; i--)   //Correct
            {
                if (x[i] == y)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
