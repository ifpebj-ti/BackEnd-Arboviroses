using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException() : base("Usuário já existe")
        {

        }
    }
}
