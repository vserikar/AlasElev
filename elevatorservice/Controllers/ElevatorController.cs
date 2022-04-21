using elevatorservice.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace elevatorservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        
        

        [Route("{id}/nextstop")]
        [ProducesResponseType(typeof(int), 200)]
        [HttpGet]
        public ActionResult GetNextStop([FromServices] IDataRepository dataRepository, byte id)
        {
            var nextStop = dataRepository.getNextMove(id);
            
            return this.Ok(nextStop);
        }

        [Route("{id}/allstops")]
        [ProducesResponseType(typeof(int), 200)]
        [HttpGet]
        public ActionResult getAllStops([FromServices] IDataRepository dataRepository, byte id)
        {
            var allStops = dataRepository.getPendingQueue(id);

            return this.Ok(allStops);
        }

        [Route("{id}/request")]
        [ProducesResponseType(200)]
        [HttpPut]
        public ActionResult updateElevatorQueu([FromServices] IDataRepository dataRepository, byte id, sbyte floorNumber)
        {
            dataRepository.updatePendingState(id, floorNumber);

            return this.Ok();
        }
    }
}
