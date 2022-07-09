using System;
using System.Collections.Generic;

namespace Parking.Server.Infrastructure.Models
{
    public partial class TParkingSeasonTicket
    {
        public int SIdx { get; set; }
        public string UserId { get; set; }
        public string CarDisplayNo { get; set; }
        public string Plcode { get; set; }
        public int? TicketPrice { get; set; }
        public int? DiscountPrice { get; set; }
        public int? RealPrice { get; set; }
        public DateTime? ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public DateTime? DataRegDate { get; set; }

        public virtual TParkingLotBasicInfo PlcodeNavigation { get; set; }
    }
}
