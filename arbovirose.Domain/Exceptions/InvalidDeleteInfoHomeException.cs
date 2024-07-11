using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Exceptions
{
    public class InvalidDeleteInfoHomeException : Exception
    {
        public InvalidDeleteInfoHomeException() : base("Erro ao deletar informações da home")
        {
        }
    }
}
