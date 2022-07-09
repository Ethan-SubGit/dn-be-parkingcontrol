using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public class AuditLogRepository : Repository<TAuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(ParkingIntegratedControlCenterContext context) : base(context) { }


        public async Task<IEnumerable<TAuditLog>> GetAllWithAsync()
        {
            return await Context.TAuditLogs
                        .Take(10)
                        .OrderBy(p => p.AIdx)
                        .ToListAsync();
        }

        public async Task<IEnumerable<TAuditLog>> GetAllWithAuditLogAsync(string userId)
        {
            //return await context.TAuditLogs.Where(p => p.UserId == userId)
            //            .ToListAsync();

            return await context.Set<TAuditLog>().Where(p => p.EmpId == userId).ToListAsync();
        }

        public async Task<TAuditLog> GetWithAuditLogByIdAsync(int aidx)
        {
            return await Context.TAuditLogs.Where(p => p.AIdx == aidx)
                        .SingleOrDefaultAsync();
        }

        private ParkingIntegratedControlCenterContext Context
        {
            get { return Context as ParkingIntegratedControlCenterContext; }
        }
    }
}
