using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Dtos.InfoHome
{
    public class DeleteInfoHomeDTO
    {
        public Guid Id { get; set; }
        public string? TypeFile { get; set; }
        public string? OriginalFileName { get; set; }
    }
}
