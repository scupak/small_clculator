using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using small_calculator;

namespace CalculatorTest
{
    public class CalculatorTest
    {
        [Fact]
        public void CreateCalculator()
        {
            ICalculator c = new Calculator();
            Assert.Equal(0, c.Result);
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, -1, -1)]
        [InlineData(123, 1, 124)]
        [InlineData(-321, -1, -322)]
        [InlineData(0, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue, int.MinValue)]
        [InlineData(123, int.MaxValue - 123, int.MaxValue)]
        [InlineData(-234, int.MinValue + 234, int.MinValue)]
        public void AddValidValue(int initialValue, int x, int expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(initialValue);

            // Act
            c.Add(x);

            // Assert
            Assert.Equal(expected, c.Result);
        }

        [Theory]
        [InlineData(int.MaxValue, 1, "Overflow")]
        [InlineData(int.MinValue, -1, "Underflow")]
        public void AddWithOverflowExpectOverflowException(int initial, int x, string expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(initial);

            // Act + Assert
            var ex = Assert.Throws<OverflowException>(() =>
            {
                c.Add(x);
            });

            Assert.Equal(expected, ex.Message);
        }

        [Theory]
        [InlineData(0, 1, -1)]
        [InlineData(0, -1, 1)]
        [InlineData(123, 1, 122)]
        [InlineData(-321, -1, -320)]
        [InlineData(0, int.MaxValue, int.MinValue + 1)]
        [InlineData(0, int.MinValue + 1, int.MaxValue)]
        [InlineData(123, 123 - int.MaxValue, int.MaxValue)]
        [InlineData(-234, int.MaxValue - 233, int.MinValue)]
        public void SubtractValidValue(int initialValue, int x, int expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Result = initialValue;

            // Act
            c.Subtract(x);

            // Assert
            Assert.Equal(expected, c.Result);
        }
        [Theory]
        [InlineData(int.MinValue, 1, "Underflow")]
        [InlineData(int.MaxValue, -1, "Overflow")]
        public void SubtractWithOverflowExpectOverflowException(int initial, int x, string expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Result = initial;


            // Act + Assert
            var ex = Assert.Throws<OverflowException>(() =>
            {
                c.Subtract(x);
            });

            Assert.Equal(expected, ex.Message);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(2, 2, 4)]
        [InlineData(2, -3, -6)]
        public void MultiplyValidValue(int initialValue, int x, int expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Result = initialValue;

            // Act
            c.Multiply(x);

            // Assert
            Assert.Equal(expected, c.Result);
        }

        [Theory]
        [InlineData(int.MinValue, 2, "Underflow")]
        [InlineData(int.MaxValue, 2, "Overflow")]
        public void MultiplytWithOverflowExpectOverflowException(int initial, int x, string expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Result = initial;


            // Act + Assert
            var ex = Assert.Throws<OverflowException>(() =>
            {
                c.Multiply(x);
            });

            Assert.Equal(expected, ex.Message);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(2, -2, -1)]
        [InlineData(-6, 3, -2)]
        public void DivideValidValue(int initialValue, int x, int expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Result = initialValue;

            // Act
            c.Divide(x);

            // Assert
            Assert.Equal(expected, c.Result);
        }

        [Theory]
        [InlineData(0, 2, "Cant divide by 0")]
        [InlineData(4, 0, "Cant divide by 0")]
        public void DividetWithOverflowExpectOverflowException(int initial, int x, string expected)
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Result = initial;


            // Act + Assert
            var ex = Assert.Throws<InvalidDataException>(() =>
            {
                c.Divide(x);
            });

            Assert.Equal(expected, ex.Message);
        }
    }

}

