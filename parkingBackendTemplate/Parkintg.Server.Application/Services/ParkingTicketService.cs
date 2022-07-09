using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.ParameterModels;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parkintg.Server.Application.Services
{
    public class ParkingTicketService : IParkingTicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParkingTicketService(IUnitOfWork UnitOfWork)
        {
            //_context = ParkingIntegratedControlCenterContext;
            _unitOfWork = UnitOfWork;
        }

        public async Task<TParkingTicketInfo> CreateParkingTicket(CreateParkingTicket ticket)
        {
            TParkingTicketInfo newRow = new TParkingTicketInfo()
            {
                CarDisplayNo = ticket.CarDisplayNo,
                DataRegDate = DateTime.Now,
                DiscountPrice = ticket.DiscountPrice ?? 0,
                ChargePrice = ticket.ChargePrice ?? 0,
                ImgPath = ticket.ImgPath,
                IsPaid = ticket.IsPaid,
                IsCancel = ticket.IsCancel == true ? true: false,
                PaidDate = ticket.PaidDate,
                PayStatus = ticket.PayStatus,
                PayTypeCd = ticket.PayTypeCd,
                Plcode = ticket.Plcode,
                RealPayPrice =  ticket.RealPayPrice ?? 0,
                RefundPrice= ticket.RefundPrice ?? 0,
                TicketCloseDate = ticket.TicketCloseDate ?? null,
                TicketNo = ticket.TicketNo,
                TicketOpenDate = ticket.TicketOpenDate ,
                //TParkingTicketUseDiscount = ticket.TParkingTicketUseDiscount,
                UseTime = ticket.UseTime
            };

            //TParkingTicketUseDiscount discountRow
            foreach (var item in ticket.TParkingTicketUseDiscount)
            {
                await _unitOfWork.ParkingTicketUseDiscountRepository.AddAsync(item).ConfigureAwait(false);
            }

            await _unitOfWork.ParkingTicketInfo.AddAsync(newRow).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return newRow;
        }
    }
}
