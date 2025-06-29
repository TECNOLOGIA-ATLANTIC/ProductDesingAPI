using AtlanticProductDesing.API.Dtos.Person;
using AtlanticProductDesing.Application.Features.People.Commands.CreatePerson;
using AtlanticProductDesing.Application.Features.People.Commands.UpdatePerson;
using AtlanticProductDesing.Application.Features.People.Queries.GetPeople;
using AtlanticProductDesing.Application.Features.People.Queries.GetPersonById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AtlanticProductDesing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PeopleController(IMediator mediator, IMapper mapper)
        {

            _mediator = mediator;
            _mapper = mapper;
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<CreatePersonCommand>(data);
            var personId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = personId }, personId);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(long id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery(id));

            var personDto = _mapper.Map<PersonDto>(person);
            return Ok(personDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePersonDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var command = _mapper.Map<UpdatePersonCommand>(data);
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }


        // GET: api/People
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<PersonDto>), 200)]
        public async Task<IActionResult> GetPeople([FromQuery] int? Skip, [FromQuery] int? Limit)
        {

            var query = new GetPeopleQuery(Skip, Limit);
            var people = await _mediator.Send(query);
            return Ok(people);
        }


    }
}
