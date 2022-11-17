using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMiniProject.DataLayer.MyAppDbContext;
using MyMiniProject.Entities;
using MyMiniProject.Models.CustomerModels;
using MyMiniProject.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMiniProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _db;
        public CustomerController(IUnitOfWork db, ICustomerService customerService)
        {
            _db = db;
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var customer = await _customerService.GetAllAsync();
                return Ok(customer);
            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertCustomer(CustomerModel c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer costomer = new Customer
                    {
                        Firstname = c.Firstname,
                        Lastname = c.Lastname,
                        DateOfBirth = c.DateOfBirth,
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email,
                        BankAccountNumber = c.BankAccountNumber
                    };
                    await _customerService.AddAsync(costomer);
                    await _db.SaveChangesAsync();
                    return Ok(c);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                string err = ex.Message.ToString();
                return BadRequest("not ok");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer([FromRoute] int id, [FromBody] CustomerModel c)
        {
            try
            {
                var customer = await _customerService.FindByIdAsync(id);
                if (customer == null)
                    return NotFound("Customer Not Found");
                if (ModelState.IsValid)
                {
                    customer.Firstname = c.Firstname;
                    customer.Lastname = c.Lastname;
                    customer.DateOfBirth = c.DateOfBirth;
                    customer.PhoneNumber = c.PhoneNumber;
                    customer.Email = c.Email;
                    customer.BankAccountNumber = c.BankAccountNumber;
                }
                _customerService.Update(customer);
                _db.SaveChanges();
                return Ok("ok");
            }
            catch (System.Exception ex)
            {
                string err = ex.Message.ToString();
                return BadRequest("not ok");
            }

        }
        [HttpDelete("{id}")]
        public ActionResult RemoveCustomer([FromRoute] int id)
        {
            try
            {
                _customerService.Remove(id);
                _db.SaveChanges();
                return Ok("ok");
            }
            catch (System.Exception ex)
            {
                string err = ex.Message.ToString();
                return BadRequest("not ok");
            }
        }

        [HttpGet]
        public IActionResult Zarb(int x, int y)
        {
            return Ok(x * y);
        }
    }
}
