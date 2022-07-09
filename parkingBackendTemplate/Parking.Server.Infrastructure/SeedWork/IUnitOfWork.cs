using Parking.Server.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAuditLogRepository AuditLog { get; }
        IParkingLotBasicInfoRepository ParkingLotBasicInfo { get; }
        IParkingTicketInfoRepository ParkingTicketInfo { get; }
        IParkingTicketUseDiscountRepository ParkingTicketUseDiscountRepository { get; }

        Task<int> CommitAsync();
    }
}
