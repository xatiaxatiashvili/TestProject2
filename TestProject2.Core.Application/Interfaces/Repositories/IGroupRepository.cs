using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Core.Application.Interfaces.Repositories
{
    public interface IGroupRepository : IRepository<Guid, SchoolGroup>
    {
        Task<List<SchoolGroup>> GroupFilterAsync(string groupNumber = null);

        
    }
    
}
