using AdessoRideShare.TravelPlanService.Application.Commands;
using AdessoRideShare.TravelPlanService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdessoRideShare.TravelPlanService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        [HttpPost("add")]
        public async Task<IActionResult> AddTravelPlan([FromBody] CreateTravelPlanCommand command)
        {
            var result = await _mediator.Send(command);
            if (result != Guid.Empty)
                return CreatedAtAction(nameof(GetTravelPlan), new { planId = result }, null);
            else
                return BadRequest("Failed to add travel plan.");
        }

        [HttpPost("publish/{planId}")]
        public async Task<IActionResult> PublishTravelPlan(Guid planId)
        {
            var command = new PublishTravelPlanCommand { TravelPlanId = planId };
            var result = await _mediator.Send(command);
            if (!result)
                return NoContent();
            else
                return BadRequest("Failed to publish travel plan.");
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTravelPlans(string fromCity, string toCity)
        {
            var query = new SearchTravelPlansQuery { FromCity = fromCity, ToCity = toCity };
            var travelPlans = await _mediator.Send(query);

            if (travelPlans != null && travelPlans.Count > 0)
                return Ok(travelPlans);
            else
                return NotFound("No travel plans found.");
        }


        [HttpGet("{planId}")]
        public async Task<IActionResult> GetTravelPlan(Guid planId)
        {
            var query = new GetTravelPlanQuery { TravelPlanId = planId };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                if (result.Id == Guid.Empty)
                    return NotFound("Travel plan not found.");

                return Ok(result);
            }
            else
                return BadRequest("Failed to get travel plan.");
        }



        [HttpGet]
        public async Task<IActionResult> ListTravelPlans()
        {
            var query = new ListTravelPlansQuery();
            var result = await _mediator.Send(query);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Failed to list travel plans.");
        }
    }
}
