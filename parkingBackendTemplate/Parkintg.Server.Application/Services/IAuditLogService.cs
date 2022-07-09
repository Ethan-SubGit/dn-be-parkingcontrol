using Parking.Server.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parkintg.Server.Application.Services
{
    public interface IAuditLogService
    {
        Task<TAuditLog> GetAuditLogById(int aIdx);
        Task<TAuditLog> CreateAuditLog(TAuditLog newAuditLog);
        Task<IEnumerable<TAuditLog>> GetUserAuditLog(string userId);

    }
}
