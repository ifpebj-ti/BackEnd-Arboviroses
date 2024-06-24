using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Exceptions
{
    public class InvalidEditInfoHomeException : Exception
    {
        public InvalidEditInfoHomeException() : base("Erro na edição de informações da home")
        {
        }
    }
}
