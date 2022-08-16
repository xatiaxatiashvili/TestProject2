using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Enums;

namespace TestProject2.Core.Application.Features.Persons.Queries
{
    public class GetPersonsQuery
    {
        public class Request : IRequest<List<GetPersonDto>>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PersonalNumber { get; set; }
            public DateTime BirthDate { get;  set; }
        } 
        public class Handler : IRequestHandler<Request, List<GetPersonDto>>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }
            public async Task<List<GetPersonDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                          
                var persons = await _unit.PersonRepository.FilterAsync(firstName: request.FirstName,lastName: request.LastName);
                return _mapper.Map<List<GetPersonDto>>(persons);
            }
        }          
 
    }
}
