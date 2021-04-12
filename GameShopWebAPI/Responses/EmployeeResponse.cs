using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Responses
{
    public class EmployeeResponse
    {
        public Guid EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
