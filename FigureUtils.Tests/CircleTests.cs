using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;

namespace FigureUtils.Tests
{
    public class CircleTests
    {
        [Test]
        public void Circle_WhenNegativeRadius_ShouldThrowException()
        {
            //Arrange
            double radius = -99.789;

            //Act
            Action act = () => new Circle(radius);

            //Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("The radius of the circle should be greater than zero");
        }

        [TestCaseSource(nameof(Circle_ShouldReturnExpectedTestCases))]
        public void CalculateSquare_ShouldReturnSquare(string caseName, double radius)
        {
            //Arrange
            var circle = new Circle(radius);

            var expected = Math.PI * radius * radius;

            //Act
            var square = circle.Square;

            //Assert    
            square.Should().Be(expected);
        }

        [TestCaseSource(nameof(Circle_ShouldReturnExpectedTestCases))]
        public void CalculatePerimeter_ShouldReturnPerimetr(string caseName, double radius)
        {
            //Arrange
            var circle = new Circle(radius);

            var expected = 2 * Math.PI * radius;

            //Act
            var square = circle.Perimeter;

            //Assert     
            square.Should().Be(expected);
        }

        private static IEnumerable Circle_ShouldReturnExpectedTestCases
        {
            get
            {
                yield return new TestCaseData(
                    "When radius is 0.55",
                    0.55);

                yield return new TestCaseData(
                    "When radius is 100",
                    100);

                yield return new TestCaseData(
                    "When radius is 0.002",
                    0.002);

                yield return new TestCaseData(
                    "When radius is 8",
                    8);
            }
        }
    }


}
