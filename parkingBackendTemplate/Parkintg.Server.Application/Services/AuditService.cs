using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.DtoModels;
using Parking.Server.Infrastructure.SeedWork;
using Parkintg.Server.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parkintg.Server.Application.Service
{
    /// <summary>
    /// 서비스에 대한 audit
    /// 회원로그인 및 내역변경에 대한 기록을 담당
    /// </summary>
    public class AuditService : IAuditLogService
    {
        //private readonly ParkingIntegratedControlCenterContext _context;
        private readonly IUnitOfWork _unitOfWork;
        
        public AuditService(IUnitOfWork UnitOfWork)
        {
            //_context = ParkingIntegratedControlCenterContext;
            _unitOfWork = UnitOfWork;
        }

        /// <summary>
        /// audit save
        /// </summary>
        /// <param name="newAuditLog"></param>
        /// <returns></returns>
        public async Task<TAuditLog> CreateAuditLog(TAuditLog newAuditLog)
        {
            TAuditLog newRow = new TAuditLog();
            newRow.DataModifyDate = null;
            newRow.DataRegDate = DateTime.Now;
            newRow.EventSorce = newAuditLog.EventSorce;
            newRow.EmpId = newAuditLog.EmpId;
            newRow.UserIpAddr = newAuditLog.UserIpAddr;

            await _unitOfWork.AuditLog.AddAsync(newRow);
            await _unitOfWork.CommitAsync();

            return newRow;
        }

        public async Task<TAuditLog> GetAuditLogById(int aIdx)
        {
            return await _unitOfWork.AuditLog.GetWithAuditLogByIdAsync(aidx: aIdx).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TAuditLog>> GetUserAuditLog(string userId)
        {
            var row = await _unitOfWork.AuditLog.GetAllWithAuditLogAsync(userId: userId);
            return row;
        }

        /// <summary>
        /// 로그인 기록작성
        /// </summary>
        public void LoginAuditWrite(AuditLoginModelDto loingDto)
        {

        }
    }
}
