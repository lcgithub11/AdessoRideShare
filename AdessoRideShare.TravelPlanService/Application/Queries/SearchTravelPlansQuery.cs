using AdessoRideShare.TravelPlanService.Application.DTOs;
using MediatR;

namespace AdessoRideShare.TravelPlanService.Application.Queries
{
    public class SearchTravelPlansQuery : IRequest<List<TravelPlanDto>>
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
    }

    public class SearchTravelPlanDto
    {
        public Guid Id { get; set; }
        public string StartingLocation { get; set; }
        public string DestinationLocation { get; set; }
    }
}
