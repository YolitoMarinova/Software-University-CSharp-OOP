using System;

namespace _02.EnterNumbers
{
    public class NumberReader
    {
        public int ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();

            int parsedNumber;

            if (!int.TryParse(number, out parsedNumber)
                || !IsValid(parsedNumber, start, end))
            {
                throw new FormatException("Invalid number!");
            }

            return parsedNumber;
        }

        private bool IsValid(int number, int start, int end)
        {
            return number >= start && number <=end;
        }
    }
}
