namespace AdessoRideShare.TravelPlanService.Application.DTOs
{
    public class TravelPlanDto
    {
        public Guid Id { get; set; }
        public LocationDto DepartureLocation { get; set; }
        public LocationDto DestinationLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsActive { get; set; }
    }
}
