using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Application.DTOs;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Infrastructure.Persistence.Implamentations
{
    internal class PersonRepository:Repository<Person>,IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context) { }
        private IQueryable<Person> Including =>
            _context.Persons.Include(x => x.Group);
        public async Task<List<Person>> FilterAsync(string firstName = null, string lastName = null, string personalNumber = null, DateTime? birthDate = null)
        {
            var persons = this.Including.Where(x =>
             (firstName == null || x.FirstName == firstName) &&
              (lastName == null || x.LastName == lastName) &&
              (personalNumber == null || x.PersonalNumber == personalNumber) &&             
             (birthDate == null || x.BirthDate == birthDate)
          );           
            var items = persons.ToList();
            return items;
        }
        public override async Task<Person> ReadAsync(Guid id)
        {
            return await this.Including.FirstOrDefaultAsync(x => x.Id == id);
        }
        
    }
}

