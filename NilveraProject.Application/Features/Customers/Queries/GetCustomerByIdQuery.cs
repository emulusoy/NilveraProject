using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NilveraProject.Application.DTO;
using NilveraProject.Domain.Entities;

namespace NilveraProject.Application.Features.Customers.Queries
{
    public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto?>
    {
    }
}
