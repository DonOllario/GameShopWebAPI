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
    public class OrderLineController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;

        public OrderLineController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }

        //[HttpPost("AddGameToBuy")]
        //public ActionResult<string> AddOrderLine([FromBody] AddOrderLineRequest request, [FromBody] AddOrderRequest request2)
        //{
        //    try
        //    {
        //        var orderAlreadyExistCheck = _gameShopDbContext.Orders.FirstOrDefault(x => x.StreetAddress == request.StreetAddress);
        //        var gameToBuy = _gameShopDbContext.Games.FirstOrDefault(x => x.GameName == request.GameName);
        //        if (gameToBuy != null)
        //        {
        //            var orderLine = new OrderLine
        //            {
        //                GameId = gameToBuy.GameId,
        //                Quantity = request.Quantity
        //            };
        //            var order = new Order 
        //            {

        //            }
        //            _gameShopDbContext.OrderLines.Add(orderLine);
        //            _gameShopDbContext.SaveChanges();
        //            return Ok($"The Game: {gameToBuy.GameName} with the quantity: {orderLine.Quantity}, has been added to the Database sucessfully.");
        //        }
        //        else
        //        {
        //            return "It doesn't exist a Game with that name, please try again.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ArgumentException($"Something went wrong, please try again {ex}");
        //    }
        //}
    }
}
