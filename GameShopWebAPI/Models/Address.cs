using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Address
    {
        public Address() 
        {
            Customers = new List<Customer>();
            Employees = new List<Employee>();
            Stores = new List<Store>();
        }

        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public ICollection<Store> Stores { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
