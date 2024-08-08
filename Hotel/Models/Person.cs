namespace Hotel.Models
{
    public class Person(string name, string lastName)
    {
        public string Name { get; set; } = name;
        public string LastName { get; set; } = lastName;
    }
}
