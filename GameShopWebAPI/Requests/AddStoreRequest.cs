using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Requests
{
    public class AddStoreRequest
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
