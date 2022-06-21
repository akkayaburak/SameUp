using Application.Core.Machines;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MachinesController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> CreateMachine(Machine machine)
        {
            return HandleResult(await Mediator.Send(new Create.Command{Machine = machine}));
        }

        [HttpGet]
        public async Task<ActionResult> GetMachines()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMachine(int id)
        {
            return HandleResult(await Mediator.Send(new Detail.Query{Id = id}));
        }
    }
}