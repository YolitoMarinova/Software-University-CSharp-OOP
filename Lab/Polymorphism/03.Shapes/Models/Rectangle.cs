using System;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get => this.width;
            private set => this.width = value;
        }
        public double Height
        {
            get => this.height;
            private set => this.height = value;
        }

        public override double CalculateArea()
        {
            double area =  this.Height* this.Width;

            return Math.Round(area, 2);
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2*(this.Width + this.Height);

            return Math.Round(perimeter, 2);
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
