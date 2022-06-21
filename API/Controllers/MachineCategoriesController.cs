using Application.MachineCategories;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MachineCategoriesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public MachineCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MachineCategory>>> GetMachineCategories()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MachineCategory>>> GetMachineCategory(int id)
        {
            return Ok();
        }
    }
}