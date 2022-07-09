using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public class ParkingTicketInfoRepository : Repository<TParkingTicketInfo>, IParkingTicketInfoRepository
    {
        public ParkingTicketInfoRepository(ParkingIntegratedControlCenterContext context) : base(context) { }

        /// <summary>
        /// ticket정보 (사진정보포함)
        /// </summary>
        /// <param name="ticketNo"></param>
        /// <returns></returns>
        public async Task<TParkingTicketInfo> GetTicketInfoWithImage(string ticketNo)
        {
            var row = await context.Set<TParkingTicketInfo>()
                        //.Include(p => p.TParkingTicketUseDiscount)
                        .FirstOrDefaultAsync(p => p.TicketNo == ticketNo).ConfigureAwait(false);

            return row;
        }
    }
}
