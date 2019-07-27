using P01._Square_Before.Contracts;
using System;

namespace P01._Square_Before
{
    public class Square : IShape
    {
        public double Side { get; set; }
        public double Area => Math.Sqrt(this.Side);
    }
}
