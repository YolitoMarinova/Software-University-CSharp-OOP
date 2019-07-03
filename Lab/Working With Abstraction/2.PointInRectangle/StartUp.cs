using System;
using System.Linq;

namespace _02.PointInRectangle
{
    public class StartUp
    {
        public static void Main()
        {
            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Point topLeft = new Point(coordinates[0], coordinates[1]);
            Point bottomRight = new Point(coordinates[2], coordinates[3]);

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int[] pointCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int x = pointCoordinates[0];
                int y = pointCoordinates[1];

                Point currentPoint = new Point(x,y);

                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}
