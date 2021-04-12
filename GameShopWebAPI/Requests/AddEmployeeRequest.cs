using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Requests
{
    public class AddEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Store { get; set; }
    }
}
