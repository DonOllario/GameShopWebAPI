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
    public class EmployeeController : ControllerBase
    {
        private GameShopDbContext _gameShopDbContext;

        public EmployeeController(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }



        //Adderar en Customer och en ny Address i ett svep, Addressen behövs göras först i programmet men användaren
        //har samma visuella flöde som requesten.
        [HttpPost("AddEmployeeAndAddress")]
        public ActionResult<string> AddCustomerAndCustomerAddress([FromBody] AddEmployeeRequest request)
        {
            try
            {
                var addressAlreadyExistCheck = _gameShopDbContext.Addresses.FirstOrDefault(x => x.StreetAddress == request.StreetAddress);
                if (addressAlreadyExistCheck == null)
                {
                    var address = new Address
                    {
                        StreetAddress = request.StreetAddress,
                        City = request.City,
                        PostalCode = request.PostalCode
                    };
                    _gameShopDbContext.Addresses.Add(address);
                    _gameShopDbContext.SaveChanges();
                    var employee = new Employee
                    {
                        AddressId = address.AddressId,
                        Address = address,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        EmploymentDate = DateTime.Today

                    };
                    _gameShopDbContext.Employees.Add(employee);
                    _gameShopDbContext.SaveChanges();
                    return Ok($"Your employee profile has been saved sucessfully, {employee.FirstName} {employee.LastName}.");
                }
                else
                {
                    var employee = new Employee
                    {

                        AddressId = addressAlreadyExistCheck.AddressId,
                        Address = addressAlreadyExistCheck,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        EmploymentDate = DateTime.Today

                    };
                    _gameShopDbContext.Employees.Add(employee);
                    _gameShopDbContext.SaveChanges();
                    return Ok($"Your employee profile has been saved sucessfully, {employee.FirstName} {employee.LastName}.");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong, please try again {ex}");
            }
        }
    }
}
