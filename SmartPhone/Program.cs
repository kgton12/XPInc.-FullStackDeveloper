using SmartPhone.Models;

Console.WriteLine("SmartPhone Nokia: ");
Nokia nokia = new("123456789", "Nokia 3310", "123456789", 16);
nokia.Call();
nokia.InstallApp("WhatsApp");

Console.WriteLine("\n");

Console.WriteLine("SmartPhone Iphone: ");
Iphone iphone = new("987654321", "Iphone 12", "987654321", 128);
iphone.Call();
iphone.InstallApp("Instagram");