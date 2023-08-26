using AdessoRideShare.TravelPlanService.Application.DTOs;
using AdessoRideShare.TravelPlanService.Application.Queries;
using AdessoRideShare.TravelPlanService.Persistence.Repositories;
using AutoMapper;
using MediatR;

namespace AdessoRideShare.TravelPlanService.Application.QueryHandlers
{
    public class GetTravelPlanQueryHandler : IRequestHandler<GetTravelPlanQuery, TravelPlanDto>
    {
        private readonly ITravelPlanRepository _travelPlanRepository;
        private readonly IMapper _mapper;

        public GetTravelPlanQueryHandler(ITravelPlanRepository travelPlanRepository, IMapper mapper)
        {
            _travelPlanRepository = travelPlanRepository;
            _mapper = mapper;
        }

        public async Task<TravelPlanDto> Handle(GetTravelPlanQuery request, CancellationToken cancellationToken)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(request.TravelPlanId);
            var travelPlanDto = _mapper.Map<TravelPlanDto>(travelPlan);
            return travelPlanDto;
        }
    }
}
