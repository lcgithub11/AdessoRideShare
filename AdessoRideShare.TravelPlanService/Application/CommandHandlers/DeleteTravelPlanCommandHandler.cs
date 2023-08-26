using AdessoRideShare.TravelPlanService.Application.Commands;
using AdessoRideShare.TravelPlanService.Persistence.Context;
using AdessoRideShare.TravelPlanService.Persistence.Repositories;
using MediatR;

namespace AdessoRideShare.TravelPlanService.Application.CommandHandlers
{
    public class DeleteTravelPlanCommandHandler : IRequestHandler<DeleteTravelPlanCommand, bool>
    {
        private readonly ITravelPlanRepository _travelPlanRepository;
        private readonly ApplicationDbContext _dbContext;

        public DeleteTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository, ApplicationDbContext dbContext)
        {
            _travelPlanRepository = travelPlanRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTravelPlanCommand request, CancellationToken cancellationToken)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(request.TravelPlanId);
            if (travelPlan == null)
            {
                return false;
            }

            await _travelPlanRepository.RemoveAsync(travelPlan);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
