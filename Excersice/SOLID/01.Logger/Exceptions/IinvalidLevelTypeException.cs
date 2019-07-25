using System;

namespace _01.Logger.Exceptions
{
    public class IinvalidLevelTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid level type!";

        public IinvalidLevelTypeException()
            :base(EXCEPTION_MESSAGE)
        {

        }

        public IinvalidLevelTypeException(string message) 
            : base(message)
        {

        }
    }
}
