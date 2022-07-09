using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parkgin.Server.Application.Model;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.ParameterModels;
using Parking.Server.Infrastructure.Repositories;
using Parkintg.Server.Application.Services;

namespace Parkgin.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingInfoController : ControllerBase
    {
        IParkingLotBasicInfoRepository _tparingLotBasicInfoRepository;
        private readonly IParkingManagerService _parkingManagerService;
        public ParkingInfoController(IParkingLotBasicInfoRepository tParkingLotBasicInfoRepository, IParkingManagerService parkingManagerService)
        {
            _tparingLotBasicInfoRepository = tParkingLotBasicInfoRepository;
            _parkingManagerService = parkingManagerService;
        }
        [Route("find-parking-info")]
        [HttpGet]
        public IActionResult GetBasicInfo(string parkingCode)
        {
            //var request = Request;
            //var headers = request.Headers;
            //var parkingHeaderEncCode = headers["parkingEncCode"].ToString();
            string parkingHeaderEncCode = "";
            var row = ParkingBasicCacheInfo.FindParkingInfo(parkingHeaderEncCode);

            return Ok(row);
        }

        [Route("get-parking-list")]
        [HttpGet]
        public async Task<IActionResult> GetAllParkingList()
        {
            var list = await _parkingManagerService.GetListParkingInfoWithDevice().ConfigureAwait(false);

            return Ok(list);
        }

        [Route("get-parking")]
        [HttpGet]
        public async Task<IActionResult> GetAllParkingList(string plCode)
        {
            var list = await _parkingManagerService.GetParkingInfoWithDevice(code: "").ConfigureAwait(false);

            return Ok(list);
        }

        /// <summary>
        /// 주차장 기본정보 입력
        /// </summary>
        /// <param name="newParkingLot"></param>
        /// <returns></returns>
        [Authorize]
        [Route("add-parkingInfo")]
        [HttpPost]
        //public async Task<IActionResult> AddParkingInfo(string plCode, string plCodeName,  string plAddress, string plType, string empId, bool isActive)
        public async Task<IActionResult> AddParkingInfo(CreateParkingLotBasicInfoModel newParkingLot)
        {
            var row =  await _parkingManagerService.CreateParkingLotInfo(newParkingLot);
            
            return Ok(row);
        }
    }
}