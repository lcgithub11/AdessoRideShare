using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdessoRideShare.TravelPlanService.Domain.Entities;

namespace AdessoRideShare.TravelPlanService.Persistence.Context
{
    public interface IApplicationDbContext
    {
        DbSet<TravelPlan> TravelPlans { get; set; }
        DbSet<Location> Locations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
