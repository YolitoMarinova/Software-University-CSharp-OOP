using System;

namespace _01.RhombusOfStars
{
    public class StartUp
    {
        public static void Main()
        {       
            int size = int.Parse(Console.ReadLine());

            for (int i = 1; i <= size; i++)
            {
                PrintRow(i, size);
            }

            for (int i = size - 1; i >= 1; i--)
            {
                PrintRow(i, size);
            }
        }

        private static void PrintRow(int count, int size)
        {
            for (int i = 0; i < size - count; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < count; col++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
