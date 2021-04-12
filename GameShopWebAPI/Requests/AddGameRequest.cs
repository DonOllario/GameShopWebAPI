using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Requests
{
    public class AddGameRequest
    {
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public double GamePrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string GameGenre { get; set; }
    }
}
