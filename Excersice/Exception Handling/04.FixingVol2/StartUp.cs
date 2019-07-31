using System;

namespace _04.FixingVol2
{
    public class StartUp
    {
        public static void Main()
        {
            int num1, num2;
            byte result;

            try
            {
                num1 = 30;
                num2 = 60;

                result = Convert.ToByte(num1*num2);

                Console.WriteLine($"{num1} x {num2} = {result}");

                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
