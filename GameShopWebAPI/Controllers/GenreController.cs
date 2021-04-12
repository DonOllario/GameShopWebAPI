using GameShopWebAPI.Models;
using GameShopWebAPI.Requests;
using GameShopWebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;

        public GenreController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }

        //Visar alla spel som finns i en genre
        [HttpGet("GamesByGenre")] // Fungerar dock inte, får ut helt obegriblig json text.
        public ActionResult<GamesByGenreResponse> GamesByGenre(int GenreIdMatch)
        {
            var genreWithGames = _gameShopDbContext.Genres.Include(x => x.Games).FirstOrDefault(x => x.GenreId == GenreIdMatch);
            return Ok(genreWithGames);
        }


        //Lägger till en ny genre i databasen ifall den inte redan existerar.
        [HttpPost("AddGenre")]
        public ActionResult<string> AddGenre([FromBody] AddGenreRequest request)
        {
            try
            {
                var genreAlreadyExistCheck = _gameShopDbContext.Genres.FirstOrDefault(x => x.GenreName == request.GenreName);
                if (genreAlreadyExistCheck == null)
                {
                    var genre = new Genre
                    {
                        GenreName = request.GenreName,
                        GenreDescription = request.GenreDescription
                    };
                    _gameShopDbContext.Genres.Add(genre);
                    _gameShopDbContext.SaveChanges();
                    return Ok($"The new genre {genre.GenreName} has been added to the Database sucessfully.");
                }

                else
                {
                    return "It already exists a Genre with that name, please try again.";
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong, please try again {ex}");
            }
        }
    }
}
