namespace TDDAndUnitTesting.Test
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void Sum_WhenCalled_ReturnTheSumOfArguments(int a, int b, int result)
        {
            // Arrange

            // Act
            int resultSum = Calculator.Sum(a, b);

            // Assert
            Assert.Equal(resultSum, result);
        }

        [Theory]
        [InlineData(10, 8, 2)]
        [InlineData(5, 5, 0)]
        public void SubTract_WhenCalled_ReturnTheSubTractOfArguments(int a, int b, int result)
        {
            // Arrange

            // Act
            int resultSubTrac = Calculator.Subtract(a, b);

            // Assert
            Assert.Equal(resultSubTrac, result);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(5, 5, 25)]
        public void Multiply_WhenCalled_ReturnTheMultiplyOfArguments(int a, int b, int result)
        {
            // Arrange

            // Act
            int resultMultiply = Calculator.Multiply(a, b);

            // Assert
            Assert.Equal(resultMultiply, result);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(12, 2, 6)]
        public void Divide_WhenCalled_ReturnTheDivideOfArguments(int a, int b, int result)
        {
            // Arrange

            // Act
            int resultDivide = Calculator.Divide(a, b);

            // Assert
            Assert.Equal(resultDivide, result);
        }

        [Fact]
        public void TestDivisionByZero()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(10, 0));
        }

        [Fact]
        public void TestLastResults()
        {
            // Arrange

            // Act
            Calculator.Subtract(10, 5);
            Calculator.Sum(10, 5);
            Calculator.Divide(10, 5);
            Calculator.Multiply(10, 5);

            // Assert
            Assert.NotEmpty(Calculator.LastResults());
            Assert.Equal(3, Calculator.LastResults().Count);
        }
    }
}
