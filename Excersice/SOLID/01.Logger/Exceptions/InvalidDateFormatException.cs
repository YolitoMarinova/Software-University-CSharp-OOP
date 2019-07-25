using System;

namespace _01.Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid DateTime format!";

        public InvalidDateFormatException()
        {

        }

        public InvalidDateFormatException(string message) 
            : base(message)
        {

        }

        public InvalidDateFormatException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
