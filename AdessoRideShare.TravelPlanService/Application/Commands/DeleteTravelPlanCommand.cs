using MediatR;
using System;

namespace AdessoRideShare.TravelPlanService.Application.Commands
{
    public class DeleteTravelPlanCommand : IRequest<bool>
    {
        public Guid TravelPlanId { get; set; }
    }
}
