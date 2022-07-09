using Parking.Server.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkgin.Server.Application.Model
{
    public class ParkingBasicCacheInfo
    {
        public static List<ParkingBasicInfo> parkingBasicInfo;


        private static void isExParkingCode()
        {
            //parkingBasicInfo = _tParkingLotBasicInfoRepository.Retrieves().ConfigureAwait(false);
            if (parkingBasicInfo == null)
            {
                parkingBasicInfo = new List<ParkingBasicInfo>();
                //DB에서 값을 가져온다.
                //skip Data Insert
                parkingBasicInfo.Add(new ParkingBasicInfo
                {
                    ParkCode = "A00001",
                    ParkAddress = "남대문구 남가1로",
                    ParkEncKey = Guid.NewGuid().ToString()
                });

                parkingBasicInfo.Add(new ParkingBasicInfo
                {
                    ParkCode = "A00001",
                    ParkAddress = "남대문구 남가1로",
                    ParkEncKey = Guid.NewGuid().ToString()
                });

                parkingBasicInfo.Add(new ParkingBasicInfo
                {
                    ParkCode = "A00002",
                    ParkAddress = "관악로 관악길",
                    ParkEncKey = Guid.NewGuid().ToString()
                });

                parkingBasicInfo.Add(new ParkingBasicInfo
                {
                    ParkCode = "A00003",
                    ParkAddress = "대학로 대학길16",
                    ParkEncKey = Guid.NewGuid().ToString()
                });
            }
        }

        public static List<ParkingBasicInfo> FindParkingInfo(string parkingCode = "")
        {
            isExParkingCode();
            //var row = parkingBasicInfo.Where(p => p.ParkCode == parkingCode).FirstOrDefault();
            var row = parkingBasicInfo;
            //if (!string.IsNullOrEmpty(parkingCode) )
            //{
            //    row = row.Where(p => p.ParkCode == parkingCode).FirstOrDefault();
            //}

            if (row == null)
            {
                return null;
            }
            return row;
        }

        
    }

    public class ParkingBasicInfo
    {
        public string ParkCode { get; set; }
        public string ParkAddress { get; set; }
        public string ParkEncKey { get; set; }
    }
}
