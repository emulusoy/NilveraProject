using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NilveraProject.Application.DTO;

namespace NilveraProject.Application.Features.Customers.Queries
{
    public record GetAllCustomersQuery(): IRequest<List<CustomerDto>>
    {
        //record kullanimini aldigim caselerde istenilen bir seyde ogrendim tek bir satirda veri tasiyan nesne olusturur!
        //bu degerler recordda degistirilemiyor.
    }
}
