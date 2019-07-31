using System;

namespace _02.EnterNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            int startNumber = 1;
            int endNumber = 100;

            NumberReader numberReader = new NumberReader();


            for (int count = 0; count < 10; count++)
            {
                try
                {
                    int number = numberReader.ReadNumber(startNumber, endNumber);

                    startNumber = number;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);

                    startNumber = 1;
                    count = 0;

                    continue;
                }
            }
        }
    }
}
