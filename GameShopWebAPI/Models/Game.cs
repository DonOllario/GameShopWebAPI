using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Models
{
    public class Game
    {
        public Game() 
        {
            Genres = new List<Genre>();
            OrderLines = new List<OrderLine>();
        }
        
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public double GamePrice { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }

    }
}
