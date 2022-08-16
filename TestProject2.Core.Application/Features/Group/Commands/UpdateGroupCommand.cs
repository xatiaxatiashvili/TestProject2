using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.Exceptions;
using TestProject2.Core.Domain.Entities;
using TestProject2.Core.Application.Interfaces.Repositories;

namespace TestProject2.Core.Application.Features.Group.Commands
{
    public class UpdateGroupCommand
        {
            public class Request : IRequest
            {
                public Guid GroupId { get; private set; }
                public string GroupName { get; set; }
                public string GroupNumber { get; set; }

            public void SetId(Guid groupId) => this.GroupId = groupId;
            }
            public class Handler : IRequestHandler<Request>
            {
                private readonly IUnitOfWork _unit;
                private readonly IMapper _mapper;

                public Handler(IUnitOfWork unit, IMapper mapper)
                {
                    _unit = unit;
                    _mapper = mapper;
                }

                public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
                {
                    var updateGroup = await _unit.GroupRepository.ReadAsync(request.GroupId);

                    if (updateGroup == null)
                    {
                        throw new EntityNotFoundException("ასეთი ჯგუფი არ არსებობს");
                    }
                    var group = _mapper.Map<SchoolGroup>(request);
               

                    await _unit.GroupRepository.UpdateAsync(request.GroupId, group);

                    return Unit.Value;
                
                }
            }
        }
 }


