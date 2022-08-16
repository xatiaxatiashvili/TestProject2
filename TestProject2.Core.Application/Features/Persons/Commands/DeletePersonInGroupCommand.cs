using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.Exceptions;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Core.Application.Features.Persons.Commands
{
   
    public class DeletePersonInGroupCommand
    {
        public class Request : IRequest
        {
            public Guid PersonId;

            public Request(Guid personId)
            {
                this.PersonId = personId;
            }

           // public Guid PersonId { get;  set; }
            public string? GroupId { get;  set; }
          
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
                var updatePerson = await _unit.PersonRepository.ReadAsync(request.PersonId);

                if (updatePerson == null)
                {
                    throw new EntityNotFoundException("ასეთი პიროვნება არ არსებობს");
                }
                

                var person = _mapper.Map<Person>(request);

                await _unit.PersonRepository.UpdateAsync(request.PersonId, person);

                return Unit.Value;

            }
        }
    }
}
