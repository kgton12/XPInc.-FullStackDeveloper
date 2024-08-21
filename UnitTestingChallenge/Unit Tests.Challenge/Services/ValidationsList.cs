namespace Unit.Tests.Challenge.Services
{
    public static class ValidationsList
    {
        public static List<int> RemoveNegativeNumbers(List<int> list)
        {
            var listWithoutNegatives = list.Where(x => x > 0);
            return listWithoutNegatives.ToList();
        }

        public static bool ListContainsNumber(List<int> list, int number)
        {
            var contains = list.Contains(number);
            return contains;
        }

        public static List<int> MultiplyNumbersInList(List<int> list, int number)
        {
            var multipliedList = list.Select(x => x * number).ToList();
            return multipliedList;
        }

        public static int GetLargestNumberInList(List<int> list)
        {
            return list.Max();
        }

        public static int GetSmallestNumberInList(List<int> list)
        {
            return list.Min();
        }
    }
}
