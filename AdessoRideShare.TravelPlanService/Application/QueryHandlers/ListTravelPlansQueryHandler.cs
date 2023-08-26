using AdessoRideShare.TravelPlanService.Application.DTOs;
using AdessoRideShare.TravelPlanService.Application.Queries;
using AdessoRideShare.TravelPlanService.Persistence.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.TravelPlanService.Application.QueryHandlers
{
    public class ListTravelPlansQueryHandler : IRequestHandler<ListTravelPlansQuery, IEnumerable<TravelPlanDto>>
    {
        private readonly ITravelPlanRepository _travelPlanRepository;

        public ListTravelPlansQueryHandler(ITravelPlanRepository travelPlanRepository)
        {
            _travelPlanRepository = travelPlanRepository;
        }

        public async Task<IEnumerable<TravelPlanDto>> Handle(ListTravelPlansQuery request, CancellationToken cancellationToken)
        {
            var travelPlans = await _travelPlanRepository.GetAllAsync();

            var travelPlanDtos = new List<TravelPlanDto>();
            foreach (var travelPlan in travelPlans)
            {
                travelPlanDtos.Add(new TravelPlanDto
                {
                    Id = travelPlan.Id,
                    DepartureLocation = new LocationDto
                    {
                    },
                    DestinationLocation = new LocationDto
                    {
                    },
                    DepartureTime = travelPlan.TravelDate,
                    Description = travelPlan.Description,
                    AvailableSeats = travelPlan.AvailableSeats,
                    IsActive = true
                });
            }

            return travelPlanDtos;
        }
    }
}
