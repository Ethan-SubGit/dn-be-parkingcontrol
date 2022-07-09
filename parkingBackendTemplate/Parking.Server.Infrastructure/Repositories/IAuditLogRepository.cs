using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public interface IAuditLogRepository : IRepository<TAuditLog>
    {
        Task<IEnumerable<TAuditLog>> GetAllWithAsync();
        Task<TAuditLog> GetWithAuditLogByIdAsync(int aidx);
        Task<IEnumerable<TAuditLog>> GetAllWithAuditLogAsync(string userId);
    }
}
