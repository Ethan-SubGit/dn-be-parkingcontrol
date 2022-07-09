using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingMonitoringLog
    {
        public int LIdx { get; set; }
        public int? RefDdix { get; set; }
        public string HealthStatus { get; set; }
        public DateTime DataRegDate { get; set; }

        public virtual TParkingDeviceInfo RefDdixNavigation { get; set; }
    }
}
