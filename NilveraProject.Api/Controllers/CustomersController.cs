using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NilveraProject.Application.Features.Customers.Commands;
using NilveraProject.Application.Features.Customers.Queries;

namespace NilveraProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
          => Ok(await mediator.Send(new GetAllCustomersQuery()));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var val = await mediator.Send(new GetCustomerByIdQuery(id));
            return val is null ? NotFound() : Ok(val);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand cmd)
        {
            var newId = await mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { id = newId });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand body)
        {
            var cmd = body with { Id = id }; 
            var ok = await mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await mediator.Send(new RemoveCustomerCommand(id));
            return ok ? NoContent() : NotFound();
        }
    }
}
