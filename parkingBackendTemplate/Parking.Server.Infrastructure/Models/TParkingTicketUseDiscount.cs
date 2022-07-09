using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingTicketUseDiscount
    {
        public int DIdx { get; set; }
        public string TicketNo { get; set; }
        public string Plcode { get; set; }
        public string DiscountCd { get; set; }
        public int? UseCount { get; set; }
        public string Etc { get; set; }

        //public virtual TDiscountInfo DiscountCdNavigation { get; set; }
        //public virtual TParkingTicketInfo TicketNoNavigation { get; set; }
    }
}
