using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Parking.Server.Infrastructure.Models.ParameterModels;
using Parkintg.Server.Application.Services;

namespace Parkgin.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingTicketController : ControllerBase
    {
        private readonly IParkingTicketService _parkingTicketService;
        public ParkingTicketController(IParkingTicketService parkingTicketService)
        {
            _parkingTicketService = parkingTicketService;
        }

        /// <summary>
        /// 주차권 발생정보 기록
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [Route("create-parking-ticket")]
        [HttpPost]
        public async Task<IActionResult> CreateParkingTicket(CreateParkingTicket ticket)
        {
            if (ticket == null || ticket.TicketNo == null || string.IsNullOrEmpty( ticket.TicketNo))
            {
                return BadRequest("필요한 parameter 정보가 없습니다.");
            }
            var row = await _parkingTicketService.CreateParkingTicket(ticket);
            return Ok(row);
        }
    }
}