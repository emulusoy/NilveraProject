using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilveraProject.Domain.Entities
{
    public class CustomerExtra
    {
        public string? Note { get; set; }
        public string? TaxNo { get; set; }
        public string[]? Tags { get; set; }
    }
}
