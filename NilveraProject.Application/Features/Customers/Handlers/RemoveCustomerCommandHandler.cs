using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NilveraProject.Application.Abstractions;
using NilveraProject.Application.Features.Customers.Commands;

namespace NilveraProject.Application.Features.Customers.Handlers
{
    public class RemoveCustomerCommandHandler(ICustomerRepository repo) : IRequestHandler<RemoveCustomerCommand, bool>
    {
        public Task<bool> Handle(RemoveCustomerCommand cmd, CancellationToken ct)
        => repo.DeleteAsync(cmd.Id);
    }
}
