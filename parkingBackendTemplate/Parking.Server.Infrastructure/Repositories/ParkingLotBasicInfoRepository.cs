using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public class ParkingLotBasicInfoRepository : Repository<TParkingLotBasicInfo>, IParkingLotBasicInfoRepository
    {
        public ParkingLotBasicInfoRepository(ParkingIntegratedControlCenterContext context) : base(context) { }

        public TParkingLotBasicInfo Update(TParkingLotBasicInfo tparkingLotBasicInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// device 정보와 함께 리턴
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<TParkingLotBasicInfo> GetParkingLotBasicInfoWithDeviceInfo(string code = "")
        {
            var basicRow = new TParkingLotBasicInfo();
            if (!string.IsNullOrEmpty(code))
            {
                //basicRow = await context.Set<TParkingLotBasicInfo>().Include(p => p.TParkingDeviceInfo)
                //            .FirstOrDefaultAsync(p => p.Plcode == code);
                basicRow = await context.Set<TParkingLotBasicInfo>()
                            .FirstOrDefaultAsync(p => p.Plcode == code);
            }
            else
            {
                //basicRow = await context.Set<TParkingLotBasicInfo>().Include(p => p.TParkingDeviceInfo)
                //            .FirstOrDefaultAsync();
                basicRow = await context.Set<TParkingLotBasicInfo>()
                            .FirstOrDefaultAsync();
            }
                        

            return basicRow;
        }

        public async Task<List<TParkingLotBasicInfo>> GetListParkingLotBasicInfoWithDeviceInfo()
        {
            //var rowList = await context.Set<TParkingLotBasicInfo>().Include(p => p.TParkingDeviceInfo)
            //                .ToListAsync().ConfigureAwait(false);
            var rowList = await context.Set<TParkingLotBasicInfo>()
                            .ToListAsync().ConfigureAwait(false);

            return rowList;
        }

        public async Task<TParkingLotBasicInfo> AddParkingInfo(string plCode, string plCodeName, string plAddress, string plType, string empId, bool isActive)
        {
            TParkingLotBasicInfo row = new TParkingLotBasicInfo();
            row.Plcode = plCode;
            row.PlcodeName = plCodeName;
            row.Pladdress = plAddress;
            row.Pltype = plType;
            row.RegEmpId = empId;
            row.PlisActive = isActive;
            row.PlregDate = DateTime.Now;


            var returnRow = context.Set<TParkingLotBasicInfo>().Add(row).Entity;
            await context.SaveChangesAsync().ConfigureAwait(false);
            //var row = context.TParkingLotBasicInfos.Add(row).Entity;
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            return returnRow;

        }
    }
}
