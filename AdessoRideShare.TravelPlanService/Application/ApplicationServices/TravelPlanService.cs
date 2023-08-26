using AdessoRideShare.TravelPlanService.Application.Commands;
using AdessoRideShare.TravelPlanService.Domain.Entities;
using AdessoRideShare.TravelPlanService.Persistence.Repositories;

namespace AdessoRideShare.TravelPlanService.Application.ApplicationServices
{
    public class TravelPlanService
    {
        private readonly ITravelPlanRepository _travelPlanRepository;

        public TravelPlanService(ITravelPlanRepository travelPlanRepository)
        {
            _travelPlanRepository = travelPlanRepository;
        }

        public async Task<TravelPlan> AddTravelPlanAsync(TravelPlan travelPlan)
        {
            return await _travelPlanRepository.AddAsync(travelPlan);
        }

        public async Task PublishTravelPlanAsync(Guid travelPlanId)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(travelPlanId);
            if (travelPlan != null)
            {
                travelPlan.Publish();
                await _travelPlanRepository.UpdateAsync(travelPlan);
            }
        }

        public async Task<bool> UpdateTravelPlanAsync(UpdateTravelPlanCommand command)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(command.TravelPlanId);
            if (travelPlan == null)
                return false; // Travel plan not found

            travelPlan.UpdateTravelPlanDetails(
                command.StartingLocation,
                command.DestinationLocation,
                command.TravelDate,
                command.Description,
                command.AvailableSeats);

            await _travelPlanRepository.UpdateAsync(travelPlan);

            return true;
        }

        public async Task<bool> DeleteTravelPlanAsync(Guid travelPlanId)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(travelPlanId);
            if (travelPlan == null)
            {
                return false; // Travel plan not found
            }

            await _travelPlanRepository.RemoveAsync(travelPlan);

            return true;
        }
    }
}
