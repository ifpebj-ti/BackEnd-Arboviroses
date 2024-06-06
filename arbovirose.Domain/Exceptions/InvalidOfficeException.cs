using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Exceptions
{
    public class InvalidOfficeException : Exception
    {
        public InvalidOfficeException() : base("Cargo inválido")
        {
            
        }
    }
}
