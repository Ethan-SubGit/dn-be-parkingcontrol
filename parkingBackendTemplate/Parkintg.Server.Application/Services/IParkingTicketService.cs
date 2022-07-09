using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.ParameterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parkintg.Server.Application.Services
{
    public interface IParkingTicketService
    {
        Task<TParkingTicketInfo> CreateParkingTicket(CreateParkingTicket ticket);
    }
}
