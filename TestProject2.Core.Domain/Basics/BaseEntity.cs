using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.Core.Domain.Basics
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; init; }
    }
}
