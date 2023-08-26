using AdessoRideShare.TravelPlanService.Application.CommandHandlers;
using AdessoRideShare.TravelPlanService.Application.Commands;
using AdessoRideShare.TravelPlanService.Application.DTOs;
using AdessoRideShare.TravelPlanService.Application.Queries;
using AdessoRideShare.TravelPlanService.Application.QueryHandlers;
using MediatR;

namespace AdessoRideShare.TravelPlanService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Register command handlers
            services.AddTransient<IRequestHandler<CreateTravelPlanCommand, Guid>, CreateTravelPlanCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTravelPlanCommand, bool>, DeleteTravelPlanCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateTravelPlanCommand, bool>, UpdateTravelPlanCommandHandler>();

            // Register query handlers
            services.AddTransient<IRequestHandler<SearchTravelPlansQuery, List<TravelPlanDto>>, SearchTravelPlansQueryHandler>();
            services.AddTransient<IRequestHandler<GetTravelPlanQuery, TravelPlanDto>, GetTravelPlanQueryHandler>();
            services.AddTransient<IRequestHandler<ListTravelPlansQuery, IEnumerable<TravelPlanDto>>, ListTravelPlansQueryHandler>();

        }
    }
}
