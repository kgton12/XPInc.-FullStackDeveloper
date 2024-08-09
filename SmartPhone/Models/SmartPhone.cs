namespace SmartPhone.Models
{
    public abstract class SmartPhone(string number, string model, string imei, int memory)
    {
        public string Number { get; set; } = number;
        public string Model { get; set; } = model;
        public string IMEI { get; set; } = imei;
        public int Memory { get; set; } = memory;

        public abstract void InstallApp(string appName);

        public void Call()
        {
            Console.WriteLine($"Ligando...");
        }

        public void ReceiveCall()
        {
            Console.WriteLine("Recebendo ligação...");
        }
    }
}
