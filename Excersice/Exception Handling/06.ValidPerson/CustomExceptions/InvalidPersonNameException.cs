using System;
using System.Runtime.Serialization;

namespace _06.ValidPerson.CustomExceptions
{

    public class InvalidPersonNameException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Name cannot content any special character or numeric value!";

        public InvalidPersonNameException()
            : base(EXCEPTION_MESSAGE)
        {
        }

        public InvalidPersonNameException(string message)
            : base(message)
        {
        }
    }
}
