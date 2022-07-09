using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking.Server.Infrastructure.Models;
using Parkintg.Server.Application.Services;

namespace Parkgin.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;
        public AuditController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        /// <summary>
        /// 회원감사로그
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-log")]
        public async Task<IActionResult> GetAllAuditLog(string userId)
        {
            var rowList = await _auditLogService.GetUserAuditLog(userId: userId).ConfigureAwait(false);

            return Ok(rowList);
        }

        /// <summary>
        /// AuditLog Save
        /// </summary>
        /// <param name="newAuditLog"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("save-log")]
        public async Task<IActionResult> SaveAuditLog([FromBody] TAuditLog newAuditLog)
        {

            var newRow = await _auditLogService.CreateAuditLog(newAuditLog: newAuditLog);
            
            return Ok(newRow);
        }
    }
}