using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Ellipse
{
    public class Ellipse
    {
        public int VerticalRadius { get; private set; }
        public int HorizontalRadius { get; private set; }
        public Ellipse(int verticalRadius, int horizontalRadius)
        {
            if (verticalRadius <= 0 | horizontalRadius <= 0)
            {
                throw new ArgumentException("Enter a radius greater than zero.");
            }
            VerticalRadius = verticalRadius;
            HorizontalRadius = horizontalRadius;
        }

        public double GetSquare()
        {
            return Math.Round(Math.PI * VerticalRadius * HorizontalRadius, 2);
        }
        public double GetLength()
        {
            return Math.Round(Math.PI * (VerticalRadius + HorizontalRadius), 2);
        }
    }
}
