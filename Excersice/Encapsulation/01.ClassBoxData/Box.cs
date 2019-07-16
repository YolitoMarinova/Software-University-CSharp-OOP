using System;
using System.Text;
using _01.ClassBoxData;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (!IsValid(value))
                {
                   throw new ArgumentException(Exception.LengthZeroOrNegativeException);
                }

                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(Exception.WidthZeroOrNegativeException);
                }

                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(Exception.HeightZeroOrNegativeException);
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh

            return 2 * this.length * this.width
              + 2 * this.length * this.height
               + 2 * this.width * this.height;
        }

        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh

            return 2 * this.length * this.height
                + 2 * this.width * this.height;
        }

        public double Volume()
        {
            //Volume = lwh

            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }
        private bool IsValid(double side)
        {
            return side > 0;
        }
    }
}
