using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Features.Persons.Commands;
using TestProject2.Core.Application.Features.Persons.Queries;

namespace TestProject2.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IMediator _mediator;
        public PersonsController(IMediator mediator) =>
          _mediator = mediator;

        [HttpGet(Name = "GetPersons")]    
        public async Task<IEnumerable<GetPersonDto>> Get([FromQuery] GetPersonsQuery.Request request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpPost(Name = "CreatePerson")]   
        public async Task<ActionResult> Add([FromForm] CreatePersonCommand.Request request, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request, cancellationToken);           
            return CreatedAtRoute("GetPersons", result);
        }
        [HttpPut("{id}", Name = "UpdatePerson")]
      
        public async Task Update([FromRoute] Guid id, [FromBody] UpdatePersonCommand.Request request, CancellationToken cancellationToken = default)
        {
            request.SetId(id);

            await _mediator.Send(request, cancellationToken);
        }
        [HttpGet("{id}", Name = "GetPerson")]
        public async Task<GetPersonDto> Get([FromRoute] Guid id)
        {
         return   await _mediator.Send(new GetPersonQuery.Request(id));
        }


        [HttpDelete("{id}", Name = "DeletePerson")]      
        public async Task Delete([FromRoute] Guid id) =>
           await _mediator.Send(new DeletePersonCommand.Request(id));

        [HttpPost("{id}", Name = "DeletePersonInGroup")]
        public async Task DeletePersonInGroup([FromRoute] Guid id) =>
      await _mediator.Send(new DeletePersonInGroupCommand.Request(id));
    }
}
