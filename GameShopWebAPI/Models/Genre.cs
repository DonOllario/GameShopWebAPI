using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Genre
    {
        public Genre() 
        {
            Games = new List<Game>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }


        public ICollection<Game> Games { get; set; }
    }
}
