using System;
using _03.Ferrarii.Interfaces;
using _03.Ferrarii.Models;

namespace _03.Ferrarii

{
    public class StartUp
    {
        public static void Main()
        {
            string driver = Console.ReadLine();

            ICar ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
