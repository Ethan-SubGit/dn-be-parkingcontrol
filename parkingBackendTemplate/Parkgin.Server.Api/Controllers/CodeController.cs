using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Procedure;
using Parking.Server.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parkgin.Server.Api.Controllers
{
    //[Authorize]
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]")]
    public class CodeController : ControllerBase
    {
        //private readonly ParkingIntegratedControlCenterContext ParkingIntegratedControlCenterContext;
        private readonly ISP_Code_Projection _sp_Code_Projection;
        private readonly ITCodeMasterRepository _tCodeMasterRespository;
        public CodeController(ISP_Code_Projection sp_TCode
            , ITCodeMasterRepository tCodeMasterRespository)
        {
            //ParkingIntegratedControlCenterContext = _ParkingIntegratedControlCenterContext;
            _sp_Code_Projection = sp_TCode;
            _tCodeMasterRespository = tCodeMasterRespository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public string Get()
        {
            var request = Request;
            var headers = request.Headers;
            string returnValue = string.Empty;
            foreach (var headerItems in headers)
            {
                returnValue += $"{headerItems.Key.ToString()} // {headerItems.Value.ToString()}";
            }
            //return new string[] { "value1", "value2" };
            return returnValue;
        }

        /// <summary>
        /// header 값 출력
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("get-header")]
        public IActionResult GetHeader()
        {
            var request = Request;
            var headers = request.Headers;
            string returnValue = string.Empty;

            var jsonStr = JsonConvert.SerializeObject(headers);
            return Ok(jsonStr);
        }

        /// <summary>
        /// get CodeList
        /// </summary>
        /// <param name="cm_cd"></param>
        /// <returns></returns>
        [Route("get-code-list")] //sms-result-detail
        [HttpGet]

        public async Task<IActionResult> Get(string cm_cd)
        {
           
            var rowList = await _sp_Code_Projection.GetCodeList(CM_CD: cm_cd).ConfigureAwait(false);
            //ParkingIntegratedControlCenterContext.SPCodeLists
            return Ok(rowList);
        }

        

        // POST api/<controller>
        [HttpGet]
        [AllowAnonymous]
        [Route("save-codemaster")]
        public async Task<IActionResult> Get(string CM_CD, string CM_NM, string CM_USE_YN, string T_NM, string F_NM)
        {
            var rslt = await _sp_Code_Projection.InsertCodeMaster(CM_CD: CM_CD, CM_NM: CM_CD, CM_USE_YN: CM_USE_YN, T_NM: T_NM, F_NM: F_NM).ConfigureAwait(false);

            return Ok(rslt.First());
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("pdate-codemaster")]
        public async Task<IActionResult> UpdateCodeMaster([FromBody]TCodeMaster codeMaster)
        {
            //var rslt = await _tCodeMasterRespository.Update(TCodeMaster: codeMaster).ConfigureAwait(false);
            return Ok("");
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("delete-codemaster")]
        public async Task<IActionResult> DeleteCodeMaster(string CM_CD)
        {
            var rslt = await _sp_Code_Projection.DeleteCodeMaster(CM_CD: CM_CD)
                        .ConfigureAwait(false);

            if (string.Equals(rslt.First().RSLT.ToString(), "SUCCESS"))
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
