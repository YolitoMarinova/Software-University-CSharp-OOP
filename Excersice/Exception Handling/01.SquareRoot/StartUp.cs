using _01.SquareRoot.Exceptions;
using System;

namespace _01.SquareRoot
{
    public class StartUp
    {
        public static void Main()
        {
            SquareRootCalculator squareRootCalculator = new SquareRootCalculator();

            try
            {
                string number = Console.ReadLine();

                double squareRoot = squareRootCalculator
                    .CalculateSquareRoot(number);

                Console.WriteLine(squareRoot);
            }
            catch (InvalidNumberException ine)
            {
                Console.WriteLine(ine.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
