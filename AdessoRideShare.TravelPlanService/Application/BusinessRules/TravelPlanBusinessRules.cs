using AdessoRideShare.TravelPlanService.Domain.Entities;
using FluentValidation;

namespace AdessoRideShare.TravelPlanService.Application
{
    public class TravelPlanBusinessRules : AbstractValidator<TravelPlan>
    {
        public TravelPlanBusinessRules()
        {
            RuleFor(x => x.StartingLocation)
                .NotEmpty().WithMessage("Starting location is required.");

            RuleFor(x => x.DestinationLocation)
                .NotEmpty().WithMessage("Destination location is required.")
                .NotEqual(x => x.StartingLocation).WithMessage("Destination location cannot be the same as starting location.");

            RuleFor(x => x.TravelDate)
                .GreaterThan(DateTime.Now).WithMessage("Travel date must be in the future.")
                .LessThan(DateTime.Now.AddYears(1)).WithMessage("Travel date must be within the next year.");

            RuleFor(x => x.AvailableSeats)
                .GreaterThan(0).WithMessage("Number of available seats must be greater than 0.");
        }
    }
}
