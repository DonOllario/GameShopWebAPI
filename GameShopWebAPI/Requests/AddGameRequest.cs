using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Requests
{
    public class AddGameRequest
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public double GamePrice { get; set; }
        public string ReleaseDate { get; set; }
    }
}
