using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }


        public int OrderId {get; set;}
        public Order Order { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
