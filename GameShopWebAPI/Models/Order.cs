using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Order
    {
        public Order() 
        {
            OrderLines = new List<OrderLine>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
