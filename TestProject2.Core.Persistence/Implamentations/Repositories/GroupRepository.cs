using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Infrastructure.Persistence.Implamentations.Repositories
{
    internal class GroupRepository : Repository<SchoolGroup>, IGroupRepository
    {
        public GroupRepository(DataContext context) : base(context) { }      
        public async Task<List<SchoolGroup>> GroupFilterAsync(string groupNumber = null)
        {
            var groupsQuery = _context.Groups.Where(x =>
                 (groupNumber == null || x.GroupNumber == groupNumber));
            var items = groupsQuery.ToList();
            return items;
        }

          

    }
}
