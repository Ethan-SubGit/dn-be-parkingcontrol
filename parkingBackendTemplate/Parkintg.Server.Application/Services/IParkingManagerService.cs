using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.ParameterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parkintg.Server.Application.Services
{
    public interface IParkingManagerService
    {
        #region ## 기본정보
        Task<TParkingLotBasicInfo> GetParkingInfoByCode(string code);
        Task<TParkingLotBasicInfo> GetParkingInfoByEncKey(string encKey);
        Task<IEnumerable<TParkingLotBasicInfo>> GetListParkingInfo(string searchKey, string searchValue);
        Task<TParkingLotBasicInfo> CreateParkingLotInfo(CreateParkingLotBasicInfoModel newParkingInfo);
        Task<TParkingLotBasicInfo> GetParkingInfoWithDevice(string code);
        Task<List<TParkingLotBasicInfo>> GetListParkingInfoWithDevice();
        
        #endregion

        #region ## 장비정보
        Task<TParkingDeviceInfo> CreateParkingDeviceInfo(TParkingDeviceInfo newDevice);
        Task<TParkingDeviceInfo> GetParkingDeviceInfoWithDeviceId(string deviceId);
        Task<TParkingDeviceInfo> GetListParkingDeviceInfoByCode(string code);
        //Task<TParkingLotBasicInfo> AddParkingLotinfo(string plCode, string plCodeName, string plAddress, string plType, string empId, bool isActive);

        #endregion



    }
}
