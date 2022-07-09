using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public interface IParkingTicketInfoRepository : IRepository<TParkingTicketInfo>
    {
        /// <summary>
        /// 주차정보
        /// </summary>
        /// <param name="ticketNo"></param>
        /// <returns></returns>
        Task<TParkingTicketInfo> GetTicketInfoWithImage(string ticketNo);
    }
}
