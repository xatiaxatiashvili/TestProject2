using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Domain.Entities;

namespace TestProject2.Infrastructure.Persistence.Configurations
{

        internal class GroupConfiguration : IEntityTypeConfiguration<SchoolGroup>
        {
            public void Configure(EntityTypeBuilder<SchoolGroup> builder)
            {
            builder.Property(x => x.GroupName).HasMaxLength(100).IsRequired();          
            builder.Property(x => x.GroupNumber).HasMaxLength(200).IsRequired();      
    }
        
    }
}
