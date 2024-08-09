namespace SmartPhone.Models
{
    public class Nokia(string number, string model, string imei, int memory) : SmartPhone(number, model, imei, memory)
    {
        public override void InstallApp(string appName)
        {
            Console.WriteLine($"Instalando o App: {appName} do windows store");
        }
    }
}
