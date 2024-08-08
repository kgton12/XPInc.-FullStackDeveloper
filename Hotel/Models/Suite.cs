namespace Hotel.Models
{
    public class Suite(string suiteType, int capacity, decimal dailyRate)
    {
        public string SuiteType { get; set; } = suiteType;
        public int Capacity { get; set; } = capacity;
        public decimal DailyRate { get; set; } = dailyRate;
    }
}
