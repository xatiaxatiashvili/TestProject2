using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CreatePersonCommand
    {
        public class Request : IRequest<Guid>
        {
         
            [Required]
            [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "პირადი ნომერი უნდა შედგებოდეს 11 სიმბოლოსგან")]
            public string PersonalNumber { get; set; }

            [Required]
            public string FirstName { get; set; }     
            public string LastName { get; set; }
            public ICollection<Status> Status { get; set; }         
            public DateTime BirthDate { get; set; }
            public string Mail { get; set; }
            public Guid? GroupId { get; set; }
            public Request()
            {
                this.Status = new HashSet<Status>();
            }
        }

        public class Handler : IRequestHandler<Request, Guid>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;
         
            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;            
                _mapper = mapper;
            }
            public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
            {
                var person = _mapper.Map<Person>(request);             
                cancellationToken.ThrowIfCancellationRequested();               
                await _unit.PersonRepository.CreateAsync(person);
                return person.Id;
            }
        }
        public class Validator : AbstractValidator<Request>
        {
            private readonly IUnitOfWork _unit;

            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(x => x.PersonalNumber)
                    .NotNull().WithMessage("პირადი ნომერი ცარიელია")
                    //.Length(11).WithMessage("პირადი ნომერი უნდა შედგებოდეს 11 სიმბოლოსგან")
                    .Matches("^[0-9]*$").WithMessage("პირადი ნომერი უნდა შედგებოდეს მხოლოდ ციფრებისგან");

                RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("სახელის ველი ცარიელია");

                RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("გვარის ველი ცარიელია");

                RuleForEach(x => x.Status).IsInEnum().WithMessage("მიუთითეთ სტატუსი სწორად");
              
                RuleFor(x => x.Mail)            
                    .NotEmpty().WithMessage("ელ-ფოსტის ველი ცარიელია");

                RuleFor(x => x.BirthDate)
                    .Must(y => DateTime.Compare(y, DateTime.Now) < 0 ? true : false).WithMessage("მიუთითეთ დაბადების თარიღი სწორად");

            }

     
        }


}
}
