using AdessoRideShare.TravelPlanService.Application.Commands;
using AdessoRideShare.TravelPlanService.Domain.Entities;
using AdessoRideShare.TravelPlanService.Persistence.Context;
using AdessoRideShare.TravelPlanService.Persistence.Repositories;
using MediatR;

namespace AdessoRideShare.TravelPlanService.Application
{
    public class CreateTravelPlanCommandHandler : IRequestHandler<CreateTravelPlanCommand, Guid>
    {
        private readonly ITravelPlanRepository _travelPlanRepository;
        private readonly ApplicationDbContext _dbContext;

        public CreateTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository, ApplicationDbContext dbContext)
        {
            _travelPlanRepository = travelPlanRepository;
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateTravelPlanCommand request, CancellationToken cancellationToken)
        {
            var travelPlan = new TravelPlan(request.LocationFrom, request.LocationTo, request.TravelDate, request.AvailableSeats,request.Description);
            await _travelPlanRepository.AddAsync(travelPlan);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return travelPlan.Id;
        }
    }
}
