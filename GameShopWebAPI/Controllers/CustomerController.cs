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

        //Hämtar en specifik kund av angivet Id
        [HttpGet("GetSpecificCustomer")]
        public ActionResult<Customer> GetCustomer(int CustomerId) 
        {
            var customer = _gameShopDbContext.Customers.Where(c => c.CustomerId == CustomerId);

            if(customer == null)
            {
                return NotFound("There was no customer with that Id");
            }
            else
            {
                return Ok(customer);
            }
        }
        //Adderar en Customer och en ny Address i ett svep, Addressen behövs göras först i programmet men användaren
        //har samma visuella flöde som requesten.
        [HttpPost("AddCustomerAndAddress")]
        public ActionResult<string> AddCustomerAndCustomerAddress([FromBody] AddCustomerRequest request)
        {
            try
            {
                //alreadyExistCheck är en koll ifall Streetaddressen redan existerar, isåfall tar den bara det IDt och lägger till customern,
                //istället för att skapa en ny address
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
                else
                {
                    var customer = new Customer
                    {
                        AddressId = addressAlreadyExistCheck.AddressId,
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
            catch (Exception ex)
            {

                throw new ArgumentException($"Something went wrong, please try again {ex}");
            }
        }

        //Uppdaterar informationen av en kund (Vill lägga till Address senare)
        [HttpPatch("UpdateCustomer")]
        public ActionResult<Customer> UpdateCustomer(int customerId, [FromBody]UpdateCustomerInfoRequest request)
        {
            var customerUpdate = _gameShopDbContext.Customers.Find(customerId);

            if (request.FirstName != null)
            {
                customerUpdate.FirstName = request.FirstName;
            }
            else if (request.LastName != null)
            {
                customerUpdate.LastName = request.LastName;
            }
            else if (request.Email != null)
            {
                customerUpdate.Email = request.Email;
            }
            else if (request.PhoneNumber != null )
            {
                customerUpdate.PhoneNumber = request.PhoneNumber;
            }

            _gameShopDbContext.Customers.Update(customerUpdate);
            _gameShopDbContext.SaveChanges();
            return customerUpdate;
        }

        //Tar bort en existerande Customer. Men inte Addressen eftersom det är en annan entitet och att jag har tagit bort Cascading Delete.
        //Vet inte vad som är bäst, hade jag haft flera customers på samma address hade jag ju inte velat att addressen skulle försvinna heller.
        [HttpDelete("DeleteCustomer")]
        public ActionResult<string> DeleteCustomer(int customerId)
        {
            var deleteCustomer = _gameShopDbContext.Customers.Find(customerId);
            if (deleteCustomer == null)
            {
                return "Couldn't find any customer with a corresponding Id, please try again";
            }
            _gameShopDbContext.Customers.Remove(deleteCustomer);
            _gameShopDbContext.SaveChanges();
            return Ok($"The customer profile was deleted succesfully.");
        }

    }

}
