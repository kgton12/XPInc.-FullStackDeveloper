using Parking.Models;

VehicleParking parking = new();

Console.WriteLine("Digite o preco inicial");
parking.InitialValue = decimal.Parse(Console.ReadLine() ?? string.Empty);

Console.WriteLine("Digite o preco por hora");
parking.PricePerHour = decimal.Parse(Console.ReadLine() ?? string.Empty);

while (true)
{
    string option = VehicleParking.LoadMenu();

    switch (option)
    {
        case "1":
            parking.Register();
            break;
        case "2":
            parking.Unregister();
            break;
        case "3":
            parking.List();
            break;
        case "4":
            VehicleParking.Close();
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}