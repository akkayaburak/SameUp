using Application.Core.MachineBrands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MachineBrandsController : BaseApiController
    {
        [HttpGet("{categoryId}")]
        public async Task<ActionResult> GetMachineBrands(int categoryId)
        {
            return HandleResult(await Mediator.Send(new List.Query{categoryId = categoryId}));
        }
    }
}