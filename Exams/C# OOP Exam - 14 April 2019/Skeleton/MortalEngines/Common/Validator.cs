using System;

namespace MortalEngines.Common
{
    public class Validator
    {
        public static void ValidateStringNotNullOrWhitespace(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException(str,message);
            }
        }

        public static void ValidateObjectIsNotNull(object obj,string message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }
    }
}
