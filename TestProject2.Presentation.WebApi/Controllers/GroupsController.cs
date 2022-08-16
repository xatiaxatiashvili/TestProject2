using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Features.Group.Commands;
using TestProject2.Core.Application.Features.Organizations.Commands;
using TestProject2.Core.Application.Features.Organizations.Queries;

namespace TestProject2.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly IMediator _mediator;
        public GroupsController(IMediator mediator) =>
          _mediator = mediator;

        [HttpPost(Name = "CreateGroup")]
        public async Task<ActionResult> Add([FromForm] CreateGroupCommand.Request request, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return CreatedAtRoute("GetGroupsQuery", result);
        }



        [HttpGet(Name = "GetGroupsQuery")]
        public async Task<IEnumerable<GetGroupDto>> Get([FromQuery] GetGroupsQuery.Request request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
        [HttpDelete("{id}", Name = "DeleteGroup")]
        public async Task Delete([FromRoute] Guid id) =>
         await _mediator.Send(new DeleteGroupCommand.Request(id));
      

        //[HttpPut("{id}", Name = "UpdateGroup")]

        //public async Task UpdateGroup([FromRoute] Guid id, [FromBody] UpdateGroupCommand.Request request, CancellationToken cancellationToken = default)
        //{
        //    request.SetId(id);

        //    await _mediator.Send(request, cancellationToken);
        //}
    }
 }




