using System;

namespace FigureUtils
{
    public abstract class Figure
    {
        /// <summary>
        /// Returns the square of the figure
        /// </summary>
        public double Square => _square.Value;

        /// <summary>
        /// Returns the perimeter of the figure
        /// </summary>
        public double Perimeter => _perimeter.Value;

        private Lazy<double> _square => new Lazy<double>(CalculateSquare);
        private Lazy<double> _perimeter => new Lazy<double>(CalculatePerimeter);

        /// <summary>
        /// Calculates the square of the figure
        /// </summary>
        protected abstract double CalculateSquare();

        /// <summary>
        /// Calculates the perimeter of the figure
        /// </summary>
        protected abstract double CalculatePerimeter();
    }
}
