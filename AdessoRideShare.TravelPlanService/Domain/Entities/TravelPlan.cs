namespace AdessoRideShare.TravelPlanService.Domain.Entities
{
    public class TravelPlan
    {
        public Guid Id { get; set; }
        public string StartingLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string Description { get; set; }
        public DateTime TravelDate { get; set; }
        public int AvailableSeats { get; set; }
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

        public TravelPlan(string startingLocation, string destinationLocation, DateTime travelDate, int availableSeats,string descrpition)
        {
            Id = Guid.NewGuid();
            StartingLocation = startingLocation;
            DestinationLocation = destinationLocation;
            TravelDate = travelDate;
            Description = descrpition;
            AvailableSeats = availableSeats;
        }

        public void UpdateTravelPlanDetails(string startingLocation, string destinationLocation, DateTime travelDate,string description,
            int availableSeats)
        {
            StartingLocation = startingLocation;
            DestinationLocation = destinationLocation;
            TravelDate = travelDate;
            Description = description;
            AvailableSeats = availableSeats;
        }

        public void Publish()
        {
        }
    }

    public class Passenger
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
