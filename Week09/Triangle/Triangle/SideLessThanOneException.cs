using System;

namespace Triangle
{
    public class SideLessThanOneException : Exception
    {
        public SideLessThanOneException() : base()
        {

        }

        public SideLessThanOneException(string message): base(message)
        {

        }
    }
}


