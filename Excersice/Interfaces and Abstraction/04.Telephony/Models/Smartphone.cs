using _04.Telephony.Exceptions;
using _04.Telephony.Interfaces;
using System;
using System.Linq;

namespace _04.Telephony.Models
{
    public class Smartphone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(Char.IsDigit))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";

        }
        public string BrowsInWWW(string url)
        {
            if (url.Any(Char.IsDigit))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

    }
}
