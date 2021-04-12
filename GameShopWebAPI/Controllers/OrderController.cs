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
    public class OrderController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;

        public OrderController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }

        //[HttpPost("AddOrder")]
        //public ActionResult<string> AddGameToOrder([FromBody] AddOrderRequest request)
        //{
        //    try
        //    {

        //        var GameToBuy = _gameShopDbContext.Games.FirstOrDefault(x => x.GameName == request.GameName);

        //        if (GameToBuy != null)
        //        {
        //            var order = new Order
        //            {
        //                OrderDate = DateTime.Now,
        //                GenreDescription = request.GenreDescription
        //            };
        //            _gameShopDbContext.Genres.Add(genre);
        //            _gameShopDbContext.SaveChanges();
        //            return Ok($"The new genre {genre.GenreName} has been added to the Database sucessfully.");
        //        }

        //        else
        //        {
        //            return "It already exists a Genre with that name, please try again.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ArgumentException($"Something went wrong, please try again {ex}");
        //    }
        //}
    }
}
