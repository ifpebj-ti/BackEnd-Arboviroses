using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class InvalidUserUniqueCode : Exception
    {
        public InvalidUserUniqueCode() : base("Código de acesso inválido")
        {

        }
    }
}
