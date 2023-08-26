using MediatR;
using AdessoRideShare.TravelPlanService.Application.DTOs;

namespace AdessoRideShare.TravelPlanService.Application.Queries
{
    public class GetTravelPlanQuery : IRequest<TravelPlanDto>
    {
        public Guid TravelPlanId { get; set; }
    }
}
