using GameShopWebAPI.Models;
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

        [HttpGet]
        public ActionResult<List<Address>> GetAddress() 
        {
            try
            {
                var addresses = _gameShopDbContext.Addresses.ToList();
                return Ok(addresses);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
