using System;

namespace _03.Fixing
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string[] weekdays = new string[]
                    {
                        "Sunday",
                        "Monday",
                        "Tuesday",
                        "Wednesday",
                        "Thursday"
                    };

                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }

                Console.ReadLine();
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine(ioore.Message);
            }
        }
    }
}
