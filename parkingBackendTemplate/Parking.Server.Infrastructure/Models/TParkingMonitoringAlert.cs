using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingMonitoringAlert
    {
        public int AIdx { get; set; }
        public string Plcode { get; set; }
        public string AlertReceiveNo { get; set; }
        public bool IsActive { get; set; }
        public string RegEmpId { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual TParkingLotBasicInfo PlcodeNavigation { get; set; }
    }
}
