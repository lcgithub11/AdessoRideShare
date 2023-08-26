using AdessoRideShare.TravelPlanService.Application.Commands;
using AdessoRideShare.TravelPlanService.Domain.Entities;
using AdessoRideShare.TravelPlanService.Persistence.Context;
using AdessoRideShare.TravelPlanService.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShare.TravelPlanService.Application
{
    public class UpdateTravelPlanCommandHandler : IRequestHandler<UpdateTravelPlanCommand, bool>
    {
        private readonly ITravelPlanRepository _travelPlanRepository;
        private readonly ApplicationDbContext _dbContext;

        public UpdateTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository, ApplicationDbContext dbContext)
        {
            _travelPlanRepository = travelPlanRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateTravelPlanCommand request, CancellationToken cancellationToken)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(request.TravelPlanId);
            if (travelPlan == null)
            {
                return false; // Travel plan not found
            }

            travelPlan.TravelDate = request.TravelDate;
            travelPlan.DestinationLocation = request.DestinationLocation;
            travelPlan.StartingLocation = request.StartingLocation;
            travelPlan.AvailableSeats = request.AvailableSeats;

            await _travelPlanRepository.UpdateAsync(travelPlan);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
