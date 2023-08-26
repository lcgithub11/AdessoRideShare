using AdessoRideShare.TravelPlanService.Domain.Entities;
using AdessoRideShare.TravelPlanService.Persistence.Context;
using AdessoRideShare.Infrastructure.Domain;

namespace AdessoRideShare.TravelPlanService.Persistence.Repositories
{
    public class TravelPlanRepository : GenericRepository<TravelPlan, ApplicationDbContext>, ITravelPlanRepository
    {
        public TravelPlanRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
