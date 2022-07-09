using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Server.Infrastructure.Repositories
{
    public class ParkingTicketUseDiscountRepository : Repository<TParkingTicketUseDiscount>, IParkingTicketUseDiscountRepository
    {
        public ParkingTicketUseDiscountRepository(ParkingIntegratedControlCenterContext context) : base(context) { }
    }
}
