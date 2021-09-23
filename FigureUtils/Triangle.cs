using System;
using System.Linq;

namespace FigureUtils
{
    public class Triangle : Figure
    {
        /// <summary>
        /// First side of the triangle
        /// </summary>
        public double FirstSide { get; }

        /// <summary>
        /// Second side of the triangle
        /// </summary>
        public double SecondSide { get; }

        /// <summary>
        /// Third side of the triangle
        /// </summary>
        public double ThirdSide { get; }

        /// <summary>
        /// Is the triangle a right triangle
        /// </summary>
        public bool IsRight => _IsRight.Value;

        private Lazy<bool> _IsRight => new Lazy<bool>(CheckIsRight);

        /// <summary>
        /// Triangle
        /// </summary>
        /// <param name="firstSide">First side</param>
        /// <param name="secondSide">Second side</param>
        /// <param name="thirdSide">Third side </param>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
            {
                throw new ArgumentException("The sides of the triangle can take positive values only");
            }

            if (firstSide >= secondSide + thirdSide
                || secondSide >= firstSide + thirdSide
                || thirdSide >= firstSide + secondSide)
            {
                throw new ArgumentException("A side of a triangle should be less than the sum of two other sides");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        /// <summary>
        /// Calculates the square of the triangle
        /// </summary>
        protected sealed override double CalculateSquare()
        {
            var semiPerimetr = CalculatePerimeter() / 2;
            return Math.Sqrt(semiPerimetr * (semiPerimetr - FirstSide) * (semiPerimetr - SecondSide) * (semiPerimetr - ThirdSide));
        }

        /// <summary>
        /// Calculates the perimeter of the triangle
        /// </summary>
        protected sealed override double CalculatePerimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
        }

        /// <summary>
        /// Checks is the triangle a right triangle
        /// </summary>
        private bool CheckIsRight()
        {
            var maxSide = new[] { FirstSide, SecondSide, ThirdSide }.Max();

            return maxSide * maxSide == (FirstSide * FirstSide + SecondSide * SecondSide + ThirdSide * ThirdSide) / 2;
        }
    }
}
