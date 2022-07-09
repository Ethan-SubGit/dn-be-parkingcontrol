using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingDeviceInfo
    {
        public TParkingDeviceInfo()
        {
            TParkingMonitoringLog = new HashSet<TParkingMonitoringLog>();
        }

        public int DIdx { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceDescription { get; set; }
        public string Plcode { get; set; }
        public bool? IsHealthCheck { get; set; }
        public string DeviceIpAddr { get; set; }
        public string HealthStatus { get; set; }
        public DateTime? DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }
        public int? DisplayOrder { get; set; }
        public string Etc { get; set; }

        public virtual TParkingLotBasicInfo PlcodeNavigation { get; set; }
        public virtual ICollection<TParkingMonitoringLog> TParkingMonitoringLog { get; set; }
    }
}
