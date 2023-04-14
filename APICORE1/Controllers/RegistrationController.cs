using APICORE1.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using APICORE1.Models;

namespace APICORE1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
       
        private readonly IRegistration _IRegistration;

        public RegistrationController(IRegistration Registration)
        {
            _IRegistration = Registration;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegistration()
        {

            {
                var result = await _IRegistration.GetRegistration();
                return Ok(result);
            }

        }
        // DELETE: api/Registration/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteRegistration(int Id)
        {
            try
            {
                var result = await _IRegistration.DeleteRegistration(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data  from the server");
            }
        }
        // POST api/<Registration>
        [HttpPost]
        public async Task<IActionResult> AddRegistration(TblRegistration Registration)
        {
            try
            {
                var result = await _IRegistration.AddRegistration(Registration);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        [HttpGet("{Id}")]
        [HttpPut]
        [Route("Registration")]
        public async Task<IActionResult> UpdateRegistration(TblRegistration Registration)
        {
            try
            {
                await _IRegistration.UpdateRegistration(Registration);
                return Ok("Updated Successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
    }
}
