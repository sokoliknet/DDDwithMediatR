using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DDDwithMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Creates a new Person and BusinessEntity objects
        /// </summary>
        /// <param name="personDto">The PersonDto object</param>
        /// <returns>PersonDto object</returns>
        /// <response code="200">Person created succesfully</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public IActionResult Post([FromBody] PersonDto personDto)
        {
            var result = _personService.CreatePerson(personDto);
            return Ok(result);
        }

        /// <summary>
        /// Get the list of Person objects
        /// </summary>
        /// <returns>List of PersonDto objects</returns>
        /// <response code="200">Person list by name returned succesfully</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("{personName}")]
        public IActionResult Get(string personName)
        {
            var result = _personService.GetPersonByName(personName);
            if (result == null || result.Count() == 0) return BadRequest("User Not Found");
            return Ok(result);
        }
    }
}
