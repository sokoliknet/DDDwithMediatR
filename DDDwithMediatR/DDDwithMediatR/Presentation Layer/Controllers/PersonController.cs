using DDDwithMediatR.Application_Layer.Commands;
using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Application_Layer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DDDwithMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new Person and BusinessEntity objects
        /// </summary>
        /// <param name="CreatePersonCommand">The CreatePersonCommand object</param>
        /// <returns>PersonDto object</returns>
        /// <response code="200">Person created succesfully</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get the list of Person objects
        /// </summary>
        /// <returns>List of PersonDto objects</returns>
        /// <response code="200">Person list by name returned succesfully</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("get-persons")]
        public async Task<IActionResult> GetPersons()
        {
            var query = new GetAllPersonsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Get the list of Person objects
        /// </summary>
        /// <returns>List of PersonDto objects</returns>
        /// <response code="200">Person list by name returned succesfully</response>
        /// <response code="400">Person Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("person-by-name/{firstName}")]
        public async Task<IActionResult> GetPersonsByName(string firstName)
        {
            var query = new GetPersonByNameQuery(firstName);
            var result = await _mediator.Send(query);

            if (result == null) return BadRequest("Person Not Found");
            return Ok(result);
        }
    }
}
