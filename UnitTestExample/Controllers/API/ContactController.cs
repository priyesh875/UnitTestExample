using Microsoft.AspNetCore.Mvc;
using UnitTestExample.Models.ViewModels;
using UnitTestExample.Helper;
using UnitTestExample.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitTestExample.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// List of contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _contactService.GetContacts();
            return Ok(new { data = list });
        }

        /// <summary>
        /// Return single contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _contactService.GetContact(id);
            return Ok(result);
        }

        // POST api/<ContactController>
        /// <summary>
        /// Add or Update Contact
        /// </summary>
        /// <remarks>
        /// Sample add new contact request:
        /// 
        ///     {
        ///         "name": "jack smith",
        ///         "address": "893 Main St",
        ///         "jobTitle": "Manager",
        ///         "phone": "455-455-5555",
        ///         "comments": "Lorem Ipsum is simply dummy text of the printing.",
        ///         "email": "user@example.com",
        ///         "companyId": 2,
        ///         "lastDateContacted": "12/05/2022"
        ///     }
        ///     
        /// Sample update contact request:
        /// 
        ///     {
        ///         "id": "2",
        ///         "name": "jack smith",
        ///         "address": "893 Main St",
        ///         "jobTitle": "Manager",
        ///         "phone": "455-455-5555",
        ///         "comments": "Lorem Ipsum is simply dummy text of the printing.",
        ///         "email": "user@example.com",
        ///         "companyId": 2,
        ///         "lastDateContacted": "12/05/2022"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!SD.ToDateTime(model.LastDateContacted).HasValue)
                    {
                        return StatusCode(500, "Please enter valid date.");
                    }

                    if (model.Id.HasValue)
                    {
                        var result = await _contactService.UpdateContact(model);
                        return Ok(result);
                    }
                    else
                    {
                        var result = await _contactService.AddContact(model);
                        return Ok(result);
                    }

                }
                else
                {
                    return StatusCode(500, "Invalid data!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ContactVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!SD.ToDateTime(model.LastDateContacted).HasValue)
                    {
                        return StatusCode(500, "Please enter valid date.");
                    }

                    if (model.Id.HasValue)
                    {
                        var result = await _contactService.UpdateContact(model);
                        return Ok(result);
                    }
                    else
                    {
                        return StatusCode(500, "No data found!");
                    }
                }
                return StatusCode(500, "Invalid data!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete single contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _contactService.DeleteContact(id);
            return Ok(result);
        }

        /// <summary>
        /// List of companies
        /// </summary>
        /// <returns></returns>
        [HttpGet("Companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var result = await _contactService.GetCompanies();
            return Ok(result);
        }
    }
}
