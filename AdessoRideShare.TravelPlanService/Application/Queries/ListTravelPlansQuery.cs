using MediatR;
using System.Collections.Generic;
using AdessoRideShare.TravelPlanService.Application.DTOs;

namespace AdessoRideShare.TravelPlanService.Application.Queries
{
    public class ListTravelPlansQuery : IRequest<IEnumerable<TravelPlanDto>>
    {

    }
}
