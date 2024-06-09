using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Exceptions
{
    public class InvalidCreateProfileException : Exception
    {
        public InvalidCreateProfileException() : base("Erro ao criar perfil") 
        { 

        }
    }
}
