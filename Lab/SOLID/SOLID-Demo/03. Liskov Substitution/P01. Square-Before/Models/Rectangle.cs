using P01._Square_Before.Contracts;

namespace P01._Square_Before.Models
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area => this.Width * this.Height;
    }
}
