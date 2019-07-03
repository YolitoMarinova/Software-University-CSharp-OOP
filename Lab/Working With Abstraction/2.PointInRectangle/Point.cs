using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PointInRectangle
{
    public class Point
    {
        private int x;
        private int y;

        public int X { get { return x; } private set { this.x = value; } }
        public int Y { get { return y; } private set { this.y = value; } }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
