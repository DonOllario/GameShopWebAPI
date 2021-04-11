using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
