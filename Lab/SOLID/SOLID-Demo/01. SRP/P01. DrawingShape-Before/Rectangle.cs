using P01._DrawingShape_Before.Contracts;

namespace P01._DrawingShape_Before
{
    public class Rectangle : IShape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Area
                 => this.Width * this.Height;        
    }
}
