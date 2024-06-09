using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class ProfileAlreadyExistException : Exception
    {
        public ProfileAlreadyExistException() : base("Perfil já existe") 
        { 

        }
    }
}
