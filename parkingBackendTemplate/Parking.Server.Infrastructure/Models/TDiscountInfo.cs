using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TDiscountInfo
    {
        public TDiscountInfo()
        {
            TParkingTicketUseDiscount = new HashSet<TParkingTicketUseDiscount>();
        }

        public int DIdx { get; set; }
        public string DiscountCd { get; set; }
        public string DiscountCdnm { get; set; }
        public decimal DiscountRate { get; set; }
        public string RegEmpId { get; set; }
        public DateTime DataRegDate { get; set; }
        public DateTime? DataModDate { get; set; }

        public virtual ICollection<TParkingTicketUseDiscount> TParkingTicketUseDiscount { get; set; }
    }
}
