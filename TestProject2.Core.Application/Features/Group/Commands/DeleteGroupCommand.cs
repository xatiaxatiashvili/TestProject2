using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.Interfaces.Repositories;

namespace TestProject2.Core.Application.Features.Group.Commands
{
    public class DeleteGroupCommand
    {
        public record Request(Guid GroupId) : IRequest;


        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork _unit;
            public Handler(IUnitOfWork unit) => _unit = unit;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                await _unit.GroupRepository.DeleteAsync(request.GroupId);

                return Unit.Value;
            }
        }
    }
}
