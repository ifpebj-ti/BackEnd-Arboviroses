using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Exceptions
{
    public class InvalidTypeInfoException : Exception
    {
        public InvalidTypeInfoException() : base("Tipo de informação inválida")
        {

        }
    }
}
