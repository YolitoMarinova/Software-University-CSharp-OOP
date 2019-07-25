using System;

namespace _01.Logger.Exceptions
{
    public class InvalidLayoutException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid type of layout!";

        public InvalidLayoutException()
            :base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidLayoutException(string message) 
            : base(message)
        {

        }
    }
}
