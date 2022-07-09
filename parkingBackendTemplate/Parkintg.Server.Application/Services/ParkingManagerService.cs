using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Models.ParameterModels;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parkintg.Server.Application.Services
{
    

    public class ParkingManagerService : IParkingManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParkingManagerService(IUnitOfWork UnitOfWork)
        {
            //_context = ParkingIntegratedControlCenterContext;
            _unitOfWork = UnitOfWork;
        }

        #region ## basic info
        public async Task<TParkingLotBasicInfo> CreateParkingLotInfo(CreateParkingLotBasicInfoModel p)
        {
            TParkingLotBasicInfo newRow = new TParkingLotBasicInfo()
            {
                PIdx = 0,
                Plcode = p.Plcode,
                PlcodeName = p.PlcodeName,
                Pladdress = p.Pladdress,
                PlencKey = new Guid().ToString(),
                Pltype = p.Pltype,
                PlregDate = DateTime.Now,
                RegEmpId = p.RegEmpId,
                PlisActive = p.PlisActive
            };
            //newRow = newParkingInfo;

            await _unitOfWork.ParkingLotBasicInfo.AddAsync(newRow).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return newRow;
        }

        public async Task<TParkingLotBasicInfo> GetParkingInfoByCode(string code)
        {
            var row = await _unitOfWork.ParkingLotBasicInfo.SingleOrDefaultAsync(p => p.Plcode == code);

            return row;
        }

        public Task<TParkingLotBasicInfo> GetParkingInfoByEncKey(string encKey)
        {
            throw new NotImplementedException();
        }

        public async Task<TParkingLotBasicInfo> GetParkingInfoWithDevice(string code)
        {
            var row = await _unitOfWork.ParkingLotBasicInfo.GetParkingLotBasicInfoWithDeviceInfo(code: code).ConfigureAwait(false);

            return row;
        }

        public async Task<List<TParkingLotBasicInfo>> GetListParkingInfoWithDevice()
        {
            var list = await _unitOfWork.ParkingLotBasicInfo.GetListParkingLotBasicInfoWithDeviceInfo().ConfigureAwait(false);

            return list;
        }

        #endregion


        #region device info

        public Task<TParkingDeviceInfo> CreateParkingDeviceInfo(TParkingDeviceInfo newDevice)
        {
            throw new NotImplementedException();
        }

       

        public Task<TParkingDeviceInfo> GetListParkingDeviceInfoByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TParkingLotBasicInfo>> GetListParkingInfo(string searchKey, string searchValue)
        {
            throw new NotImplementedException();
        }

        public Task<TParkingDeviceInfo> GetParkingDeviceInfoWithDeviceId(string deviceId)
        {
            throw new NotImplementedException();
        }

       
        #endregion


    }
}
