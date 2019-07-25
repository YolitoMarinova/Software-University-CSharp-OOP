using System;

namespace _01.Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid Appender type!"; 

        public InvalidAppenderTypeException()
            :base(EXCEPTION_MESSAGE)
        {
        }

        public InvalidAppenderTypeException(string message) 
            : base(message)
        {
        }
    }
}
