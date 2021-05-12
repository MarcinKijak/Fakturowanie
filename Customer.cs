using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturowanie
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"name:{Name}; address:{Address}; taxNumber:{TaxNumber}; eMail:{Email}; phoneNumber:{PhoneNumber}";
        }
    }
}
