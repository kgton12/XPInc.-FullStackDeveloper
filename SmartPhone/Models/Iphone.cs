namespace SmartPhone.Models
{
    public class Iphone(string number, string model, string imei, int memory) : SmartPhone(number, model, imei, memory)
    {
        public override void InstallApp(string appName)
        {
            Console.WriteLine($"Instalando o App: {appName} da App Store");
        }
    }
}
