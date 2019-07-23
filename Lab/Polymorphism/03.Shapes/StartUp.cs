using Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Rectangle rectangle = new Rectangle(0,0);
            Circle circle = new Circle(0);

            Console.WriteLine("Rectangle result:");
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine("Circle result:");
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
        }
    }
}
