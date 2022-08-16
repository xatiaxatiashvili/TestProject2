using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Core.Application.Features.Organizations.Commands
{
    public class CreateGroupCommand
    {
        public class Request : IRequest<Guid>
        {
            public string GroupName { get; set; }
            public string GroupNumber { get; set; }

        }

        public class Handler : IRequestHandler<Request, Guid>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;
           
            public Handler(IUnitOfWork unit,IMapper mapper)
            {
                _unit = unit;              
                _mapper = mapper;
            }
            public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
            {
                var group = _mapper.Map<SchoolGroup>(request);
                await _unit.GroupRepository.CreateAsync(group);
                return new Guid();
            }
        }
        public class Validator : AbstractValidator<Request>
        {
            private readonly IUnitOfWork _unit;

            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(x => x.GroupName)
                    .NotNull().WithMessage("ჯგუფის დასახელება ცარიელია")
                    .Length(2, 100).WithMessage("ჯგუფის დასახელება უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 100 სიმბოლოს," +
                                  " უნდა შეიცავდეს მხოლოდ ქართულ ან ლათინურ ასოებს");                
               
                RuleFor(x => x.GroupNumber)
                    .NotEmpty().WithMessage("ჯგუფის ნომერი ცარიელია")
                      .Length(1, 8).WithMessage("ჯგუფის ნომერი უნდა შეიცავდეს მინიმუმ 1 და მაქსიმუმ 8 სიმბოლოს," +
                                  " უნდა შეიცავდეს მხოლოდ ქართულ ან ლათინურ ასოებს");
         
            }         
        }
    }
}

