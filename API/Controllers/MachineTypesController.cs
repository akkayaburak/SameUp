using Application.Core.MachineTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MachineTypesController : BaseApiController
    {
        [HttpGet("{categoryId}")]
        public async Task<ActionResult> GetMachineTypes(int categoryId)
        {
            return HandleResult(await Mediator.Send(new List.Query{categoryId = categoryId}));
        }
    }
}