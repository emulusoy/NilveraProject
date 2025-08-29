using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NilveraProject.Domain.Entities;

namespace NilveraProject.Application.DTO
{
    public class CustomerDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Surname { get; init; } = null!;
        public string? Email { get; init; }
        public string? Phone { get; init; }
        public string? Address { get; init; }
        public CustomerExtra? Extra { get; init; }
    }
}
