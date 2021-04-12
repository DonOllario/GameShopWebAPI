using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Responses
{
    public class GamesByGenreResponse
    {

        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
        public ICollection<GameResponse> Games { get; set; }
    }
}
