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
            var pathToCustomerFile = @"C:\Rafal\Customers.txt";

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
            if (File.Exists(pathToCustomerFile))
            {
                var contentOfCustomerFile = File.ReadAllLines(pathToCustomerFile);

                foreach (var customerLine in contentOfCustomerFile)
                {
                    var customerData = customerLine.Split(";");
                    var taxNo = customerData[2].Split(":")[1];
                    var email = customerData[3].Split(":")[1];
                    if (taxNo == taxNumber || email == eMail)
                    {
                        throw new Exception("Client exists!");
                    }
                }

                Array.Resize<string>(ref contentOfCustomerFile, contentOfCustomerFile.Length + 1);
                contentOfCustomerFile[contentOfCustomerFile.Length - 1] =
                    $"name:{name}; address:{address}; taxNumber:{taxNumber}; eMail:{eMail}; phoneNumber:{phoneNumber}{Environment.NewLine}";
                //write records to file
                File.AppendAllLines(pathToCustomerFile, contentOfCustomerFile);
            }
            else
            {
                File.AppendAllText(pathToCustomerFile, $"name:{name}; address:{address}; taxNumber:{taxNumber}; eMail:{eMail}; phoneNumber:{phoneNumber}{Environment.NewLine}");
            }

            
        }
    }
}
