using AutoMapper;
using System;
using System.Collections.Generic;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Features.Group.Commands;
using TestProject2.Core.Application.Features.Organizations.Commands;
using TestProject2.Core.Application.Features.Persons.Commands;
using TestProject2.Core.Domain.Entities;
using TestProject2.Core.Domain.Enums;

namespace TestProject2.Core.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, GetPersonDto>()
                .ForMember(dest => dest.PersonStatus, opt => opt.MapFrom(src => src.Status));            

            

            CreateMap<CreatePersonCommand.Request, Person>()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusesToStatus(src.Status)));
         

            CreateMap<UpdatePersonCommand.Request, Person>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusesToStatus(src.Statuses)));

            CreateMap<DeletePersonInGroupCommand.Request, Person>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId))            
             .ForMember(x => x.GroupId, opt => opt.MapFrom(o => Guid.Empty));


            CreateMap<SchoolGroup, GetGroupDto>();

            CreateMap<CreateGroupCommand.Request, SchoolGroup>();
            CreateMap<UpdateGroupCommand.Request, SchoolGroup>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GroupId));
            


        }
        private Status StatusesToStatus(ICollection<Status> statuses)
        {
            Status status = Status.None;
            foreach (var item in statuses)
                status |= item;
            return status;
        }
    }
}
