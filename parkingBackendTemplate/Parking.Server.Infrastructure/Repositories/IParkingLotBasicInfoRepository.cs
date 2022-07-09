using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    //public interface ITParkingLotBasicInfoRepository : IRepository<TParkingLotBasicInfo>
    public interface IParkingLotBasicInfoRepository : IRepository<TParkingLotBasicInfo>
    {
        //TParkingLotBasicInfo Create(TParkingLotBasicInfo tparkingLotBasicInfo);
        //Task<TParkingLotBasicInfo> Retrieve(string code);
        //Task<List<TParkingLotBasicInfo>> Retrieves();
        //Task<TParkingLotBasicInfo> RetrieveWithEncCode(string encCode);

        TParkingLotBasicInfo Update(TParkingLotBasicInfo tparkingLotBasicInfo);

        Task<TParkingLotBasicInfo> GetParkingLotBasicInfoWithDeviceInfo(string code);
        Task<List<TParkingLotBasicInfo>> GetListParkingLotBasicInfoWithDeviceInfo();
        Task<TParkingLotBasicInfo> AddParkingInfo(string plCode, string plCodeName, string plAddress, string plType, string empId, bool isActive);
    }
}
