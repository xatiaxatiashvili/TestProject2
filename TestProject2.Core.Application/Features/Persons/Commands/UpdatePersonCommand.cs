using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.Exceptions;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Entities;
using TestProject2.Core.Domain.Enums;

namespace TestProject2.Core.Application.Features.Persons.Commands
{
    public class UpdatePersonCommand
    {
        public class Request : IRequest
         {
            public Guid PersonId { get; private set; }        
            public string PersonalNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ICollection<Status> Statuses { get; set; }
            public DateTime? BirthDate { get; set; }      
            public string Mail { get; set; }
            public Request() => this.Statuses = new HashSet<Status>();
            public void SetId(Guid personId) => this.PersonId = personId;
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

                cancellationToken.ThrowIfCancellationRequested();

                await _unit.PersonRepository.UpdateAsync(request.PersonId, person);

              return Unit.Value;
            }
        }
    }
}
