using System;
using System.IO;

namespace Fakturowanie
{
    class Program
    {
        static void Main(string[] args)
        {

            var consoleApplication = new ConsoleApplication();

            consoleApplication.Run();

        }
    }

    public class ConsoleApplication
    {
        public void Run()
        {
            Console.WriteLine("Insert Customer name:");
            var name = Console.ReadLine();
            Console.WriteLine("Insert Customer address:");
            var address = Console.ReadLine();
            Console.WriteLine("Insert Customer tax number:");
            var taxNumber = Console.ReadLine();
            Console.WriteLine("Insert Customer e-mail:");
            var eMail = Console.ReadLine();
            Console.WriteLine("Insert Customer phone number:");
            var phoneNumber = Console.ReadLine();
            File.AppendAllText(@"C:\Users\Lenovo\Desktop\R\Customers.txt", $"name:{name} address:{address} taxNumber:{taxNumber} eMail:{eMail} phoneNumber:{phoneNumber}{Environment.NewLine}");
            //File.ReadAllLines(); sparsować


        }
    }
}
