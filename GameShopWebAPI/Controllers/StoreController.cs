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
    public class StoreController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;
        public StoreController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }

        //Lägger till en ny store och den address man skriver in, finns den redan i databasen lägger den bara till det ID:t till den nya Storen
        [HttpPost("AddStoreAndAddress")]
        public ActionResult<int> AddStoreAndStoreAddress([FromBody] AddStoreRequest request)
        {

            var alreadyExistCheck = _gameShopDbContext.Addresses.Find(request.StreetAddress);
            if (alreadyExistCheck == null)
            {
                var address = new Address
                {
                    StreetAddress = request.StreetAddress,
                    City = request.City,
                    PostalCode = request.PostalCode

                };
                _gameShopDbContext.Addresses.Add(address);
                _gameShopDbContext.SaveChanges();
                var store = new Store
                {
                    AddressId = address.AddressId
                };
                _gameShopDbContext.Stores.Add(store);
                _gameShopDbContext.SaveChanges();

                return Ok($"The Store has been saved sucessfully, {store.StoreId} at {store.Address.AddressId}.");
            }
            else
            {
                var store = new Store
                {
                    AddressId = alreadyExistCheck.AddressId
                };
                _gameShopDbContext.Stores.Add(store);
                _gameShopDbContext.SaveChanges();
                return Ok($"Your customer profile has been saved sucessfully, {store.StoreId} at {store.Address.AddressId}.");
            }
        }
    }
}
