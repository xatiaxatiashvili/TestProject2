using System;
using System.Collections.Generic;

namespace TestProject2.Core.Application.DTOs
{
    public class GetGroupDto
    {
        public Guid Id { get; set; } 
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }

    }
}
