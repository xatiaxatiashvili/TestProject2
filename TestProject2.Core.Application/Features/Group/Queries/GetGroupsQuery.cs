using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Interfaces.Repositories;

namespace TestProject2.Core.Application.Features.Organizations.Queries
{   
    public class GetGroupsQuery
    {
        public class Request : IRequest<List<GetGroupDto>> {
            public string GroupNumber { get; set; }
        }     
        public class Handler : IRequestHandler<Request, List<GetGroupDto>>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }
            public async Task<List<GetGroupDto>> Handle(Request request, CancellationToken cancellationToken)
            {

                var group = await _unit.GroupRepository.GroupFilterAsync(groupNumber: request.GroupNumber);
        
                return _mapper.Map<List<GetGroupDto>>(group);
            }

        }
    }
}
