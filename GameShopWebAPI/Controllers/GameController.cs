using GameShopWebAPI.Models;
using GameShopWebAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;
        public GameController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }


        //Lägger till ett nytt spel i databasen, har även felhantering då en genre inte skulle existera.
        //Kom på medans jag skrev den här kommentaren att det dock tvingar på användaren att skriva in en genre.
        [HttpPost("AddGame")]
        public ActionResult<string> AddGame([FromBody] AddGameRequest request)
        {
            try
            {
                var genreAlreadyExistCheck = _gameShopDbContext.Genres.Where(x => x.GenreName == request.GameGenre);
                if (genreAlreadyExistCheck != null)
                {
                    var game = new Game
                    {
                        GameName = request.GameName,
                        GameDescription = request.GameDescription,
                        GamePrice = request.GamePrice,
                        ReleaseDate = request.ReleaseDate,
                        Genres = genreAlreadyExistCheck.ToList()
                    };
                    _gameShopDbContext.Games.Add(game);
                    _gameShopDbContext.SaveChanges();
                    return Ok($"Your game, {game.GameName} with the price {game.GamePrice}kr has been added to the Database sucessfully.");
                }
                else if (request.GamePrice.Equals(typeof(int))) 
                {
                    return "The price isn't a number, please try again";
                }
                else
                {
                    return "It doesn't exist any Genre with that name, please try again or add a new genre to the database.";
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Something went wrong, please try again {ex}");
            }
        }
    }
}
