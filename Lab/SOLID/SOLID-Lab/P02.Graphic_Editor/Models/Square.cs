using System;
using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor.Models
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Square");
        }
    }
}
