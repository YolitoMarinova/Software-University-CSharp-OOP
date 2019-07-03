using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PointInRectangle
{
    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public bool Contains(Point point)
        {
            int x = point.X;
            int y = point.Y;

            bool isXInside = x >= topLeft.X && x <= bottomRight.X;
            bool isYInside = y >= topLeft.Y && y <= bottomRight.Y;

            return isXInside && isYInside;
        }
    }
}
