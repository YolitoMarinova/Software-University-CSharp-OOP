using _01.Logger.Exceptions;
using _01.Logger.Models;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumeration;
using _01.Logger.Models.Errors;
using System;
using System.Globalization;

namespace _01.Logger.Factories
{
    public class ErrorFactory
    {
        public IError GetError(string dateString,string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new IinvalidLevelTypeException();
            }

            DateTime dateTime;
            
            try
            {
                dateTime = DateTime.ParseExact(dateString,
                    DateTimeFormats.LoggerFormat,
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime,message,level);
        }
    }
}
