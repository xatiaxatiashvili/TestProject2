using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Exceptions;
using TestProject2.Core.Application.Interfaces.Repositories;

namespace TestProject2.Core.Application.Features.Persons.Queries
{
    public class GetPersonQuery
    {
        public record Request(Guid PersonId) : IRequest<GetPersonDto>;
        public class Handler : IRequestHandler<Request, GetPersonDto>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }

            public async Task<GetPersonDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var person = await _unit.PersonRepository.ReadAsync(request.PersonId);
                if (person == null) throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");         
                return await Task.FromResult(_mapper.Map<GetPersonDto>(person));
            }
        }
    }

}
