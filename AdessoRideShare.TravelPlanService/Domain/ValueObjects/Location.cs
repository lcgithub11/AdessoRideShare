using System;

namespace AdessoRideShare.TravelPlanService.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
