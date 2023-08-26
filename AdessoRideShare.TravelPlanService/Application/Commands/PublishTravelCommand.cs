using MediatR;
using System;

namespace AdessoRideShare.TravelPlanService.Application.Commands
{
    public class PublishTravelPlanCommand : IRequest<bool>
    {
        public Guid TravelPlanId { get; set; }
    }
}
