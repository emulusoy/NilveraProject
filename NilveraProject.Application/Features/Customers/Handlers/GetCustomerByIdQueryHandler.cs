using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using NilveraProject.Application.Abstractions;
using NilveraProject.Application.DTO;
using NilveraProject.Application.Features.Customers.Queries;
using NilveraProject.Domain.Entities;

namespace NilveraProject.Application.Features.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler(ICustomerRepository repo)
    : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private static readonly JsonSerializerOptions _json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken ct)
        {
            var c = await repo.GetByIdAsync(request.Id);
            if (c is null) return null;

            CustomerExtra? extra = null;
            if (!string.IsNullOrWhiteSpace(c.JsonData))
            {
                try { extra = JsonSerializer.Deserialize<CustomerExtra>(c.JsonData, _json); } catch { }
            }

            return new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                Extra = extra
            };
        }
    }
}
