using System;

namespace _01.SquareRoot.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid number";

        public InvalidNumberException()
            : base (EXCEPTION_MESSAGE)
        {
        }

        public InvalidNumberException(string message) 
            : base(message)
        {
        }
    }
}
