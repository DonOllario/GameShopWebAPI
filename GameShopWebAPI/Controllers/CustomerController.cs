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
    public class CustomerController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;

        public CustomerController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }

        [HttpPost("AddCustomerAndCustomerAddress")]
        public ActionResult<int> AddCustomerAndCustomerAddress([FromBody] AddCustomerRequest request)
        {
            
            var address = new Address
            {
                StreetAddress = request.Address,
                City = request.City,
                PostalCode = request.PostalCode
                
            };
            _gameShopDbContext.Addresses.Add(address);
            _gameShopDbContext.SaveChanges();
            var customer = new Customer
            {
                AddressId = address.AddressId,
                Address = address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CreationDate = DateTime.Now
                
            };
            _gameShopDbContext.Customers.Add(customer);
            _gameShopDbContext.SaveChanges();
            return Ok($"Your customer profile has been saved sucessfully, {customer.FirstName} {customer.LastName}.");
        }
    }

}
