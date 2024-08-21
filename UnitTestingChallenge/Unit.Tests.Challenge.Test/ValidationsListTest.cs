using Unit.Tests.Challenge.Services;

namespace Unit.Tests.Challenge.Test
{
    public class ValidationsListTest
    {
        [Fact]
        public void RemoveNegativeNumbersTest()
        {
            // Arrange
            List<int> list = [1, 2, 3, -1, -2, -3];

            // Act
            var result = ValidationsList.RemoveNegativeNumbers(list);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(-1, result);
            Assert.DoesNotContain(-2, result);
            Assert.DoesNotContain(-3, result);
        }

        [Fact]
        public void ListContainsNumberTest()
        {
            // Arrange
            List<int> list = [1, 2, 3, 4, 5];
            int number = 3;

            // Act
            var result = ValidationsList.ListContainsNumber(list, number);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MultiplyNumbersInListTest()
        {
            // Arrange
            List<int> list = [1, 2, 3, 4, 5];
            int number = 2;

            // Act
            var result = ValidationsList.MultiplyNumbersInList(list, number);

            // Assert
            Assert.Equal(2, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(6, result[2]);
            Assert.Equal(8, result[3]);
            Assert.Equal(10, result[4]);
        }

        [Fact]
        public void GetLargestNumberInListTest()
        {
            // Arrange
            List<int> list = [1, 2, 3, 4, 5];

            // Act
            var result = ValidationsList.GetLargestNumberInList(list);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void GetSmallestNumberInListTest()
        {
            // Arrange
            List<int> list = [1, 2, 3, 4, 5];

            // Act
            var result = ValidationsList.GetSmallestNumberInList(list);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
