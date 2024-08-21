namespace Unit.Tests.Challenge.Services
{
    public static class StringValidations
    {
        public static int GetCharacterCount(string text)
        {
            var characterCount = text.Length;
            return characterCount;
        }

        public static bool ContainsCharacter(string text, string searchCharacter)
        {
            var contains = text.Contains(searchCharacter);
            return contains;
        }

        public static bool EndsWithText(string text, string searchText)
        {
            var endsWith = text.EndsWith(searchText);
            return endsWith;
        }
    }
}
