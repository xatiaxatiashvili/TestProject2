using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Domain.Entities;
using TestProject2.Infrastructure.Persistence.Configurations;

namespace TestProject2.Infrastructure.Persistence
{
    internal class DataContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<SchoolGroup> Groups { get; set; }
       
        public DataContext(DbContextOptions options)
          : base(options)
        {}

            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
    }
  
}
