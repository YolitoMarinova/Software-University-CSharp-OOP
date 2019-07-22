using System;

namespace _08.MilitaryElite.Exceptions
{
    public class InvalidStatesExceptions : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid states!";

        public InvalidStatesExceptions()
            : base(EXCEPTION_MESSAGE)
        {
        }

        public InvalidStatesExceptions(string message) 
            : base(message)
        {
        }
    }
}
