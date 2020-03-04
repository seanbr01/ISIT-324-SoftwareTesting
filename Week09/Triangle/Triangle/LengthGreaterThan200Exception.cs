using System;

namespace Triangle
{
    public class LengthGreaterThan200Exception : Exception
    {
        public LengthGreaterThan200Exception() : base()
        {

        }

        public LengthGreaterThan200Exception(string message) : base(message)
        {

        }
    }
}
