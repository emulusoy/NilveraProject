using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using NilveraProject.Application.Abstractions;
using NilveraProject.Application.Features.Customers.Commands;
using NilveraProject.Domain.Entities;

namespace NilveraProject.Application.Features.Customers.Handlers
{
    public class CreateCustomerCommandHandler(ICustomerRepository repo)
    : IRequestHandler<CreateCustomerCommand, int>
    {
        public async Task<int> Handle(CreateCustomerCommand req, CancellationToken ct)
        {
            if (!string.IsNullOrWhiteSpace(req.JsonData))
            {
                try { JsonDocument.Parse(req.JsonData); }
                catch (JsonException) { throw new ArgumentException("Geçersiz JSON verisi.", nameof(req.JsonData)); }
            }
            var customer = new Customer
            {
                Name = req.Name,
                Surname = req.Surname,
                Email = req.Email,
                Phone = req.Phone,
                Address = req.Address,
                JsonData = req.JsonData
            };

            return await repo.InsertAsync(customer);
        }
    }
}
