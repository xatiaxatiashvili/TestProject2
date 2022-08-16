using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Core.Application.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Guid, Person>    {

        Task<List<Person>> FilterAsync(string firstName = null, string lastName = null, string personalNumber = null,  DateTime? birthDate = null);
   
    }
}
