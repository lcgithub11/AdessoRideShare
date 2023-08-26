using AdessoRideShare.TravelPlanService.Application.DTOs;
using AdessoRideShare.TravelPlanService.Application.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoRideShare.TravelPlanService.Application.QueryHandlers
{
    public class SearchTravelPlansQueryHandler : IRequestHandler<SearchTravelPlansQuery, List<TravelPlanDto>>
    {
        public Task<List<TravelPlanDto>> Handle(SearchTravelPlansQuery request, CancellationToken cancellationToken)
        {
            var travelPlans = new List<TravelPlanDto>();
            return Task.FromResult(travelPlans);
        }
    }
}
