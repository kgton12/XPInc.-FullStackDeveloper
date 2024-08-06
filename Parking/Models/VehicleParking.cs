namespace Parking.Models
{
    public class VehicleParking
    {
        public decimal InitialValue { get; set; }
        public decimal PricePerHour { get; set; }
        public int ParkedTime { get; set; }
        public List<string> VehiclePlate { get; set; } = [];

        public void Register()
        {
            Console.WriteLine("Digite a placa do veiculo:");
            string plate = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(plate) is false)
            {
                VehiclePlate.Add(plate);
            }
            Console.WriteLine("Veiculo cadastrado com sucesso!");
            Console.WriteLine("Digite uma tecla para continuar");
            Console.ReadLine();
        }
        public void Unregister()
        {
            Console.WriteLine("Digite a placa do veiculo:");
            string plate = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite o tempo de permanencia:");
            ParkedTime = int.Parse(Console.ReadLine() ?? string.Empty);

            decimal amountToPay = (PricePerHour * ParkedTime) + InitialValue;

            Console.WriteLine($"Valor a pagar : R$ {amountToPay:0.00}");

            if (string.IsNullOrWhiteSpace(plate) is false)
            {
                VehiclePlate.Remove(plate);
            }
            Console.WriteLine("Veiculo removido com sucesso!");
            Console.WriteLine("Digite uma tecla para continuar");
            Console.ReadLine();
        }
        public void List()
        {
            Console.WriteLine("Veiculos estacionados:");

            foreach (var plate in VehiclePlate)
            {
                Console.WriteLine(plate);
            }
            Console.WriteLine("Digite uma tecla para continuar");
            Console.ReadLine();

        }
        public static void Close()
        {
            Console.WriteLine("Parking closed");
            Environment.Exit(0);
        }
        public static string LoadMenu()
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veiculo.");
            Console.WriteLine("2 - Remover veiculo.");
            Console.WriteLine("3 - Listar veiculo.");
            Console.WriteLine("4 - Encerrar.");
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
