using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.Core.Application.Exceptions
{
    public abstract class ApplicationBaseException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public ApplicationBaseException(string message) : base(message) { } 
    }
}
