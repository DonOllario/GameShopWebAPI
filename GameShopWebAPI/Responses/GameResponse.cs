using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Responses
{
    public class GameResponse
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public double GamePrice { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
