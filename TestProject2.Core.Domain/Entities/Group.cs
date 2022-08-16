using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Domain.Basics;

namespace TestProject2.Core.Domain.Entities
{
    public class SchoolGroup : BaseEntity
    {
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }     

    }
}
