using System;

namespace _05.ConvertToDouble
{
    public class StartUp
    {
        public static void Main()
        {
            string numberToConvert = Console.ReadLine();
            double result;

            try
            {
                result = Convert.ToDouble(numberToConvert);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The number is not in valid format!");
                throw fe;
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("The number is not in range [-1.79769313486232E+308 - 1.79769313486232E+308]!");
                throw oe;
            }
        }
    }
}
