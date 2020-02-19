using System;


namespace TooColdException
{
    public class ColderThanAbsoluteZeroException : Exception
    {
        public ColderThanAbsoluteZeroException()
        {
        }

        public ColderThanAbsoluteZeroException(string message) 
            : base(message)
        {
        }

        public ColderThanAbsoluteZeroException(string message, Exception inner)
            : base(message, inner)
        {

        }

    }
}
