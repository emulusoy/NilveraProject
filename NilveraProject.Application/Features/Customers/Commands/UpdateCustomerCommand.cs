using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NilveraProject.Application.Features.Customers.Commands
{
    public record UpdateCustomerCommand(int Id,string Name,string Surname,string? Email,string? Phone,string? Address,string? JsonData) : IRequest<bool>
    {
    }
}
