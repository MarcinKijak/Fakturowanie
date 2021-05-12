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

            GetCustomerData(out var name, out var address, out var taxNumber, out var eMail, out var phoneNumber);
            
            if (File.Exists(pathToCustomerFile))
            {   
                var contentOfCustomerFile = File.ReadAllLines(pathToCustomerFile);
                if (CustomerExists(contentOfCustomerFile, taxNumber, eMail))
                {
                    throw new Exception("Client exists!");
                }
                WriteCustomersToFile(contentOfCustomerFile, name, address, taxNumber, eMail, phoneNumber, pathToCustomerFile);
            }
            else
            {
                WriteSingleCustomerToFile(pathToCustomerFile, name, address, taxNumber, eMail, phoneNumber);
            }
        }

        private static void WriteCustomersToFile(string[] contentOfCustomerFile, string? name, string? address,
            string? taxNumber, string? eMail, string? phoneNumber, string pathToCustomerFile)
        {
            Array.Resize<string>(ref contentOfCustomerFile, contentOfCustomerFile.Length + 1);
            contentOfCustomerFile[contentOfCustomerFile.Length - 1] =
                $"name:{name}; address:{address}; taxNumber:{taxNumber}; eMail:{eMail}; phoneNumber:{phoneNumber}{Environment.NewLine}";
            //write records to file
            File.AppendAllLines(pathToCustomerFile, contentOfCustomerFile);
        }

        private bool CustomerExists(string[] contentOfCustomerFile, string? taxNumber, string? eMail)
        {
            foreach (var customerLine in contentOfCustomerFile)
            {
                var customerData = customerLine.Split(";");
                var taxNo = customerData[2].Split(":")[1];
                var email = customerData[3].Split(":")[1];
                if (taxNo == taxNumber || email == eMail)
                {
                    return true;
                }
            }

            return false;
        }

        private static void WriteSingleCustomerToFile(string pathToCustomerFile, string? name, string? address, string? taxNumber,
            string? eMail, string? phoneNumber)
        {
            File.AppendAllText(pathToCustomerFile,
                $"name:{name}; address:{address}; taxNumber:{taxNumber}; eMail:{eMail}; phoneNumber:{phoneNumber}{Environment.NewLine}");
        }

        private static void GetCustomerData(out string? name, out string? address, out string? taxNumber, out string? eMail,
            out string? phoneNumber)
        {
            Console.WriteLine("Insert Customer name:");
            name = Console.ReadLine();
            Console.WriteLine("Insert Customer address:");
            address = Console.ReadLine();
            Console.WriteLine("Insert Customer tax number:");
            taxNumber = Console.ReadLine();
            Console.WriteLine("Insert Customer e-mail:");
            eMail = Console.ReadLine();
            Console.WriteLine("Insert Customer phone number:");
            phoneNumber = Console.ReadLine();
        }
    }
}
