using System;

namespace Triangle
{
    public class TwoSidesCannotBeLessThanThirdSideException : Exception
    {
        public TwoSidesCannotBeLessThanThirdSideException() : base()
        {

        }

        public TwoSidesCannotBeLessThanThirdSideException(string message) : base(message)
        {

        }
    }
}
