using _01.SquareRoot.Exceptions;

namespace _01.SquareRoot
{
    public class SquareRootCalculator
    {
        public double CalculateSquareRoot(string number)
        {
            int multiplayer;

            if (!int.TryParse(number, out multiplayer) || multiplayer < 0)
            {
                throw new InvalidNumberException();
            }

            return multiplayer * multiplayer;
        }
    }
}
