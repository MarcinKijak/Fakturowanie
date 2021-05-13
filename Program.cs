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
            var pathToCustomerFile = @"C:\Users\Lenovo\Desktop\R\Customers.txt";

            var customer = GetCustomerData();

            if (File.Exists(pathToCustomerFile))
            {
                var contentOfCustomerFile = File.ReadAllLines(pathToCustomerFile);
                if (CustomerExists(contentOfCustomerFile, customer))
                {
                    throw new Exception("Client exists!");
                }
                WriteCustomersToFile(contentOfCustomerFile, pathToCustomerFile, customer);
            }
            else
            {
                WriteSingleCustomerToFile(pathToCustomerFile, customer);
            }
        }

        private static void WriteCustomersToFile(string[] contentOfCustomerFile, string pathToCustomerFile, Customer customer)
        {
            Array.Resize<string>(ref contentOfCustomerFile, contentOfCustomerFile.Length + 1);
            contentOfCustomerFile[contentOfCustomerFile.Length - 1] = customer.ToString();
            //write records to file
            File.WriteAllLines(pathToCustomerFile, contentOfCustomerFile);
        }

        private bool CustomerExists(string[] contentOfCustomerFile, Customer customer)
        {
            foreach (var customerLine in contentOfCustomerFile)
            {
                var customerData = customerLine.Split(";");
                var taxNo = customerData[2].Split(":")[1];
                var email = customerData[3].Split(":")[1];
                if (taxNo == customer.TaxNumber || email == customer.Email)
                {
                    return true;
                }
            }

            return false;
        }

        private static void WriteSingleCustomerToFile(string pathToCustomerFile, Customer customer)
        {
            File.AppendAllText(pathToCustomerFile,$"{customer.ToString()}{Environment.NewLine}");
        }

        private static Customer GetCustomerData()
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

            return new Customer
            {
                Address = address,
                Email = eMail,
                Name = name,
                PhoneNumber = phoneNumber,
                TaxNumber = taxNumber
            };
        }
    }
}
