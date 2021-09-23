using NUnit.Framework;
using FluentAssertions;
using System.Collections;
using System;

namespace FigureUtils.Tests
{
    public class TriangleTests
    {
        [TestCaseSource(nameof(Triangle_WhenNegativeSides_ShouldThrowExceptionTestCases))]
        public void Triangle_WhenNegativeSides_ShouldThrowException(string caseName, double firstSide, double secondSide, double thirdSide)
        {
            //Act
            Action act = () => new Triangle(firstSide, secondSide, thirdSide);

            //Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("The sides of the triangle can take positive values only");
        }

        [TestCaseSource(nameof(Triangle_WhenSideGreaterThanSumofOthersTestCases))]
        public void Triangle_WhenSideGreaterThanSumofOthers_ShouldThrowException(string caseName, double firstSide, double secondSide, double thirdSide)
        {
            //Act
            Action act = () => new Triangle(firstSide, secondSide, thirdSide);

            //Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("A side of a triangle should be less than the sum of two other sides");
        }

        [TestCaseSource(nameof(Triangle_ShouldReturnExpectedTestCases))]
        public void CalculateSquare_ShouldReturnExpected(string caseName, double firstSide, double secondSide, double thirdSide, double expectedSquare, double expectedPerimeter)
        {
            //Arrange
            var triangle = new Triangle(firstSide, secondSide, thirdSide);

            //Act
            var square = triangle.Square;

            //Assert    
            square.Should().Be(expectedSquare);
        }

        [TestCaseSource(nameof(Triangle_ShouldReturnExpectedTestCases))]
        public void CalculatePerimeter_ShouldReturnExpected(string caseName, double firstSide, double secondSide, double thirdSide, double expectedSquare, double expectedPerimeter)
        {
            //Arrange
            var triangle = new Triangle(firstSide, secondSide, thirdSide);

            //Act
            var perimeter = triangle.Perimeter;

            //Assert    
            perimeter.Should().Be(expectedPerimeter);
        }

        private static IEnumerable Triangle_ShouldReturnExpectedTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "When sides equals 3,4,5",
                    3,
                    4,
                    5,
                    6,
                    12);

                yield return new TestCaseData(
                   "When sides equals 13,12,5",
                   13,
                   12,
                   5,
                   30,
                   30);
            }
        }

        [TestCaseSource(nameof(IsRight_ShouldReturnExpectedTestCases))]
        public void IsRight_ShouldReturnExpected(string caseName, double firstSide, double secondSide, double thirdSide, bool expected)
        {
            //Arrange
            var triangle = new Triangle(firstSide, secondSide, thirdSide);

            //Act
            var IsRight = triangle.IsRight;

            //Assert
            IsRight.Should().Be(expected);
        }

        private static IEnumerable Triangle_WhenNegativeSides_ShouldThrowExceptionTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "When the first side is less than zero",
                    -3,
                    10,
                    10);

                yield return new TestCaseData(
                    "When the second side is less than zero",
                    3,
                    -4,
                    10);

                yield return new TestCaseData(
                    "When the third side is less than zero",
                    3,
                    4,
                    -5);

                yield return new TestCaseData(
                    "When three sides is less than zero",
                    -10,
                    -10,
                    -10);
            }
        }

        private static IEnumerable Triangle_WhenSideGreaterThanSumofOthersTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "When the first side is greater than the sum of the others",
                    5,
                    2,
                    2);

                yield return new TestCaseData(
                    "When the second side is greater than the sum of the others",
                    20,
                    40,
                    20);

                yield return new TestCaseData(
                    "When the third side is greater than the sum of the others",
                    13,
                    18,
                    31);
            }
        }

        private static IEnumerable IsRight_ShouldReturnExpectedTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "Triangle is rectangular",
                    3,
                    4,
                    5,
                    true);

                yield return new TestCaseData(
                    "Triangle is rectangular",
                    5,
                    12,
                    13,
                    true);

                yield return new TestCaseData(
                    "Triangle is rectangular",
                    7,
                    24,
                    25,
                    true);

                yield return new TestCaseData(
                    "Triangle is not rectangular",
                    6,
                    6,
                    6,
                    false);

                yield return new TestCaseData(
                    "Triangle is not rectangular",
                    200,
                    100,
                    225,
                    false);

                yield return new TestCaseData(
                    "Triangle is not rectangular",
                    19,
                    19,
                    10,
                    false);
            }
        }
    }
}