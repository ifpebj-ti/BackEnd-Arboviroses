using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class InvalidUserPassword : Exception
    {
        public InvalidUserPassword(): base("Hash da senha do usário inválida")
        {

        }
    }
}
