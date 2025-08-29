using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NilveraProject.Application.Features.Customers.Commands
{
    public record RemoveCustomerCommand(int Id):IRequest<bool>
    {
    }
}
