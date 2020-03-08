using System;

namespace Triangle
{
    public class LengthGreaterThan199Exception : Exception
    {
        public LengthGreaterThan199Exception() : base()
        {

        }

        public LengthGreaterThan199Exception(string message) : base(message)
        {

        }
    }
}
