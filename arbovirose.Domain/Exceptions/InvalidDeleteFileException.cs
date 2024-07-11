using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Exceptions
{
    public class InvalidDeleteFileException : Exception
    {
        public InvalidDeleteFileException() : base("Erro ao deletar arquivo")
        {
        }
    }
}
