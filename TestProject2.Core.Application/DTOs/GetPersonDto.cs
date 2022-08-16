using System;

namespace TestProject2.Core.Application.DTOs
{
    public class GetPersonDto
    {
        public Guid Id { get; set; }      
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PersonalNumber { get; private init; }
        public DateTime BirthDate { get; private set; }
        public string Mail { get; set; }
        public string PersonStatus { get; set; } 
        public Guid GroupId { get; set; }

    }
}
