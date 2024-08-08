namespace Hotel.Models
{
    public class Reserve
    {
        private readonly List<Person> guests = [];
        private Suite suite = new(string.Empty, 0, 0);
        private int reservedDays;

        public void AddGuest()
        {
            if (guests.Count < suite.Capacity)
            {
                var guest = CreatePerson();
                guests.Add(guest);
            }
            else
            {
                Console.WriteLine("Não é possível adicionar mais hóspedes");
                Console.WriteLine("Tecla uma tecla para continuar");
                Console.ReadLine();
            }
        }

        private static Person CreatePerson()
        {
            Console.WriteLine("Digite o nome do hóspede");
            var name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite o sobrenome do hóspede");
            var lastName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Hóspede cadastrado com sucesso, Tecla uma tecla para continuar");
            Console.ReadLine();

            return new Person(name, lastName);
        }

        public void AddSuite()
        {
            Console.WriteLine("Digite o nome/tipo da suíte");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a capacidade da suíte");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o valor da diária");
            decimal dailyRate = Convert.ToDecimal(Console.ReadLine());

            RegisterHosting();

            suite = new Suite(name, capacity, dailyRate);

            Console.WriteLine("Suíte cadastrada com sucesso, Tecla uma tecla para continuar");
            Console.ReadLine();
        }

        public void GetNumberOfGuests()
        {
            Console.WriteLine("Suíte: " + suite.SuiteType);
            Console.WriteLine("Número de hóspedes: " + guests.Count);
            Console.WriteLine("Tecla uma tecla para continuar");
            Console.ReadLine();
        }

        public void CalculateDailyRate()
        {
            Console.WriteLine($"O valor da diária é: {(suite.DailyRate * reservedDays):C}");
            Console.WriteLine("Tecla uma tecla para continuar");
            Console.ReadLine();
        }

        private void RegisterHosting()
        {
            Console.WriteLine("Quantidade de diárias?");
            reservedDays = Convert.ToInt32(Console.ReadLine());
        }
    }
}
