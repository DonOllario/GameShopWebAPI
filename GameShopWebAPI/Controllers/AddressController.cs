using GameShopWebAPI.Models;
using GameShopWebAPI.Requests;
using GameShopWebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;
        public AddressController(GameShopDbContext gameShopDbContext) 
        {
            _gameShopDbContext = gameShopDbContext;
        }

        //Visar alla Addresser
        [HttpGet("ShowAddresses")]
        public ActionResult<List<Address>> GetAddress() 
        {
            try
            {
                var addressesFromDb = _gameShopDbContext.Addresses.ToList();
                var addressResponses = new List<AddressResponse>();

                foreach (var address in addressesFromDb)
                {
                    var addressResponse = new AddressResponse
                    {
                        AddressId = address.AddressId,
                        StreetAddress = address.StreetAddress,
                        City = address.City,
                        PostalCode = address.PostalCode
                    };
                    addressResponses.Add(addressResponse);
                }
                return Ok(addressResponses);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"You have entered something invalid {ex}, please try again");
            }
        }

        

        //Lägger till en ny address
        [HttpPost("AddAddress")]
        public ActionResult<string> AddAddress([FromBody] AddAddressRequest request)
        {
            var address = new Address
            {
                StreetAddress = request.StreetAddress,
                City = request.City,
                PostalCode = request.PostalCode
            };
            _gameShopDbContext.Addresses.Add(address);
            _gameShopDbContext.SaveChanges();
            return Ok($"Your address information has been saved sucessfully, {address.AddressId} at {address.StreetAddress}.");
        }
    }
}
