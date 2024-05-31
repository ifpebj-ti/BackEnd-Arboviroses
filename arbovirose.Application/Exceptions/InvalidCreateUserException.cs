using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class InvalidCreateUserException : Exception
    {
        public InvalidCreateUserException() : base("Não foi possível criar um usuário")
        {

        }
    }
}
