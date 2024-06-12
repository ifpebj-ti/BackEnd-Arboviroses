using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class InvalidUserUpdatePassword : Exception
    {
        public InvalidUserUpdatePassword() : base("Error ao alterar senha do usuário")
        {

        }
    }
}
