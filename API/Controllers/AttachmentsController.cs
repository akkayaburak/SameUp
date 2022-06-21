using Application.Attachments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class AttachmentsController : BaseApiController
    {
        [HttpGet("{machineTypeId}")]
        public async Task<ActionResult> GetMachineTypes(int machineTypeId)
        {
            return HandleResult(await Mediator.Send(new List.Query{machineTypeId = machineTypeId}));
        }
    }
}