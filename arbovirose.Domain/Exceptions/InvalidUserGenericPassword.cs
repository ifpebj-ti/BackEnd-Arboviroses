using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Exceptions
{
    public class InvalidUserGenericPassword : Exception
    {
        public InvalidUserGenericPassword() : base("Senha padrão do usuário inválida")
        {

        }
    }
}
