using System;

namespace FigureUtils
{
    public class Circle : Figure
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Circle
        /// </summary>
        /// <param name="radius">Circle radius</param>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius of the circle should be greater than zero");
            }

            Radius = radius;
        }

        /// <summary>
        /// Calculates the square of the circle
        /// </summary>
        protected sealed override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Calculates the perimeter of the circle
        /// </summary>
        protected sealed override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
