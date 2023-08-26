using MediatR;
using System;

namespace AdessoRideShare.TravelPlanService.Application.Commands
{
    public class UpdateTravelPlanCommand : IRequest<bool>
    {
        public Guid TravelPlanId { get; set; }
        public string StartingLocation { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime TravelDate { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
    }
}
