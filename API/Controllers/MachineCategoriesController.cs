using Application.MachineCategories;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MachineCategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<MachineCategory>>> GetMachineCategories()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MachineCategory>> GetMachineCategory(int id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
    }
}