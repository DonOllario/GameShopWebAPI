using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Employee
    {
        public Employee() 
        {
            Stores = new List<Store>();
            Orders = new List<Order>();
        }

        public int EmployeeId { get; set; }
        public Guid EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmploymentDate { get; set; }


        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
