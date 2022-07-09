using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingIntegratedControlCenterContext _context;
        private AuditLogRepository _auditLogRepository;
        private ParkingLotBasicInfoRepository _parkingLotBasicInfoRepository;
        private ParkingTicketInfoRepository _parkingTicketInfoRepository;
        private ParkingTicketUseDiscountRepository _parkingTicketUseDiscountRepository;

        public IAuditLogRepository AuditLog => _auditLogRepository = _auditLogRepository ?? new AuditLogRepository(_context);
        public IParkingLotBasicInfoRepository ParkingLotBasicInfo => _parkingLotBasicInfoRepository = _parkingLotBasicInfoRepository ?? new ParkingLotBasicInfoRepository(_context);
        public IParkingTicketInfoRepository ParkingTicketInfo => _parkingTicketInfoRepository = _parkingTicketInfoRepository ?? new ParkingTicketInfoRepository(_context);
        //public IParkingTicketUseDiscountRepository ParkingTicketUseDiscount => _parkingTicketUseDiscountRepository = _parkingTicketUseDiscountRepository ?? new ParkingTicketUseDiscountRepository(_context);

        public IParkingTicketUseDiscountRepository ParkingTicketUseDiscountRepository => _parkingTicketUseDiscountRepository = _parkingTicketUseDiscountRepository ?? new ParkingTicketUseDiscountRepository(_context);

        public UnitOfWork(ParkingIntegratedControlCenterContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
