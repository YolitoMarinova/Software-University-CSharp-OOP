using System;

namespace CustomRandomList
{
   public class StartUp
    {
        public static void Main()
        {
            RandomList randomList = new RandomList()
            {
                "Yoana",
                "Zlatina",
                "Atanas"
            };

            Console.WriteLine(randomList.RandomString());
        }
    }
}
