using System;
using TestProject2.Core.Domain.Basics;
using TestProject2.Core.Domain.Enums;

namespace TestProject2.Core.Domain.Entities
{
    public class Person:BaseEntity
    {       
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PersonalNumber { get; private init; }
        public DateTime BirthDate { get; private set; }
        public string Mail { get; set; }
        public Status Status { get; set; }
        public Guid? GroupId { get; set; }
        public SchoolGroup Group { get; set; }

    }
}
