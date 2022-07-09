using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingLotBasicInfo
    {
        public TParkingLotBasicInfo()
        {
            //TParkingDeviceInfo = new HashSet<TParkingDeviceInfo>();
            //TParkingMonitoringAlert = new HashSet<TParkingMonitoringAlert>();
            //TParkingSeasonTicket = new HashSet<TParkingSeasonTicket>();
            //TParkingTicketInfo = new HashSet<TParkingTicketInfo>();
        }

        public int PIdx { get; set; }
        public string Plcode { get; set; }
        public string PlcodeName { get; set; }
        public string Pladdress { get; set; }
        public string PlencKey { get; set; }
        public string Pltype { get; set; }
        public DateTime PlregDate { get; set; }
        public DateTime? PlmodDate { get; set; }
        public string RegEmpId { get; set; }
        public bool PlisActive { get; set; }

        //public virtual ICollection<TParkingDeviceInfo> TParkingDeviceInfo { get; set; }
        //public virtual ICollection<TParkingMonitoringAlert> TParkingMonitoringAlert { get; set; }
        //public virtual ICollection<TParkingSeasonTicket> TParkingSeasonTicket { get; set; }
        //public virtual ICollection<TParkingTicketInfo> TParkingTicketInfo { get; set; }
    }
}
