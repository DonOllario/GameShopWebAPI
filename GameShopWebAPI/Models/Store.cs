using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Store
    {
        public Store() 
        {
            Employees = new List<Employee>();
        }

        public int StoreId { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
