using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Requests
{
    public class AddOrderRequest
    {
        public string GameName { get; set; }
        public int Quantity { get; set; }
    }
}
