using Unit.Tests.Challenge.Services;

namespace Unit.Tests.Challenge.Test
{
    public class ValidationsStringTest
    {
        [Fact]
        public void GetCharacterCountTest()
        {
            // Arrange
            string text = "Hello World";

            // Act
            var result = StringValidations.GetCharacterCount(text);

            // Assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void ContainsCharacterTest()
        {
            // Arrange
            string text = "Hello World";
            string searchCharacter = "W";

            // Act
            var result = StringValidations.ContainsCharacter(text, searchCharacter);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EndsWithTextTest()
        {
            //Arrange
            string text = "Hello World";
            string searchText = "World";

            // Act
            var result = StringValidations.EndsWithText(text, searchText);

            // Assert
            Assert.True(result);
        }
    }
}
