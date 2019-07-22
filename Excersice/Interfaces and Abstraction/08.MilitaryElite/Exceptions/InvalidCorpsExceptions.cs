using System;

namespace _08.MilitaryElite.Exceptions
{
    public class InvalidCorpsExceptions : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid corps!";

        public InvalidCorpsExceptions()
            : base (EXCEPTION_MESSAGE)
        {
        }

        public InvalidCorpsExceptions(string message) 
            : base(message)
        {
        }
    }
}
