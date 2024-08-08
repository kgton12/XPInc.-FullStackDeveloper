using Hotel.Models;

Reserve reserve = new();


while (true)
{
    CreateMenu();

    var switch_on = Console.ReadLine();

    switch (switch_on)
    {
        case "1":
            reserve.AddGuest();
            break;
        case "2":
            reserve.AddSuite();
            break;
        case "3":
            reserve.GetNumberOfGuests();
            break;
        case "4":
            reserve.CalculateDailyRate();
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

static void CreateMenu()
{
    Console.Clear();
    Console.WriteLine("Menu");
    Console.WriteLine("1 - Cadastrar hóspede");
    Console.WriteLine("2 - Cadastrar suite");
    Console.WriteLine("3 - Listar hóspedes");
    Console.WriteLine("4 - Calcular diaria");
}
