using MediatR;
using System;

namespace AdessoRideShare.TravelPlanService.Application.Commands
{
    public class CreateTravelPlanCommand : IRequest<Guid>
    {
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public DateTime TravelDate { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
    }
}
