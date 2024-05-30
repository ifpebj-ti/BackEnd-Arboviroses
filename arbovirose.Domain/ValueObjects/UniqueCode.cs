using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.ValueObjects
{
    public class UniqueCode
    {
        public string value { get; set; } = "";
        public UniqueCode() { 
            this.value = GenerateUniqueCode();
        }
        public string GenerateUniqueCode()
        {
            var code = Guid.NewGuid();
            return code.ToString();
        }
    }
}
