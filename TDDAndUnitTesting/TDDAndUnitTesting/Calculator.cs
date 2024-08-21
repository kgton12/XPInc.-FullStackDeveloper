namespace TDDAndUnitTesting
{
    public class Calculator
    {
        private static readonly List<string> _lastResults = [];

        public static int Sum(int a, int b)
        {
            _lastResults.Insert(0, $"{a} + {b} = {a + b}");
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            _lastResults.Insert(0, $"{a} - {b} = {a - b}");
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            _lastResults.Insert(0, $"{a} * {b} = {a * b}");
            return a * b;
        }
        public static int Divide(int a, int b)
        {
            _lastResults.Insert(0, $"{a} / {b} = {a / b}");
            return a / b;
        }
        public static List<string> LastResults()
        {
            return _lastResults.Take(3).ToList();
        }
    }
}
