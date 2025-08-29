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
    public class GetAllCustomersQueryHandler(ICustomerRepository repo)
    : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private static readonly JsonSerializerOptions _json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken ct)
        {
            var list = await repo.GetAllAsync();
            var result = new List<CustomerDto>();

            foreach (var c in list)
            {
                CustomerExtra? extra = null;
                if (!string.IsNullOrWhiteSpace(c.JsonData))
                {
                    try { extra = JsonSerializer.Deserialize<CustomerExtra>(c.JsonData, _json); }
                    catch (JsonException) { }
                }

                result.Add(new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address,
                    Extra = extra
                });
            }
            return result;
        }
    }
}