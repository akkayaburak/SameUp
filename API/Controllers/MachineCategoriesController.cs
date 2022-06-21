using Application.MachineCategories;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MachineCategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetMachineCategories()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachineCategory(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }
    }
}