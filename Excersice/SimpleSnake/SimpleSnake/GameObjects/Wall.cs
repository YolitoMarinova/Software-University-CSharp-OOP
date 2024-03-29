﻿namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitiallizeWallBordes();
        }
        
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 ||
                snake.LeftX == 0 ||
                snake.LeftX == this.LeftX - 1 ||
                snake.TopY == this.TopY;
        }
        private void InitiallizeWallBordes()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticaleLine(0);
            this.SetVerticaleLine(this.LeftX-1);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX,topY,wallSymbol);
            }
        }

        private void SetVerticaleLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX,topY,wallSymbol);
            }
        }
    }
}
